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
using System.Json;
using System.Text.Json;

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

        private async Task SetupUsers() {
            Identity user;
            for (int i = 0; i < usersToRegister.Count; i++) {
                user = usersToRegister[i];
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
                        i--;
                        continue;
                    }
                    var session = data["session"];
                    userSessions.Add(user.userName,session);

                    //Then, get profile image and update profile
                    var avatarbase64 = HelperFunctions.ConvertToBase64String(File.OpenRead("profile_images\\" + user.profileImagePath));

                    //Limit description size
                    if (user.description.Length > 1024) user.description = user.description.Substring(0, 1024);

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
                        tempImgStr = HelperFunctions.ConvertToBase64String(File.OpenRead(img));
                        task = RegisterUsersAPI.UploadImage(session, tempImgStr, url);
                        data = await task;
                        if (data != null) usrImages.Add(data["filename"]);
                    }

                    //Then, add posts, including random uploaded images, if any present
                    Post post;
                    string tempImg;
                    int lastImgInd = 0;
                    for (int j = 0; j < user.posts.Count; j++) {
                        post = user.posts[j].Clone();
                        tempImg = null;
                        if (usrImages.Count > 0) {
                            if (lastImgInd >= usrImages.Count) lastImgInd = 0;
                            tempImg = usrImages[lastImgInd++];

                            post.body += $"\n[img]{tempImg}[/img]";
                        }

                        if (post.title.Length > 256) post.title = post.title.Substring(0,256);
                        if (post.body.Length > 4096) post.body = post.body.Substring(0,4096);
                        await RegisterUsersAPI.AddPost(post, new List<string>(tempImg != null ? new string[] { tempImg } : new string[] { }), session, url);
                    }
                }
                else {
                    usersToRegister.Remove(user);
                    i--;
                    continue;
                }

                Invoke(new Action(() => {
                    progressBar1.Value++;
                }));
            }
        }

        private async Task PerformUserActions() {
            Invoke(new Action(() => {
                progressBar1.Value = 0;
                nameLabel.Text = $"Getting user IDs...";
            }));
            //Get user ID's and all posts
            foreach (var user in usersToRegister) {

                var task = RegisterUsersAPI.GetUserInfo(userSessions[user.userName], url);
                var data = await task;

                userIDs.Add(data["ID"]);
                for (int i = 0; i < data["posts"].Count; i++) {
                    userPostIDs.Add(int.Parse(data["posts"][i]));
                }
            }

            //Perform user actions
            Random rnd = new Random();
            int currentIndex;
            foreach (var user in usersToRegister) {
                Invoke(new Action(() => {
                    nameLabel.Text = $"Performing actions with {user.userName}...";
                }));

                //Add friends
                currentIndex = 0;
                while (true) {
                    await RegisterUsersAPI.AddFriend(userIDs[currentIndex], userSessions[user.userName], url);
                    currentIndex += rnd.Next(1, 2 + (userIDs.Count / 2)); //~4 friends/ user at 100 users
                    if (currentIndex >= userIDs.Count) break;
                }

                //Like posts
                currentIndex = 0;
                while (true) {
                    await RegisterUsersAPI.LikePost(userPostIDs[currentIndex], userSessions[user.userName], url);
                    currentIndex += rnd.Next(1, 2 + (userPostIDs.Count / 10)); //~16 likes/user at 100 users
                    if (currentIndex >= userPostIDs.Count) break;
                }

                //Add comments to posts
                currentIndex = 0;
                while (true) {
                    if (user.comments.Count == 0) break;

                    await RegisterUsersAPI.AddComment(userPostIDs[currentIndex], userSessions[user.userName],user.comments[rnd.Next(0, user.comments.Count)], url);
                    currentIndex += rnd.Next(1, 2 + (userPostIDs.Count / 5)); //~10 comments/user at 100 users
                    if (currentIndex >= userPostIDs.Count) break;
                }

                Invoke(new Action(() => {
                    progressBar1.Value++;
                }));
            }

            Invoke(new Action(() => {
                nameLabel.Text = $"Accepting friend requests...";
            }));
            //Get and accept friend requests
            foreach (var user in usersToRegister) {
                var task = RegisterUsersAPI.GetUserInfo(userSessions[user.userName], url);
                var data = await task;

                for (int i = 0; i < data["friendRequests"].Count; i++) {
                    await RegisterUsersAPI.AddFriend(int.Parse(data["friendRequests"][i]),userSessions[user.userName],url);
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

            try {
                await SetupUsers();
                await PerformUserActions();
            }
            catch (System.Net.Http.HttpRequestException) {
                MessageBox.Show("Connection error. Make sure the adress entered is correct.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Invoke(new Action(() => {
                nameLabel.Text = $"Registration complete! Registered {usersToRegister.Count} users.";
                usersToRegister.Clear();
            }));
        }
    }
}
