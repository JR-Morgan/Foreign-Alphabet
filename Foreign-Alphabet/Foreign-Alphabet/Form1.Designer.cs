namespace Foreign_Alphabet
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbCharacterDisplay = new System.Windows.Forms.RichTextBox();
            this.gboAlphabet = new System.Windows.Forms.GroupBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gboConfig = new System.Windows.Forms.GroupBox();
            this.trvAlphabetGroups = new System.Windows.Forms.TreeView();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.ofdAlphabetFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.btnAnalytics = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gboAlphabet.SuspendLayout();
            this.gboConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // rtbCharacterDisplay
            // 
            this.rtbCharacterDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCharacterDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCharacterDisplay.Location = new System.Drawing.Point(6, 19);
            this.rtbCharacterDisplay.Name = "rtbCharacterDisplay";
            this.rtbCharacterDisplay.ReadOnly = true;
            this.rtbCharacterDisplay.Size = new System.Drawing.Size(357, 184);
            this.rtbCharacterDisplay.TabIndex = 1;
            this.rtbCharacterDisplay.Text = "t";
            // 
            // gboAlphabet
            // 
            this.gboAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboAlphabet.Controls.Add(this.btnListen);
            this.gboAlphabet.Controls.Add(this.btnHint);
            this.gboAlphabet.Controls.Add(this.btnNext);
            this.gboAlphabet.Controls.Add(this.lblDescription);
            this.gboAlphabet.Controls.Add(this.rtbCharacterDisplay);
            this.gboAlphabet.Location = new System.Drawing.Point(12, 27);
            this.gboAlphabet.Name = "gboAlphabet";
            this.gboAlphabet.Size = new System.Drawing.Size(369, 465);
            this.gboAlphabet.TabIndex = 2;
            this.gboAlphabet.TabStop = false;
            // 
            // btnListen
            // 
            this.btnListen.Enabled = false;
            this.btnListen.Location = new System.Drawing.Point(6, 238);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(90, 23);
            this.btnListen.TabIndex = 5;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            // 
            // btnHint
            // 
            this.btnHint.Enabled = false;
            this.btnHint.Location = new System.Drawing.Point(6, 209);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(90, 23);
            this.btnHint.TabIndex = 4;
            this.btnHint.Text = "Hint";
            this.btnHint.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(6, 436);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(357, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(102, 214);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(10, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = " ";
            // 
            // gboConfig
            // 
            this.gboConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboConfig.Controls.Add(this.trvAlphabetGroups);
            this.gboConfig.Controls.Add(this.btnLoadFile);
            this.gboConfig.Controls.Add(this.txtFile);
            this.gboConfig.Location = new System.Drawing.Point(387, 27);
            this.gboConfig.Name = "gboConfig";
            this.gboConfig.Size = new System.Drawing.Size(253, 430);
            this.gboConfig.TabIndex = 3;
            this.gboConfig.TabStop = false;
            this.gboConfig.Text = "Configuration";
            // 
            // trvAlphabetGroups
            // 
            this.trvAlphabetGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvAlphabetGroups.CheckBoxes = true;
            this.trvAlphabetGroups.Location = new System.Drawing.Point(6, 48);
            this.trvAlphabetGroups.Name = "trvAlphabetGroups";
            this.trvAlphabetGroups.Size = new System.Drawing.Size(241, 376);
            this.trvAlphabetGroups.TabIndex = 0;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(172, 19);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Load...";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(6, 21);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(160, 20);
            this.txtFile.TabIndex = 0;
            // 
            // ofdAlphabetFileDialogue
            // 
            this.ofdAlphabetFileDialogue.DefaultExt = "xml";
            this.ofdAlphabetFileDialogue.Title = "Open Alphabet File";
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.Enabled = false;
            this.btnAnalytics.Location = new System.Drawing.Point(520, 463);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Size = new System.Drawing.Size(120, 23);
            this.btnAnalytics.TabIndex = 6;
            this.btnAnalytics.Text = "Averages";
            this.btnAnalytics.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(387, 463);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 504);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAnalytics);
            this.Controls.Add(this.gboConfig);
            this.Controls.Add(this.gboAlphabet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gboAlphabet.ResumeLayout(false);
            this.gboAlphabet.PerformLayout();
            this.gboConfig.ResumeLayout(false);
            this.gboConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtbCharacterDisplay;
        private System.Windows.Forms.GroupBox gboAlphabet;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox gboConfig;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog ofdAlphabetFileDialogue;
        private System.Windows.Forms.TreeView trvAlphabetGroups;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAnalytics;
        private System.Windows.Forms.Button button3;
    }
}

