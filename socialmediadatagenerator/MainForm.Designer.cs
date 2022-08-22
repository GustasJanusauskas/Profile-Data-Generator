
namespace socialmediadatagenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.generateFacesBtn = new System.Windows.Forms.Button();
            this.facesBar = new System.Windows.Forms.ProgressBar();
            this.facesNumeric = new System.Windows.Forms.NumericUpDown();
            this.faceGroup = new System.Windows.Forms.GroupBox();
            this.nameBox = new System.Windows.Forms.GroupBox();
            this.customNamelistsCheckbox = new System.Windows.Forms.CheckBox();
            this.nameListFemaleBtn = new System.Windows.Forms.Button();
            this.generateUsernamesCheckbox = new System.Windows.Forms.CheckBox();
            this.UsernameListBtn = new System.Windows.Forms.Button();
            this.emailListBtn = new System.Windows.Forms.Button();
            this.lastNameListBtn = new System.Windows.Forms.Button();
            this.nameListBtn = new System.Windows.Forms.Button();
            this.generateEmailsCheckbox = new System.Windows.Forms.CheckBox();
            this.previewBox = new System.Windows.Forms.GroupBox();
            this.previewListView = new System.Windows.Forms.ListView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.generationGroup = new System.Windows.Forms.GroupBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.generateNumeric = new System.Windows.Forms.NumericUpDown();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tokenGroup = new System.Windows.Forms.GroupBox();
            this.generateBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).BeginInit();
            this.faceGroup.SuspendLayout();
            this.nameBox.SuspendLayout();
            this.previewBox.SuspendLayout();
            this.generationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateNumeric)).BeginInit();
            this.tokenGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateFacesBtn
            // 
            this.generateFacesBtn.Location = new System.Drawing.Point(6, 19);
            this.generateFacesBtn.Name = "generateFacesBtn";
            this.generateFacesBtn.Size = new System.Drawing.Size(104, 23);
            this.generateFacesBtn.TabIndex = 0;
            this.generateFacesBtn.Text = "Generate faces";
            this.generateFacesBtn.UseVisualStyleBackColor = true;
            this.generateFacesBtn.Click += new System.EventHandler(this.generateFacesBtn_Click);
            // 
            // facesBar
            // 
            this.facesBar.Location = new System.Drawing.Point(6, 48);
            this.facesBar.Name = "facesBar";
            this.facesBar.Size = new System.Drawing.Size(175, 23);
            this.facesBar.TabIndex = 1;
            // 
            // facesNumeric
            // 
            this.facesNumeric.Location = new System.Drawing.Point(116, 22);
            this.facesNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.facesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.facesNumeric.Name = "facesNumeric";
            this.facesNumeric.Size = new System.Drawing.Size(65, 20);
            this.facesNumeric.TabIndex = 2;
            this.facesNumeric.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // faceGroup
            // 
            this.faceGroup.Controls.Add(this.generateFacesBtn);
            this.faceGroup.Controls.Add(this.facesNumeric);
            this.faceGroup.Controls.Add(this.facesBar);
            this.faceGroup.Location = new System.Drawing.Point(12, 12);
            this.faceGroup.Name = "faceGroup";
            this.faceGroup.Size = new System.Drawing.Size(188, 82);
            this.faceGroup.TabIndex = 3;
            this.faceGroup.TabStop = false;
            this.faceGroup.Text = "Profile images";
            // 
            // nameBox
            // 
            this.nameBox.Controls.Add(this.customNamelistsCheckbox);
            this.nameBox.Controls.Add(this.nameListFemaleBtn);
            this.nameBox.Controls.Add(this.generateUsernamesCheckbox);
            this.nameBox.Controls.Add(this.UsernameListBtn);
            this.nameBox.Controls.Add(this.emailListBtn);
            this.nameBox.Controls.Add(this.lastNameListBtn);
            this.nameBox.Controls.Add(this.nameListBtn);
            this.nameBox.Controls.Add(this.generateEmailsCheckbox);
            this.nameBox.Location = new System.Drawing.Point(12, 100);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(188, 253);
            this.nameBox.TabIndex = 4;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Names";
            // 
            // customNamelistsCheckbox
            // 
            this.customNamelistsCheckbox.AutoSize = true;
            this.customNamelistsCheckbox.Location = new System.Drawing.Point(7, 230);
            this.customNamelistsCheckbox.Name = "customNamelistsCheckbox";
            this.customNamelistsCheckbox.Size = new System.Drawing.Size(128, 17);
            this.customNamelistsCheckbox.TabIndex = 12;
            this.customNamelistsCheckbox.Text = "Use custom namelists";
            this.customNamelistsCheckbox.UseVisualStyleBackColor = true;
            this.customNamelistsCheckbox.CheckedChanged += new System.EventHandler(this.customNamelistsCheckbox_CheckedChanged);
            // 
            // nameListFemaleBtn
            // 
            this.nameListFemaleBtn.Enabled = false;
            this.nameListFemaleBtn.Location = new System.Drawing.Point(7, 48);
            this.nameListFemaleBtn.Name = "nameListFemaleBtn";
            this.nameListFemaleBtn.Size = new System.Drawing.Size(175, 23);
            this.nameListFemaleBtn.TabIndex = 11;
            this.nameListFemaleBtn.Text = "Select female first name list";
            this.nameListFemaleBtn.UseVisualStyleBackColor = true;
            this.nameListFemaleBtn.Click += new System.EventHandler(this.nameListFemaleBtn_Click);
            // 
            // generateUsernamesCheckbox
            // 
            this.generateUsernamesCheckbox.AutoSize = true;
            this.generateUsernamesCheckbox.Checked = true;
            this.generateUsernamesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateUsernamesCheckbox.Location = new System.Drawing.Point(6, 187);
            this.generateUsernamesCheckbox.Name = "generateUsernamesCheckbox";
            this.generateUsernamesCheckbox.Size = new System.Drawing.Size(124, 17);
            this.generateUsernamesCheckbox.TabIndex = 10;
            this.generateUsernamesCheckbox.Text = "Generate usernames";
            this.generateUsernamesCheckbox.UseVisualStyleBackColor = true;
            this.generateUsernamesCheckbox.CheckedChanged += new System.EventHandler(this.generateUsernamesCheckbox_CheckedChanged);
            // 
            // UsernameListBtn
            // 
            this.UsernameListBtn.Enabled = false;
            this.UsernameListBtn.Location = new System.Drawing.Point(6, 158);
            this.UsernameListBtn.Name = "UsernameListBtn";
            this.UsernameListBtn.Size = new System.Drawing.Size(175, 23);
            this.UsernameListBtn.TabIndex = 9;
            this.UsernameListBtn.Text = "Select username list";
            this.UsernameListBtn.UseVisualStyleBackColor = true;
            this.UsernameListBtn.Click += new System.EventHandler(this.UsernameListBtn_Click);
            // 
            // emailListBtn
            // 
            this.emailListBtn.Enabled = false;
            this.emailListBtn.Location = new System.Drawing.Point(7, 106);
            this.emailListBtn.Name = "emailListBtn";
            this.emailListBtn.Size = new System.Drawing.Size(175, 23);
            this.emailListBtn.TabIndex = 8;
            this.emailListBtn.Text = "Select email list";
            this.emailListBtn.UseVisualStyleBackColor = true;
            this.emailListBtn.Click += new System.EventHandler(this.emailListBtn_Click);
            // 
            // lastNameListBtn
            // 
            this.lastNameListBtn.Enabled = false;
            this.lastNameListBtn.Location = new System.Drawing.Point(7, 77);
            this.lastNameListBtn.Name = "lastNameListBtn";
            this.lastNameListBtn.Size = new System.Drawing.Size(175, 23);
            this.lastNameListBtn.TabIndex = 7;
            this.lastNameListBtn.Text = "Select last name list";
            this.lastNameListBtn.UseVisualStyleBackColor = true;
            this.lastNameListBtn.Click += new System.EventHandler(this.lastNameListBtn_Click);
            // 
            // nameListBtn
            // 
            this.nameListBtn.Enabled = false;
            this.nameListBtn.Location = new System.Drawing.Point(7, 19);
            this.nameListBtn.Name = "nameListBtn";
            this.nameListBtn.Size = new System.Drawing.Size(175, 23);
            this.nameListBtn.TabIndex = 6;
            this.nameListBtn.Text = "Select male first name list";
            this.nameListBtn.UseVisualStyleBackColor = true;
            this.nameListBtn.Click += new System.EventHandler(this.nameListBtn_Click);
            // 
            // generateEmailsCheckbox
            // 
            this.generateEmailsCheckbox.AutoSize = true;
            this.generateEmailsCheckbox.Checked = true;
            this.generateEmailsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.generateEmailsCheckbox.Location = new System.Drawing.Point(7, 135);
            this.generateEmailsCheckbox.Name = "generateEmailsCheckbox";
            this.generateEmailsCheckbox.Size = new System.Drawing.Size(102, 17);
            this.generateEmailsCheckbox.TabIndex = 6;
            this.generateEmailsCheckbox.Text = "Generate emails";
            this.generateEmailsCheckbox.UseVisualStyleBackColor = true;
            this.generateEmailsCheckbox.CheckedChanged += new System.EventHandler(this.generateEmailsCheckbox_CheckedChanged);
            // 
            // previewBox
            // 
            this.previewBox.Controls.Add(this.previewListView);
            this.previewBox.Location = new System.Drawing.Point(418, 12);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(318, 341);
            this.previewBox.TabIndex = 5;
            this.previewBox.TabStop = false;
            this.previewBox.Text = "Preview";
            // 
            // previewListView
            // 
            this.previewListView.HideSelection = false;
            this.previewListView.Location = new System.Drawing.Point(6, 19);
            this.previewListView.MultiSelect = false;
            this.previewListView.Name = "previewListView";
            this.previewListView.Size = new System.Drawing.Size(306, 316);
            this.previewListView.TabIndex = 12;
            this.previewListView.UseCompatibleStateImageBehavior = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // generationGroup
            // 
            this.generationGroup.Controls.Add(this.generateBar);
            this.generationGroup.Controls.Add(this.groupBox1);
            this.generationGroup.Controls.Add(this.generateBtn);
            this.generationGroup.Controls.Add(this.generateNumeric);
            this.generationGroup.Location = new System.Drawing.Point(206, 12);
            this.generationGroup.Name = "generationGroup";
            this.generationGroup.Size = new System.Drawing.Size(206, 82);
            this.generationGroup.TabIndex = 4;
            this.generationGroup.TabStop = false;
            this.generationGroup.Text = "Generation";
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(6, 19);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(123, 23);
            this.generateBtn.TabIndex = 0;
            this.generateBtn.Text = "Generate users";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // generateNumeric
            // 
            this.generateNumeric.Location = new System.Drawing.Point(135, 22);
            this.generateNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.generateNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generateNumeric.Name = "generateNumeric";
            this.generateNumeric.Size = new System.Drawing.Size(65, 20);
            this.generateNumeric.TabIndex = 2;
            this.generateNumeric.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(6, 19);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.Size = new System.Drawing.Size(194, 20);
            this.tokenBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(135, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 98);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // tokenGroup
            // 
            this.tokenGroup.Controls.Add(this.tokenBox);
            this.tokenGroup.Location = new System.Drawing.Point(206, 307);
            this.tokenGroup.Name = "tokenGroup";
            this.tokenGroup.Size = new System.Drawing.Size(206, 46);
            this.tokenGroup.TabIndex = 14;
            this.tokenGroup.TabStop = false;
            this.tokenGroup.Text = "OpenAI token";
            // 
            // generateBar
            // 
            this.generateBar.Location = new System.Drawing.Point(6, 48);
            this.generateBar.Name = "generateBar";
            this.generateBar.Size = new System.Drawing.Size(194, 23);
            this.generateBar.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 365);
            this.Controls.Add(this.tokenGroup);
            this.Controls.Add(this.generationGroup);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.faceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Social Media Site Data Generator";
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).EndInit();
            this.faceGroup.ResumeLayout(false);
            this.nameBox.ResumeLayout(false);
            this.nameBox.PerformLayout();
            this.previewBox.ResumeLayout(false);
            this.generationGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.generateNumeric)).EndInit();
            this.tokenGroup.ResumeLayout(false);
            this.tokenGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateFacesBtn;
        private System.Windows.Forms.ProgressBar facesBar;
        private System.Windows.Forms.NumericUpDown facesNumeric;
        private System.Windows.Forms.GroupBox faceGroup;
        private System.Windows.Forms.GroupBox nameBox;
        private System.Windows.Forms.GroupBox previewBox;
        private System.Windows.Forms.ListView previewListView;
        private System.Windows.Forms.Button emailListBtn;
        private System.Windows.Forms.Button lastNameListBtn;
        private System.Windows.Forms.Button nameListBtn;
        private System.Windows.Forms.CheckBox generateEmailsCheckbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button UsernameListBtn;
        private System.Windows.Forms.CheckBox generateUsernamesCheckbox;
        private System.Windows.Forms.Button nameListFemaleBtn;
        private System.Windows.Forms.CheckBox customNamelistsCheckbox;
        private System.Windows.Forms.GroupBox generationGroup;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.NumericUpDown generateNumeric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.GroupBox tokenGroup;
        private System.Windows.Forms.ProgressBar generateBar;
    }
}

