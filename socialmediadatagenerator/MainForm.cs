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
        int facesCount = 0;
        List<Identity> generatedUsers = new List<Identity>();

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            if (!Directory.Exists("profile_images")) return;

            facesCount = Directory.GetFiles("profile_images\\").Length;
            
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

            generatedUsers.Add(new Identity("user1", "first1", "last2"));
            generatedUsers.Add(new Identity("user2", "first1", "last2"));
            UpdatePreviewList();
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

        private void generateFacesBtn_Click(object sender, EventArgs e) {
            int times = (int)facesNumeric.Value;
            facesBar.Value = 0;
            facesBar.Maximum = times;

            generateFacesBtn.Enabled = false;
            var t = Task.Run(async delegate
            {
                for (int x = 0; x < times; x++)
                {
                    RequestsAPI.GetProfilePicture((x).ToString());
                    Invoke(new Action( () => {
                        facesBar.Value++;
                    }));
                    await Task.Delay(1250);
                }
                facesCount = times > facesCount ? times : facesCount;
                generateFacesBtn.Enabled = true;
            });
        }

        private void previewListBox_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
