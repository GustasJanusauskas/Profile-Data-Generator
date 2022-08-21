
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
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).BeginInit();
            this.faceGroup.SuspendLayout();
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
            this.nameBox.Location = new System.Drawing.Point(12, 100);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(188, 224);
            this.nameBox.TabIndex = 4;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Names";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 336);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.faceGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Social Media Site Data Generator";
            ((System.ComponentModel.ISupportInitialize)(this.facesNumeric)).EndInit();
            this.faceGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button generateFacesBtn;
        private System.Windows.Forms.ProgressBar facesBar;
        private System.Windows.Forms.NumericUpDown facesNumeric;
        private System.Windows.Forms.GroupBox faceGroup;
        private System.Windows.Forms.GroupBox nameBox;
    }
}

