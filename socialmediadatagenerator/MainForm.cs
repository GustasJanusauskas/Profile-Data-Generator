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
using System.Text.Json;

namespace socialmediadatagenerator
{
    public partial class MainForm : Form
    {
        List<Identity> generatedUsers = new List<Identity>();
        Dictionary<string,List<string>> nameLists = new Dictionary<string, List<string>>();
        List<Post> pregenPosts = new List<Post>();

        String[] descriptionPrompts = { "I am", "I like", "I hate", "Why do", "I love" };
        List<Post> generatedPosts = new List<Post>();

        Random random = new Random();
        int facesCount = 0;
        int imagesCount = 0;

        int pregenMaleFacesCount = 0;
        int pregenFemaleFacesCount = 0;
        int pregenOtherFacesCount = 0;

        string redditToken = "";
        string lastRedditPostName = "";

        string defaultDataDir;

        bool mainBarBusy;

        public MainForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.Icon;
            Init();
        }

        private void Init() {
            #if DEBUG
                defaultDataDir = Path.GetFullPath(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\defaultdata");
            #else
                defaultDataDir = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\defaultdata");
            #endif

            //Config elements
            openFileDialog1.Filter = "Text files|*.txt|Comma separated values|*.csv";
            openFileDialog1.InitialDirectory = defaultDataDir;

            openFileDialogJson.Filter = "Json files|*.json";
            openFileDialogJson.InitialDirectory = Directory.GetCurrentDirectory();

            saveFileDialog1.Filter = "Json files|*.json";
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

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
            previewListView.Columns.Add("Posts");
            previewListView.Columns.Add("Images");
            previewListView.Columns.Add("Comments");
            previewListView.Columns.Add("Profile image");

            if (!Directory.Exists(defaultDataDir)) {
                MessageBox.Show("Cannot find namelist directory, make sure a 'defaultdata' directory is in the same folder as executable, or use all custom namelists, including email and usernames.", "Missing namelists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Count already generated faces so we can use them later
            if (Directory.Exists("profile_images")) facesCount = Directory.GetFiles("profile_images\\").Length;
            imagesCount = Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\images\\")).Length;
            pregenMaleFacesCount = Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\male\\")).Length;
            pregenFemaleFacesCount = Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\female\\")).Length;
            pregenOtherFacesCount = Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\other\\")).Length;

            //Read default namelists
            foreach (var file in Directory.GetFiles(defaultDataDir)) {
                if (new string[] { ".txt",".csv" }.Contains(Path.GetExtension(file))) ReadNameList(File.ReadAllText(file), Path.GetFileName(file).Replace(".txt", "").Replace(".csv",""),Path.GetExtension(file));
            }
            //Read pregenerated posts
            pregenPosts = LoadListJson(Path.GetFullPath(defaultDataDir + "\\post.json"));
        }

        int usernameInd = 0;
        int emailInd = 0;
        private async Task<Identity> GenerateIdentity() {
            Identity result = new Identity();

            result.email = generateEmailsCheckbox.Checked ? GenerateName(NameType.Email) : nameLists["email"][emailInd++];
            result.userName = generateUsernamesCheckbox.Checked ? GenerateName(NameType.Username) : nameLists["username"][usernameInd++];
            result.password = GenerateName(NameType.Password);

            result.gender = random.Next(0, 2) == 0 ? "male" : "female";
            result.firstName = nameLists[result.gender + "firstname"][random.Next(0, nameLists[result.gender + "firstname"].Count)];
            result.lastName = nameLists["lastname"][random.Next(0, nameLists["lastname"].Count)];

            //Set profile image
            if (pregenProfileImgBox.Checked) {
                if (result.gender == "male") result.profileImagePath = Path.GetFullPath(Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\male\\"))[random.Next(0, pregenMaleFacesCount)]);
                else if (result.gender == "female") result.profileImagePath = Path.GetFullPath(Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\female\\"))[random.Next(0, pregenFemaleFacesCount)]);
                else result.profileImagePath = Path.GetFullPath(Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\profile_images\\other\\"))[random.Next(0, pregenOtherFacesCount)]);
            }
            else result.profileImagePath = Path.GetFullPath(Directory.GetFiles("profile_images\\")[random.Next(0,facesCount)]);

            //Get description
            if (pregenDescBox.Checked) {
                //Pregen descriptions get extra processing
                result.description = nameLists["description"][random.Next(0, nameLists["description"].Count)];
                result.description = result.description.Replace("{name}",result.firstName);

                if (result.gender == "male") {
                    result.description = result.description.Replace("{HeShe}", "He");
                    result.description = result.description.Replace("{heShe}", "he");
                    result.description = result.description.Replace("{hisHer}", "his");
                    result.description = result.description.Replace("{himHer}", "him");
                    result.description = result.description.Replace("{manWoman}", "man");
                    result.description = result.description.Replace("{fatherMother}", "father");
                }
                else {
                    result.description = result.description.Replace("{HeShe}", "She");
                    result.description = result.description.Replace("{heShe}", "she");
                    result.description = result.description.Replace("{hisHer}", "her");
                    result.description = result.description.Replace("{himHer}", "her");
                    result.description = result.description.Replace("{manWoman}", "woman");
                    result.description = result.description.Replace("{fatherMother}", "mother");
                }
            }
            else {
                result.description = $"Write a profile description for { new string[] {"a young","a middle-aged","an old"}[random.Next(0,3)] } {(result.gender == "male" ? "man" : "woman")} named {result.firstName}:\n";
                var descTask = RequestsAPI.GetOpenAIResponse(result.description, tokenBox.Text, 256);
                result.description = await descTask;
            }
            //Add posts
            int total = random.Next(0, 6);
            for (int i = 0; i < total; i++) {
                if (pregenPostsBox.Checked) {
                    result.posts.Add(pregenPosts[random.Next(0, pregenPosts.Count)]);
                }
                else {
                    result.posts.Add(generatedPosts[random.Next(0, generatedPosts.Count)]);
                }
            }
            //Add images
            total = random.Next(0, 4);
            for (int i = 0; i < total; i++) {
                result.images.Add(Directory.GetFiles(Path.GetFullPath(defaultDataDir + "\\images\\"))[random.Next(0, imagesCount)]);
            }
            //Add comments
            total = random.Next(0, 11);
            for (int i = 0; i < total; i++) {
                result.comments.Add(nameLists["comment"][random.Next(0, nameLists["comment"].Count)]);
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
            List<Post> result = new List<Post>();
            //Get reddit token and prompts
            redditToken = await RequestsAPI.GetRedditToken(redditUsernameBox.Text, redditPasswordBox.Text, redditIDBox.Text, redditSecretBox.Text);
            var postPrompts = await RequestsAPI.GetRedditWritingPrompts(redditToken,amount + 1,lastRedditPostName);
            bar.Maximum = postPrompts.prompts.Count;
            bar.Value = 0;

            string tempPost;
            string titlePrompt;
            string tempTitle;
            foreach (var prompt in postPrompts.prompts) {
                tempPost = await RequestsAPI.GetOpenAIResponse("Write a story with the prompt:\n" + prompt,tokenBox.Text,512);

                titlePrompt = tempPost.IndexOf('.') > 255 ? tempPost.Substring(0, 255) + ".\n" : tempPost.Substring(0, tempPost.IndexOf('.') + 1) + "\n";
                tempTitle = await RequestsAPI.GetOpenAIResponse("Title this story:\n" + titlePrompt,tokenBox.Text,64);

                if (tempPost == null || tempTitle == null) continue;
                result.Add(new Post(tempTitle.Trim(), tempPost.Trim()));
                bar.Value++;
            }
            return new PromptResult(result,null,postPrompts.lastPromptName);
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
                temp.SubItems.Add(user.posts.Count.ToString());
                temp.SubItems.Add(user.images.Count.ToString());
                temp.SubItems.Add(user.comments.Count.ToString());
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

            //Clean up values
            for (int i = 0; i < nameLists[category].Count; i++) {
                nameLists[category][i] = nameLists[category][i].Trim();
            }
        }

        //For automatic namelists
        private void ReadNameList(string nameList, string category, string extension) {
            if (!nameLists.ContainsKey(category)) nameLists.Add(category, new List<string>());

            //Comma separated values
            if (extension.Contains("csv")) {
                nameLists[category] = nameList.Split(',').ToList();
            }
            //Assume .txt files are newline separated
            else {
                nameLists[category] = nameList.Split('\n').ToList();
            }

            //Clean up values
            for (int i = 0; i < nameLists[category].Count; i++) {
                nameLists[category][i] = nameLists[category][i].Trim().Replace("\\n", "\n");
                //Delete empty values
                if (nameLists[category][i].Length == 0) {
                    nameLists[category].RemoveAt(i);
                    i--;
                }
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

        private void SaveList(List<Post> list, string filename) {
            if (!filename.Contains(".json")) filename += ".json";
            if (!Directory.Exists("lists")) Directory.CreateDirectory("lists");

            using (var writer = File.CreateText("lists\\" + filename)) {
                writer.Write( JsonSerializer.Serialize(list));
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

        private List<Post> LoadListJson(string filename) {
            if (!filename.Contains(".json")) filename += ".json";
            if (!File.Exists(filename)) return null;

            var rawStr = File.ReadAllText(filename);

            return JsonSerializer.Deserialize<List<Post>>(rawStr);
        }

        private async Task GenerateSampleImages(int amount) {
            if (mainBarBusy) {
                MessageBox.Show("Program busy, please wait until the current task is finished before starting a new one.", "Program busy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int startingIndex = random.Next(0,10000);

            Invoke(new Action(() => {
                mainBarBusy = true;
                mainTaskLabel.Text = "Generating sample images...";
                mainProgBar.Maximum = amount;
                mainProgBar.Value = 0;
            }));

            for (int i = startingIndex; i < startingIndex + amount; i++) {
                await RequestsAPI.SaveSamplePicture(i);
                Invoke(new Action(() => {
                    mainProgBar.Value++;
                }));
            }

            Invoke(new Action(() => {
                mainBarBusy = false;
                mainTaskLabel.Text = "Done!";
            }));
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
            generateFacesBtn.Enabled = true;
            facesBar.Value = 0;
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

            if (!customNamelistsCheckbox.Checked) {
                //Re-read default namelists
                foreach (var file in Directory.GetFiles(defaultDataDir)) {
                    ReadNameList(File.ReadAllText(file), Path.GetFileName(file).Replace(".txt", ""),Path.GetExtension(file));
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e) {
            int total = (int)generateNumeric.Value;

            if (tokenBox.Text.Length < 51 && (!pregenPostsBox.Checked || !pregenDescBox.Checked)) {
                MessageBox.Show("Please enter your openAI token first.", "Missing openAI token", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (generatedPosts.Count == 0 && !pregenPostsBox.Checked) {
                MessageBox.Show("Please generate some posts first.", "Missing posts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!pregenProfileImgBox.Checked && facesCount == 0) {
                MessageBox.Show("Please generate some profile images first.", "Missing profile images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!generateEmailsCheckbox.Checked && total > nameLists["email"].Count) {
                MessageBox.Show("Your custom email list is too short for the amount of users you have chosen to generate!", "Custom email list too short", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!generateUsernamesCheckbox.Checked && total > nameLists["username"].Count) {
                MessageBox.Show("Your custom username list is too short for the amount of users you have chosen to generate!", "Custom username list too short", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task<Identity> task;
            Identity temp;
            Invoke(new Action(() => {
                generateBar.Value = 0;
                generateBar.Maximum = total;
            }));
            for (int i = 0; i < total; i++) {
                task = GenerateIdentity();
                temp = await task;
                Invoke(new Action(() => {
                    generatedUsers.Add(temp);
                    if (!pregenPostsBox.Checked && !pregenDescBox.Checked) UpdatePreviewList();
                    generateBar.Value++;
                }));
            }
            UpdatePreviewList();

            Invoke(new Action(() => {
                generateBar.Value = 0;
            }));
        }

        private async void genPostsBtn_Click(object sender, EventArgs e) {
            if (mainBarBusy) {
                MessageBox.Show("Program busy, please wait until the current task is finished before starting a new one.", "Program busy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tokenBox.Text.Length < 51) {
                MessageBox.Show("Please enter your openAI token first.","Missing openAI token",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (redditUsernameBox.Text.Length == 0 || redditPasswordBox.Text.Length == 0 || redditIDBox.Text.Length == 0 || redditSecretBox.Text.Length == 0) {
                MessageBox.Show("Please enter your reddit API access data first.", "Missing reddit API data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Generate posts
            Invoke(new Action(() => {
                mainBarBusy = true;
                mainTaskLabel.Text = "Generating user posts...";
            }));
            var newPosts = await GeneratePosts((int)genPostsNumeric.Value,mainProgBar);
            Invoke(new Action(() => {
                lastRedditPostName = newPosts.lastPromptName;
                for (int i = 0; i < newPosts.posts.Count; i++) {
                    generatedPosts.Add(newPosts.posts[i]);
                }
            }));

            Invoke(new Action(() => {
                mainProgBar.Value = 0;
                mainBarBusy = false;
                mainTaskLabel.Text = "Done!";
            }));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveList(generatedPosts,"genPosts.json");
            File.WriteAllText("lists\\genParams.txt", lastRedditPostName);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            var temp = LoadListJson("lists\\genPosts.json");
            generatedPosts = temp != null ? temp : generatedPosts;
            lastRedditPostName = File.Exists("lists\\genParams.txt") ? File.ReadAllText("lists\\genParams.txt") : "";
        }

        private void pregenPostsBox_CheckedChanged(object sender, EventArgs e) {
            tokenBox.Enabled = !(pregenPostsBox.Checked && pregenDescBox.Checked);
            redditUsernameBox.Enabled = !pregenPostsBox.Checked;
            redditPasswordBox.Enabled = !pregenPostsBox.Checked;
            redditIDBox.Enabled = !pregenPostsBox.Checked;
            redditSecretBox.Enabled = !pregenPostsBox.Checked;
            genPostsBtn.Enabled = !pregenPostsBox.Checked;
        }

        private void pregenDescBox_CheckedChanged(object sender, EventArgs e) {
            tokenBox.Enabled = !(pregenPostsBox.Checked && pregenDescBox.Checked);
            redditUsernameBox.Enabled = !pregenPostsBox.Checked;
            redditPasswordBox.Enabled = !pregenPostsBox.Checked;
            redditIDBox.Enabled = !pregenPostsBox.Checked;
            redditSecretBox.Enabled = !pregenPostsBox.Checked;
            genPostsBtn.Enabled = !pregenPostsBox.Checked;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void exportToJsonToolStripMenuItem_Click(object sender, EventArgs e) {
            if (generatedUsers.Count <= 0) {
                MessageBox.Show("Please generate some users first.", "No generated users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(generatedUsers, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private void registerToSocialmediasiteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (generatedUsers.Count <= 0) {
                MessageBox.Show("Please generate some users first.", "No generated users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var registerForm = new RegisterUsersForm(generatedUsers,defaultDataDir);
            registerForm.ShowDialog();
        }

        private void importFromJsonToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialogJson.ShowDialog() == DialogResult.OK) {
                List<Identity> importUsers = JsonSerializer.Deserialize<List<Identity>>(File.ReadAllText(openFileDialogJson.FileName));

                foreach (var usr in importUsers) {
                    generatedUsers.Add(usr);
                }

                UpdatePreviewList();
            }
        }

        private void pregenProfileImgBox_CheckedChanged(object sender, EventArgs e) {
            generateFacesBtn.Enabled = !pregenProfileImgBox.Checked;
            facesNumeric.Enabled = !pregenProfileImgBox.Checked;
        }

        private void previewListView_MouseDoubleClick(object sender, MouseEventArgs e) {
        #if DEBUG
            string result = "";
            foreach (var user in generatedUsers) {
                result += user.description.Trim().Replace("\n","\\n") + '\n';
            }

            File.WriteAllText("descriptionExport.txt",result);
        #endif
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e) {
            GenerateSampleImages(50);
        }

        private void imagesToolStripMenuItem1_Click(object sender, EventArgs e) {
            GenerateSampleImages(100);
        }

        private void imagesToolStripMenuItem2_Click(object sender, EventArgs e) {
            GenerateSampleImages(250);
        }
    }
}
