using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace socialmediadatagenerator {
    public partial class RegisterUsersForm : Form {
        public List<Identity> usersToRegister = new List<Identity>();

        public Dictionary<string, string> userSessions = new Dictionary<string, string>();
        public List<int> userIDs = new List<int>();
        public List<int> userPostIDs = new List<int>();

        public string defaultdatadir;

        string url;

        public RegisterUsersForm(List<Identity> users, string datadir) {
            InitializeComponent();

            usersToRegister = users;
            defaultdatadir = datadir;

            registerUsersBtn.Text = $"Register {usersToRegister.Count} users";
            progressBar1.Maximum = usersToRegister.Count;
        }

        private async void SetupUsers() {
            foreach (var user in usersToRegister) {
                Invoke(new Action(() => {
                    nameLabel.Text = $"Registering user {user.userName}...";
                }));

                //Register user
                var task = RegisterUsersAPI.RegisterProfile(user, url);
                var data = await task;

                if (data["success"]) {
                    //If successful, log in
                    task = RegisterUsersAPI.Login(user, url);
                    data = await task;

                    if (!data["success"]) { //Critical step, ignore user if failed
                        usersToRegister.Remove(user);
                        continue;
                    }
                    var session = data["session"];
                    userSessions.Add(user.userName,session);

                    //Then, get profile image and update profile
                    var avatarbase64 = HelperFunctions.ConvertToBase64String(File.OpenRead("profile_images\\" + user.profileImagePath));

                    task = RegisterUsersAPI.SetProfile(user, session, avatarbase64, url);
                    data = await task;

                    if (!data["success"]) { //Critical step, ignore user if failed
                        usersToRegister.Remove(user);
                        continue;
                    }

                    //Next, upload all images
                    string tempImgStr;
                    List<string> usrImages = new List<string>();
                    foreach (var img in user.images) {
                        tempImgStr = HelperFunctions.ConvertToBase64String(File.OpenRead(Path.GetFullPath(defaultdatadir + "\\" + img)));
                        task = RegisterUsersAPI.UploadImage(session, tempImgStr, url);
                        data = await task;
                        if (data != null) usrImages.Add(data["filename"]);
                    }

                    //Then, add posts, including random uploaded images, if any present
                    string tempImg;
                    int lastImgInd = 0;
                    foreach (var post in user.posts) {
                        if (lastImgInd >= usrImages.Count) lastImgInd = 0;
                        tempImg = usrImages[lastImgInd++];

                        post.body += $"\n[img]{tempImg}[/img]";

                        await RegisterUsersAPI.AddPost(post, new List<string>(new string[] { tempImg }), session, url);
                    }
                }
                else {
                    usersToRegister.Remove(user);
                    continue;
                }

                Invoke(new Action(() => {
                    progressBar1.Value++;
                }));
            }
        }

        private async void PerformUserActions() {
            //Get user ID's and all posts
            foreach (var user in usersToRegister) {
                var task = RegisterUsersAPI.GetUserInfo(userSessions[user.userName], url);
                var data = await task;

                userIDs.Add(data["ID"]);
                foreach (var id in data["posts"]) {
                    userPostIDs.Add(int.Parse(id.ToString()));
                }
            }

            //Perform user actions
            Random rnd = new Random();
            int currentIndex;
            foreach (var user in usersToRegister) {
                //Add friends
                currentIndex = 0;
                while (true) {
                    await RegisterUsersAPI.AddFriend(userIDs[currentIndex], userSessions[user.userName], url);
                    currentIndex += rnd.Next(1, 2 + (userIDs.Count / 20));
                    if (currentIndex >= userIDs.Count) break;
                }

                //Like posts
                currentIndex = 0;
                while (true) {
                    await RegisterUsersAPI.LikePost(userPostIDs[currentIndex], userSessions[user.userName], url);
                    currentIndex += rnd.Next(1, 4);
                    if (currentIndex >= userPostIDs.Count) break;
                }

                //Add comments to posts TODO: generate and use comments
                currentIndex = 0;
                while (true) {
                    await RegisterUsersAPI.AddComment(userPostIDs[currentIndex], userSessions[user.userName],"Sample comment.", url);
                    currentIndex += rnd.Next(1, 6);
                    if (currentIndex >= userPostIDs.Count) break;
                }
            }

            //Get and accept friend requests
            foreach (var user in usersToRegister) {
                var task = RegisterUsersAPI.GetUserInfo(userSessions[user.userName], url);
                var data = await task;
                List<int> fRequests = new List<int>();

                foreach (int req in data["friendRequests"]) {
                    await RegisterUsersAPI.AddFriend(req,userSessions[user.userName],url);
                }
            }
        }

        private async void registerUsersBtn_Click(object sender, EventArgs e) {
            if (urlBox.Text.Trim().Length == 0) {
                MessageBox.Show("Please enter the socialmediasite instance URL.", "No URL entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            url = urlBox.Text;
            if (url[url.Length - 1] == '/') url = url.Substring(0, url.Length - 1);
            if (!url.Contains("http://") && !url.Contains("https://")) url = sslCheckbox.Checked ? "https://" + url : "http://" + url;

            SetupUsers();
            PerformUserActions();
            Invoke(new Action(() => {
                nameLabel.Text = $"Registration complete! Registered {usersToRegister.Count} users.";
                usersToRegister.Clear();
            }));
        }
    }
}
