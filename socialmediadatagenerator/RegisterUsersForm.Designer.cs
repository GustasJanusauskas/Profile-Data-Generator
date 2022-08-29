
namespace socialmediadatagenerator {
    partial class RegisterUsersForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.registerUsersBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sslCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Socialmediasite URL:";
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(15, 25);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(313, 20);
            this.urlBox.TabIndex = 1;
            // 
            // registerUsersBtn
            // 
            this.registerUsersBtn.Location = new System.Drawing.Point(15, 93);
            this.registerUsersBtn.Name = "registerUsersBtn";
            this.registerUsersBtn.Size = new System.Drawing.Size(127, 23);
            this.registerUsersBtn.TabIndex = 2;
            this.registerUsersBtn.Text = "Register X users";
            this.registerUsersBtn.UseVisualStyleBackColor = true;
            this.registerUsersBtn.Click += new System.EventHandler(this.registerUsersBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 77);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(47, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "No task.";
            // 
            // sslCheckbox
            // 
            this.sslCheckbox.AutoSize = true;
            this.sslCheckbox.Checked = true;
            this.sslCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sslCheckbox.Location = new System.Drawing.Point(228, 97);
            this.sslCheckbox.Name = "sslCheckbox";
            this.sslCheckbox.Size = new System.Drawing.Size(100, 17);
            this.sslCheckbox.TabIndex = 5;
            this.sslCheckbox.Text = "Use SSL (https)";
            this.sslCheckbox.UseVisualStyleBackColor = true;
            // 
            // RegisterUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 128);
            this.Controls.Add(this.sslCheckbox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.registerUsersBtn);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterUsersForm";
            this.Text = "Register Users";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Button registerUsersBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.CheckBox sslCheckbox;
    }
}