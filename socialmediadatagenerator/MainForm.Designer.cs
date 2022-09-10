
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
            this.pregenProfileImgBox = new System.Windows.Forms.CheckBox();
            this.pregenPostsBox = new System.Windows.Forms.CheckBox();
            this.pregenDescBox = new System.Windows.Forms.CheckBox();
            this.generateBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.generateNumeric = new System.Windows.Forms.NumericUpDown();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.tokenGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.genPostsNumeric = new System.Windows.Forms.NumericUpDown();
            this.genPostsBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.redditSecretBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.redditIDBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.redditPasswordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.redditUsernameBox = new System.Windows.Forms.TextBox();
            this.mainProgBar = new System.Windows.Forms.ProgressBar();
            this.mainTaskLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToSocialmediasiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogJson = new System.Windows.Forms.OpenFileDialog();
            this.generationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSampleImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).BeginInit();
            this.faceGroup.SuspendLayout();
            this.nameBox.SuspendLayout();
            this.previewBox.SuspendLayout();
            this.generationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateNumeric)).BeginInit();
            this.tokenGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genPostsNumeric)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.faceGroup.Location = new System.Drawing.Point(12, 37);
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
            this.nameBox.Location = new System.Drawing.Point(206, 186);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(206, 232);
            this.nameBox.TabIndex = 4;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Names";
            // 
            // customNamelistsCheckbox
            // 
            this.customNamelistsCheckbox.AutoSize = true;
            this.customNamelistsCheckbox.Location = new System.Drawing.Point(6, 210);
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
            this.previewBox.Location = new System.Drawing.Point(418, 37);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(318, 381);
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
            this.previewListView.Size = new System.Drawing.Size(306, 355);
            this.previewListView.TabIndex = 12;
            this.previewListView.UseCompatibleStateImageBehavior = false;
            this.previewListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.previewListView_MouseDoubleClick);
            // 
            // generationGroup
            // 
            this.generationGroup.Controls.Add(this.pregenProfileImgBox);
            this.generationGroup.Controls.Add(this.pregenPostsBox);
            this.generationGroup.Controls.Add(this.pregenDescBox);
            this.generationGroup.Controls.Add(this.generateBar);
            this.generationGroup.Controls.Add(this.groupBox1);
            this.generationGroup.Controls.Add(this.generateBtn);
            this.generationGroup.Controls.Add(this.generateNumeric);
            this.generationGroup.Location = new System.Drawing.Point(206, 37);
            this.generationGroup.Name = "generationGroup";
            this.generationGroup.Size = new System.Drawing.Size(206, 143);
            this.generationGroup.TabIndex = 4;
            this.generationGroup.TabStop = false;
            this.generationGroup.Text = "Identities";
            // 
            // pregenProfileImgBox
            // 
            this.pregenProfileImgBox.AutoSize = true;
            this.pregenProfileImgBox.Location = new System.Drawing.Point(7, 77);
            this.pregenProfileImgBox.Name = "pregenProfileImgBox";
            this.pregenProfileImgBox.Size = new System.Drawing.Size(181, 17);
            this.pregenProfileImgBox.TabIndex = 16;
            this.pregenProfileImgBox.Text = "Use pre-generated profile images";
            this.pregenProfileImgBox.UseVisualStyleBackColor = true;
            this.pregenProfileImgBox.CheckedChanged += new System.EventHandler(this.pregenProfileImgBox_CheckedChanged);
            // 
            // pregenPostsBox
            // 
            this.pregenPostsBox.AutoSize = true;
            this.pregenPostsBox.Location = new System.Drawing.Point(6, 100);
            this.pregenPostsBox.Name = "pregenPostsBox";
            this.pregenPostsBox.Size = new System.Drawing.Size(142, 17);
            this.pregenPostsBox.TabIndex = 13;
            this.pregenPostsBox.Text = "Use pre-generated posts";
            this.pregenPostsBox.UseVisualStyleBackColor = true;
            this.pregenPostsBox.CheckedChanged += new System.EventHandler(this.pregenPostsBox_CheckedChanged);
            // 
            // pregenDescBox
            // 
            this.pregenDescBox.AutoSize = true;
            this.pregenDescBox.Location = new System.Drawing.Point(6, 122);
            this.pregenDescBox.Name = "pregenDescBox";
            this.pregenDescBox.Size = new System.Drawing.Size(173, 17);
            this.pregenDescBox.TabIndex = 15;
            this.pregenDescBox.Text = "Use pre-generated descriptions";
            this.pregenDescBox.UseVisualStyleBackColor = true;
            this.pregenDescBox.CheckedChanged += new System.EventHandler(this.pregenDescBox_CheckedChanged);
            // 
            // generateBar
            // 
            this.generateBar.Location = new System.Drawing.Point(6, 48);
            this.generateBar.Name = "generateBar";
            this.generateBar.Size = new System.Drawing.Size(194, 23);
            this.generateBar.TabIndex = 3;
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
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(6, 19);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(123, 23);
            this.generateBtn.TabIndex = 0;
            this.generateBtn.Text = "Create users";
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
            this.tokenBox.Size = new System.Drawing.Size(175, 20);
            this.tokenBox.TabIndex = 6;
            // 
            // tokenGroup
            // 
            this.tokenGroup.Controls.Add(this.tokenBox);
            this.tokenGroup.Location = new System.Drawing.Point(12, 372);
            this.tokenGroup.Name = "tokenGroup";
            this.tokenGroup.Size = new System.Drawing.Size(188, 46);
            this.tokenGroup.TabIndex = 14;
            this.tokenGroup.TabStop = false;
            this.tokenGroup.Text = "OpenAI token";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.genPostsNumeric);
            this.groupBox2.Controls.Add(this.genPostsBtn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.redditSecretBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.redditIDBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.redditPasswordBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.redditUsernameBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 241);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posts / Reddit data";
            // 
            // genPostsNumeric
            // 
            this.genPostsNumeric.Location = new System.Drawing.Point(116, 215);
            this.genPostsNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.genPostsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.genPostsNumeric.Name = "genPostsNumeric";
            this.genPostsNumeric.Size = new System.Drawing.Size(65, 20);
            this.genPostsNumeric.TabIndex = 14;
            this.genPostsNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // genPostsBtn
            // 
            this.genPostsBtn.Location = new System.Drawing.Point(6, 212);
            this.genPostsBtn.Name = "genPostsBtn";
            this.genPostsBtn.Size = new System.Drawing.Size(104, 23);
            this.genPostsBtn.TabIndex = 14;
            this.genPostsBtn.Text = "Generate posts";
            this.genPostsBtn.UseVisualStyleBackColor = true;
            this.genPostsBtn.Click += new System.EventHandler(this.genPostsBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Client Secret:";
            // 
            // redditSecretBox
            // 
            this.redditSecretBox.Location = new System.Drawing.Point(6, 152);
            this.redditSecretBox.Name = "redditSecretBox";
            this.redditSecretBox.Size = new System.Drawing.Size(175, 20);
            this.redditSecretBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Client ID:";
            // 
            // redditIDBox
            // 
            this.redditIDBox.Location = new System.Drawing.Point(6, 113);
            this.redditIDBox.Name = "redditIDBox";
            this.redditIDBox.Size = new System.Drawing.Size(175, 20);
            this.redditIDBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // redditPasswordBox
            // 
            this.redditPasswordBox.Location = new System.Drawing.Point(6, 73);
            this.redditPasswordBox.Name = "redditPasswordBox";
            this.redditPasswordBox.Size = new System.Drawing.Size(175, 20);
            this.redditPasswordBox.TabIndex = 8;
            this.redditPasswordBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username:";
            // 
            // redditUsernameBox
            // 
            this.redditUsernameBox.Location = new System.Drawing.Point(6, 32);
            this.redditUsernameBox.Name = "redditUsernameBox";
            this.redditUsernameBox.Size = new System.Drawing.Size(175, 20);
            this.redditUsernameBox.TabIndex = 6;
            // 
            // mainProgBar
            // 
            this.mainProgBar.Location = new System.Drawing.Point(12, 436);
            this.mainProgBar.Name = "mainProgBar";
            this.mainProgBar.Size = new System.Drawing.Size(724, 23);
            this.mainProgBar.TabIndex = 16;
            // 
            // mainTaskLabel
            // 
            this.mainTaskLabel.AutoSize = true;
            this.mainTaskLabel.Location = new System.Drawing.Point(12, 421);
            this.mainTaskLabel.Name = "mainTaskLabel";
            this.mainTaskLabel.Size = new System.Drawing.Size(44, 13);
            this.mainTaskLabel.TabIndex = 14;
            this.mainTaskLabel.Text = "No task";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromJsonToolStripMenuItem,
            this.exportToJsonToolStripMenuItem,
            this.registerToSocialmediasiteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importFromJsonToolStripMenuItem
            // 
            this.importFromJsonToolStripMenuItem.Name = "importFromJsonToolStripMenuItem";
            this.importFromJsonToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.importFromJsonToolStripMenuItem.Text = "Import from Json..";
            this.importFromJsonToolStripMenuItem.Click += new System.EventHandler(this.importFromJsonToolStripMenuItem_Click);
            // 
            // exportToJsonToolStripMenuItem
            // 
            this.exportToJsonToolStripMenuItem.Name = "exportToJsonToolStripMenuItem";
            this.exportToJsonToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exportToJsonToolStripMenuItem.Text = "Export to Json..";
            this.exportToJsonToolStripMenuItem.Click += new System.EventHandler(this.exportToJsonToolStripMenuItem_Click);
            // 
            // registerToSocialmediasiteToolStripMenuItem
            // 
            this.registerToSocialmediasiteToolStripMenuItem.Name = "registerToSocialmediasiteToolStripMenuItem";
            this.registerToSocialmediasiteToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.registerToSocialmediasiteToolStripMenuItem.Text = "Register to socialmediasite..";
            this.registerToSocialmediasiteToolStripMenuItem.Click += new System.EventHandler(this.registerToSocialmediasiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.aboutToolStripMenuItem.Text = "About..";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // generationToolStripMenuItem
            // 
            this.generationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateSampleImagesToolStripMenuItem});
            this.generationToolStripMenuItem.Name = "generationToolStripMenuItem";
            this.generationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.generationToolStripMenuItem.Text = "Generation";
            // 
            // generateSampleImagesToolStripMenuItem
            // 
            this.generateSampleImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.imagesToolStripMenuItem1,
            this.imagesToolStripMenuItem2});
            this.generateSampleImagesToolStripMenuItem.Name = "generateSampleImagesToolStripMenuItem";
            this.generateSampleImagesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.generateSampleImagesToolStripMenuItem.Text = "Generate sample images..";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imagesToolStripMenuItem.Text = "50 images";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.imagesToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem1
            // 
            this.imagesToolStripMenuItem1.Name = "imagesToolStripMenuItem1";
            this.imagesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.imagesToolStripMenuItem1.Text = "100 images";
            this.imagesToolStripMenuItem1.Click += new System.EventHandler(this.imagesToolStripMenuItem1_Click);
            // 
            // imagesToolStripMenuItem2
            // 
            this.imagesToolStripMenuItem2.Name = "imagesToolStripMenuItem2";
            this.imagesToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.imagesToolStripMenuItem2.Text = "250 images";
            this.imagesToolStripMenuItem2.Click += new System.EventHandler(this.imagesToolStripMenuItem2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 472);
            this.Controls.Add(this.mainTaskLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.mainProgBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tokenGroup);
            this.Controls.Add(this.generationGroup);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.faceGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Social Media Site Data Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).EndInit();
            this.faceGroup.ResumeLayout(false);
            this.nameBox.ResumeLayout(false);
            this.nameBox.PerformLayout();
            this.previewBox.ResumeLayout(false);
            this.generationGroup.ResumeLayout(false);
            this.generationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateNumeric)).EndInit();
            this.tokenGroup.ResumeLayout(false);
            this.tokenGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genPostsNumeric)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox redditPasswordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox redditUsernameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox redditSecretBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox redditIDBox;
        private System.Windows.Forms.ProgressBar mainProgBar;
        private System.Windows.Forms.Label mainTaskLabel;
        private System.Windows.Forms.Button genPostsBtn;
        private System.Windows.Forms.NumericUpDown genPostsNumeric;
        private System.Windows.Forms.CheckBox pregenPostsBox;
        private System.Windows.Forms.CheckBox pregenDescBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToSocialmediasiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem importFromJsonToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogJson;
        private System.Windows.Forms.CheckBox pregenProfileImgBox;
        private System.Windows.Forms.ToolStripMenuItem generationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSampleImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem2;
    }
}

