using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socialmediadatagenerator
{
    public partial class MainForm : Form
    {
        List<Identity> generatedUsers = new List<Identity>();

        public MainForm()
        {
            InitializeComponent();
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
                    RequestsAPI.GetProfilePicture((x + 1).ToString());
                    Invoke(new Action( () => {
                        facesBar.Value++;
                    }));
                    await Task.Delay(1250);
                }
                generateFacesBtn.Enabled = true;
            });
        }
    }
}
