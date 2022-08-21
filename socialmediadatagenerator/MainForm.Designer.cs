
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
            this.previewBox = new System.Windows.Forms.GroupBox();
            this.previewListView = new System.Windows.Forms.ListView();
            this.useCustomNameListsCheckbox = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.nameListBtn = new System.Windows.Forms.Button();
            this.lastNameListBtn = new System.Windows.Forms.Button();
            this.emailListBtn = new System.Windows.Forms.Button();
            this.UsernameListBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).BeginInit();
            this.faceGroup.SuspendLayout();
            this.nameBox.SuspendLayout();
            this.previewBox.SuspendLayout();
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
            this.nameBox.Controls.Add(this.UsernameListBtn);
            this.nameBox.Controls.Add(this.emailListBtn);
            this.nameBox.Controls.Add(this.lastNameListBtn);
            this.nameBox.Controls.Add(this.nameListBtn);
            this.nameBox.Controls.Add(this.useCustomNameListsCheckbox);
            this.nameBox.Location = new System.Drawing.Point(12, 100);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(144, 162);
            this.nameBox.TabIndex = 4;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Names";
            // 
            // previewBox
            // 
            this.previewBox.Controls.Add(this.previewListView);
            this.previewBox.Location = new System.Drawing.Point(418, 12);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(318, 312);
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
            this.previewListView.Size = new System.Drawing.Size(306, 287);
            this.previewListView.TabIndex = 12;
            this.previewListView.UseCompatibleStateImageBehavior = false;
            // 
            // useCustomNameListsCheckbox
            // 
            this.useCustomNameListsCheckbox.AutoSize = true;
            this.useCustomNameListsCheckbox.Location = new System.Drawing.Point(6, 19);
            this.useCustomNameListsCheckbox.Name = "useCustomNameListsCheckbox";
            this.useCustomNameListsCheckbox.Size = new System.Drawing.Size(131, 17);
            this.useCustomNameListsCheckbox.TabIndex = 6;
            this.useCustomNameListsCheckbox.Text = "Use custom name lists";
            this.useCustomNameListsCheckbox.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // nameListBtn
            // 
            this.nameListBtn.Location = new System.Drawing.Point(6, 42);
            this.nameListBtn.Name = "nameListBtn";
            this.nameListBtn.Size = new System.Drawing.Size(131, 23);
            this.nameListBtn.TabIndex = 6;
            this.nameListBtn.Text = "Select first name list";
            this.nameListBtn.UseVisualStyleBackColor = true;
            // 
            // lastNameListBtn
            // 
            this.lastNameListBtn.Location = new System.Drawing.Point(6, 71);
            this.lastNameListBtn.Name = "lastNameListBtn";
            this.lastNameListBtn.Size = new System.Drawing.Size(131, 23);
            this.lastNameListBtn.TabIndex = 7;
            this.lastNameListBtn.Text = "Select last name list";
            this.lastNameListBtn.UseVisualStyleBackColor = true;
            // 
            // emailListBtn
            // 
            this.emailListBtn.Location = new System.Drawing.Point(6, 100);
            this.emailListBtn.Name = "emailListBtn";
            this.emailListBtn.Size = new System.Drawing.Size(131, 23);
            this.emailListBtn.TabIndex = 8;
            this.emailListBtn.Text = "Select email list";
            this.emailListBtn.UseVisualStyleBackColor = true;
            // 
            // UsernameListBtn
            // 
            this.UsernameListBtn.Location = new System.Drawing.Point(6, 129);
            this.UsernameListBtn.Name = "UsernameListBtn";
            this.UsernameListBtn.Size = new System.Drawing.Size(131, 23);
            this.UsernameListBtn.TabIndex = 9;
            this.UsernameListBtn.Text = "Select username list";
            this.UsernameListBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 336);
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
        private System.Windows.Forms.CheckBox useCustomNameListsCheckbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button UsernameListBtn;
    }
}

