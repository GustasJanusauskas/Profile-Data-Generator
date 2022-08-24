using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socialmediadatagenerator
{
    public partial class MainForm : Form
    {
        List<Identity> generatedUsers = new List<Identity>();
        Dictionary<string,List<string>> nameLists = new Dictionary<string, List<string>>();

        String[] descriptionPrompts = { "I am", "I like", "I hate", "Why do", "I love" };
        List<string> generatedPosts = new List<string>();

        Random random = new Random();
        int facesCount = 0;

        string redditToken = "";
        string lastRedditPostName = "";

        public MainForm()
        {
            InitializeComponent();
            Init();

            //DEBUG
            redditUsernameBox.Text = "***REMOVED***";
            redditPasswordBox.Text = "***REMOVED***";
            redditIDBox.Text = "***REMOVED***";
            redditSecretBox.Text = "***REMOVED***";
            generateNumeric.Value = 1;
        }

        private void Init() {
            if (!Directory.Exists("profile_images")) return;

            //Count already generated faces so we can use them later
            facesCount = Directory.GetFiles("profile_images\\").Length;
            #if DEBUG
                string defaultDataDir = Path.GetFullPath(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\defaultdata");
            #else
                string defaultDataDir = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\defaultdata");
            #endif
            openFileDialog1.Filter = "Text files|*.txt|Comma separated values|*.csv";
            openFileDialog1.InitialDirectory = defaultDataDir;

            previewListView.View = View.Details;
            previewListView.FullRowSelect = true;
            previewListView.GridLines = true;

            previewListView.Columns.Add("ID");
            previewListView.Columns.Add("Username");
            previewListView.Columns.Add("Email");
            previewListView.Columns.Add("Password");
            previewListView.Columns.Add("First name");
            previewListView.Columns.Add("Last name");
            previewListView.Columns.Add("Description length");
            previewListView.Columns.Add("Profile image");

            if (!Directory.Exists(defaultDataDir)) {
                MessageBox.Show("Cannot find namelist directory, make sure a 'defaultdata' directory is in the same folder as executable, or use all custom namelists, including email and usernames.", "Missing namelists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Read default namelists
            foreach (var file in Directory.GetFiles(defaultDataDir)) {
                ReadNameList(File.ReadAllText(file), Path.GetFileName(file).Replace(".txt", ""));
            }
        }

        private async Task<Identity> GenerateIdentity() {
            Identity result = new Identity();

            result.email = generateEmailsCheckbox.Checked ? GenerateName(NameType.Email) : nameLists["email"][random.Next(0, nameLists["email"].Count)];
            result.userName = generateUsernamesCheckbox.Checked ? GenerateName(NameType.Username) : nameLists["username"][random.Next(0, nameLists["username"].Count)];
            result.password = GenerateName(NameType.Password);

            result.gender = random.Next(0, 2) == 0 ? "male" : "female";
            result.firstName = nameLists[result.gender + "firstname"][random.Next(0, nameLists[result.gender + "firstname"].Count)];
            result.lastName = nameLists["lastname"][random.Next(0, nameLists["lastname"].Count)];

            result.profileImagePath = Directory.GetFiles("profile_images\\")[random.Next(0,facesCount)];
            //Get description
            if (pregenDescBox.Checked) {
                result.description = nameLists["description"][random.Next(0, nameLists["description"].Count)];
            }
            else {
                var descTask = RequestsAPI.GetOpenAIResponse(descriptionPrompts[random.Next(0, descriptionPrompts.Length)], tokenBox.Text);
                result.description = await descTask;
            }
            //Add posts
            for (int i = 0; i < random.Next(0,3); i++) {
                result.posts.Add(pregenPostsBox.Checked ? nameLists["post"][random.Next(0,nameLists["post"].Count)] : generatedPosts[random.Next(0,generatedPosts.Count)]);
            }

            return result;
        }
        
        enum NameType {
            Username, Email, Password
        }
        private string GenerateName(NameType nameType) {
            string result = "";

            if (nameType == NameType.Email || nameType == NameType.Username) {
                result += nameLists["adjective"][random.Next(0, nameLists["adjective"].Count)];
                result += nameLists["object"][random.Next(0, nameLists["object"].Count)];
                for (int i = 0; i < random.Next(0, 6); i++) {
                    result += random.Next(0, 10);
                }

                if (nameType == NameType.Email) result += random.Next(0, 2) == 0 ? "@hotmail.com" : "@gmail.com";
            }
            else if (nameType == NameType.Password) {
                for (int i = 0; i < random.Next(1, 3); i++) {
                    result += nameLists["object"][random.Next(0, nameLists["object"].Count)];
                }

                for (int i = 0; i < random.Next(0, 6); i++) {
                    result += random.Next(0, 10);
                }
            }

            return result;
        }

        private async Task<PromptResult> GeneratePosts(int amount = 100, ProgressBar bar = null) {
            List<string> result = new List<string>();
            //Get reddit token and prompts
            redditToken = await RequestsAPI.GetRedditToken(redditUsernameBox.Text, redditPasswordBox.Text, redditIDBox.Text, redditSecretBox.Text);
            var postPrompts = await RequestsAPI.GetRedditWritingPrompts(redditToken,amount,lastRedditPostName);
            bar.Maximum = postPrompts.prompts.Count;
            bar.Value = 0;

            string tempPost;
            foreach (var prompt in postPrompts.prompts) {
                tempPost = await RequestsAPI.GetOpenAIResponse("Write a story with the prompt:\n" + prompt,tokenBox.Text);
                if (tempPost == null) continue;
                result.Add(tempPost.Trim());
                bar.Value++;
            }
            return new PromptResult(result,postPrompts.lastPromptName);
        }

        private void UpdatePreviewList() {
            previewListView.Items.Clear();

            int ind = 1;
            foreach (var user in generatedUsers) {
                var temp = new ListViewItem();
                temp.Tag = user;
                temp.Text = ind++.ToString();

                temp.SubItems.Add(user.userName);
                temp.SubItems.Add(user.email);
                temp.SubItems.Add(user.password);
                temp.SubItems.Add(user.firstName);
                temp.SubItems.Add(user.lastName);
                temp.SubItems.Add(user.description != null ? user.description.Length.ToString() : "-");
                temp.SubItems.Add(user.profileImagePath);

                previewListView.Items.Add(temp);
            }
        }

        //Manual read
        private void ReadNameList(Stream nameList, string category) {
            if (!nameLists.ContainsKey(category)) nameLists.Add(category,new List<string>());

            string tempStr;
            using (StreamReader streamReader = new StreamReader(nameList)) {
                tempStr = streamReader.ReadToEnd();
            }
            //Assume .txt files are newline separated
            if (openFileDialog1.FileName.Contains(".txt")) {
                nameLists[category] = tempStr.Split('\n').ToList();
            }
            //Comma separated values
            else if (openFileDialog1.FileName.Contains(".csv")) {
                nameLists[category] = tempStr.Split(',').ToList();
            }
        }

        //For automatic namelists
        private void ReadNameList(string nameList, string category) {
            if (!nameLists.ContainsKey(category)) nameLists.Add(category, new List<string>());

            //Comma separated values
            if (openFileDialog1.FileName.Contains(',')) {
                nameLists[category] = nameList.Split(',').ToList();
            }
            //Assume .txt files are newline separated
            else {
                nameLists[category] = nameList.Split('\n').ToList();
            }
        }

        private void SaveList(List<string> list, string filename) {
            if (!filename.Contains(".txt")) filename += ".txt";
            if (!Directory.Exists("lists")) Directory.CreateDirectory("lists");

            using (var writer = File.CreateText("lists\\" + filename)) {
                foreach (var item in list) {
                    //^ used as separator value
                    writer.Write(item.Replace('^','\0') + '^');
                }
            }
        }

        private List<string> LoadList(string filename) {
            if (!filename.Contains(".txt")) filename += ".txt";
            if (!Directory.Exists("lists") || !File.Exists("lists\\" + filename)) return null;

            List<string> result = new List<string>();
            var rawStr = File.ReadAllText("lists\\" + filename);
            foreach (var item in rawStr.Split('^')) {
                if (item.Trim().Length == 0) continue;

                result.Add(item);
            }
            return result;
        }

        private void generateFacesBtn_Click(object sender, EventArgs e) {
            int times = (int)facesNumeric.Value;
            facesBar.Value = 0;
            facesBar.Maximum = times;

            generateFacesBtn.Enabled = false;
            var t = Task.Run(async delegate
            {
                for (int x = 0; x < times; x++)
                {
                    RequestsAPI.SaveProfilePicture((x).ToString());
                    Invoke(new Action( () => {
                        facesBar.Value++;
                    }));
                    await Task.Delay(1250);
                }
                facesCount = times > facesCount ? times : facesCount;
                generateFacesBtn.Enabled = true;
            });
        }

        private void nameListBtn_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ReadNameList(openFileDialog1.OpenFile(),"malefirstname");
            }
        }

        private void nameListFemaleBtn_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ReadNameList(openFileDialog1.OpenFile(), "femalefirstname");
            }
        }

        private void lastNameListBtn_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ReadNameList(openFileDialog1.OpenFile(), "lastname");
            }
        }

        private void emailListBtn_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ReadNameList(openFileDialog1.OpenFile(), "email");
            }
        }

        private void UsernameListBtn_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ReadNameList(openFileDialog1.OpenFile(), "username");
            }
        }

        private void generateEmailsCheckbox_CheckedChanged(object sender, EventArgs e) {
            emailListBtn.Enabled = !generateEmailsCheckbox.Checked;
        }

        private void generateUsernamesCheckbox_CheckedChanged(object sender, EventArgs e) {
            UsernameListBtn.Enabled = !generateUsernamesCheckbox.Checked;
        }

        private void customNamelistsCheckbox_CheckedChanged(object sender, EventArgs e) {
            nameListBtn.Enabled = customNamelistsCheckbox.Checked;
            nameListFemaleBtn.Enabled = customNamelistsCheckbox.Checked;
            lastNameListBtn.Enabled = customNamelistsCheckbox.Checked;
        }

        private async void button2_Click(object sender, EventArgs e) {
            if (tokenBox.Text.Length < 51 && (!pregenPostsBox.Checked || !pregenDescBox.Checked)) {
                MessageBox.Show("Please enter your openAI token first.", "Missing openAI token", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (generatedPosts.Count == 0 && !pregenPostsBox.Checked) {
                MessageBox.Show("Please generate some posts first.", "Missing posts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (facesCount == 0) {
                MessageBox.Show("Please generate some profile images first.", "Missing profile images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int total = (int)generateNumeric.Value;
            generateBar.Value = 0;
            generateBar.Maximum = total;

            Task<Identity> task;
            Identity temp;
            mainTaskLabel.Text = "Generating user info...";
            for (int i = 0; i < total; i++) {
                task = GenerateIdentity();
                temp = await task;
                Invoke(new Action(() => {
                    generatedUsers.Add(temp);
                    UpdatePreviewList();
                    generateBar.Value++;
                }));
            }
            generateBar.Value = 0;
            mainTaskLabel.Text = "Done!";
        }

        private async void genPostsBtn_Click(object sender, EventArgs e) {
            if (tokenBox.Text.Length < 51) {
                MessageBox.Show("Please enter your openAI token first.","Missing openAI token",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (redditUsernameBox.Text.Length == 0 || redditPasswordBox.Text.Length == 0 || redditIDBox.Text.Length == 0 || redditSecretBox.Text.Length == 0) {
                MessageBox.Show("Please enter your reddit API access data first.", "Missing reddit API data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Generate posts
            mainTaskLabel.Text = "Generating user posts...";
            var newPosts = await GeneratePosts((int)genPostsNumeric.Value,mainProgBar);
            Invoke(new Action(() => {
                lastRedditPostName = newPosts.lastPromptName;
                foreach (var post in newPosts.prompts) {
                    generatedPosts.Add(post);
                }
            }));
            mainProgBar.Value = 0;
            mainTaskLabel.Text = "Done!";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveList(generatedPosts,"genPosts.txt");
            File.WriteAllText("lists\\genParams.txt", lastRedditPostName);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var temp = LoadList("genPosts.txt");
            generatedPosts = temp != null ? temp : generatedPosts;
            lastRedditPostName = File.Exists("lists\\genParams.txt") ? File.ReadAllText("lists\\genParams.txt") : "";
        }
    }
}
