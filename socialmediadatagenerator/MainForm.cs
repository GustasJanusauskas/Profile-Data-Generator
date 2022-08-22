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

        Random random = new Random();
        int facesCount = 0;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            if (!Directory.Exists("profile_images")) return;

            //Count already generated faces so we can use them later
            facesCount = Directory.GetFiles("profile_images\\").Length;

            string defaultDataDir = Path.GetFullPath(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\defaultdata");
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

            //Read default namelists
            foreach (var file in Directory.GetFiles(defaultDataDir)) {
                ReadNameList(File.ReadAllText(file), Path.GetFileName(file).Replace(".txt", ""));
            }
            UpdatePreviewList();
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
            //Get ML description
            var descTask = RequestsAPI.GetOpenAIResponse(descriptionPrompts[random.Next(0,descriptionPrompts.Length)],tokenBox.Text);
            result.description = await descTask;

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
            int total = (int)generateNumeric.Value;
            generateBar.Value = 0;
            generateBar.Maximum = total;

            Task<Identity> task;
            Identity temp;
            for (int i = 0; i < total; i++) {
                task = GenerateIdentity();
                temp = await task;
                Invoke(new Action(() => {
                    generatedUsers.Add(temp);
                    UpdatePreviewList();
                    generateBar.Value++;
                }));
            }
        }
    }
}
