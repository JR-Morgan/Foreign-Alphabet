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
            this.lboDescription = new System.Windows.Forms.ListBox();
            this.chkDescription = new System.Windows.Forms.CheckBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.gboConfig = new System.Windows.Forms.GroupBox();
            this.trvAlphabetGroups = new System.Windows.Forms.TreeView();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.ofdAlphabetFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.btnAnalytics = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.gboAlphabet.SuspendLayout();
            this.gboConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // rtbCharacterDisplay
            // 
            this.rtbCharacterDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbCharacterDisplay.Location = new System.Drawing.Point(6, 19);
            this.rtbCharacterDisplay.Name = "rtbCharacterDisplay";
            this.rtbCharacterDisplay.ReadOnly = true;
            this.rtbCharacterDisplay.Size = new System.Drawing.Size(357, 216);
            this.rtbCharacterDisplay.TabIndex = 0;
            this.rtbCharacterDisplay.Text = "";
            // 
            // gboAlphabet
            // 
            this.gboAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gboAlphabet.Controls.Add(this.lboDescription);
            this.gboAlphabet.Controls.Add(this.chkDescription);
            this.gboAlphabet.Controls.Add(this.btnListen);
            this.gboAlphabet.Controls.Add(this.btnNext);
            this.gboAlphabet.Controls.Add(this.rtbCharacterDisplay);
            this.gboAlphabet.Location = new System.Drawing.Point(12, 27);
            this.gboAlphabet.Name = "gboAlphabet";
            this.gboAlphabet.Size = new System.Drawing.Size(369, 497);
            this.gboAlphabet.TabIndex = 0;
            this.gboAlphabet.TabStop = false;
            // 
            // lboDescription
            // 
            this.lboDescription.Enabled = false;
            this.lboDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboDescription.FormattingEnabled = true;
            this.lboDescription.ItemHeight = 24;
            this.lboDescription.Location = new System.Drawing.Point(109, 242);
            this.lboDescription.Name = "lboDescription";
            this.lboDescription.Size = new System.Drawing.Size(254, 196);
            this.lboDescription.TabIndex = 2;
            this.lboDescription.Visible = false;
            // 
            // chkDescription
            // 
            this.chkDescription.AutoSize = true;
            this.chkDescription.Enabled = false;
            this.chkDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescription.Location = new System.Drawing.Point(7, 242);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDescription.Size = new System.Drawing.Size(95, 22);
            this.chkDescription.TabIndex = 1;
            this.chkDescription.Text = "Show Hint";
            this.chkDescription.UseVisualStyleBackColor = true;
            this.chkDescription.CheckedChanged += new System.EventHandler(this.ChkDescription_CheckedChanged);
            // 
            // btnListen
            // 
            this.btnListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListen.Enabled = false;
            this.btnListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.Location = new System.Drawing.Point(6, 406);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(96, 34);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(6, 452);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(357, 39);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // gboConfig
            // 
            this.gboConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboConfig.Controls.Add(this.trvAlphabetGroups);
            this.gboConfig.Controls.Add(this.btnLoadFile);
            this.gboConfig.Controls.Add(this.txtFile);
            this.gboConfig.Location = new System.Drawing.Point(387, 27);
            this.gboConfig.Name = "gboConfig";
            this.gboConfig.Size = new System.Drawing.Size(252, 446);
            this.gboConfig.TabIndex = 1;
            this.gboConfig.TabStop = false;
            this.gboConfig.Text = "Configuration";
            // 
            // trvAlphabetGroups
            // 
            this.trvAlphabetGroups.CheckBoxes = true;
            this.trvAlphabetGroups.Location = new System.Drawing.Point(6, 48);
            this.trvAlphabetGroups.Name = "trvAlphabetGroups";
            this.trvAlphabetGroups.Size = new System.Drawing.Size(240, 392);
            this.trvAlphabetGroups.TabIndex = 2;
            this.trvAlphabetGroups.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvAlphabetGroups_AfterCheck);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Location = new System.Drawing.Point(171, 19);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Load...";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.BtnLoadFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(6, 21);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(159, 20);
            this.txtFile.TabIndex = 0;
            // 
            // ofdAlphabetFileDialogue
            // 
            this.ofdAlphabetFileDialogue.DefaultExt = "xml";
            this.ofdAlphabetFileDialogue.Title = "Open Alphabet File";
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalytics.Enabled = false;
            this.btnAnalytics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalytics.Location = new System.Drawing.Point(519, 479);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Size = new System.Drawing.Size(120, 39);
            this.btnAnalytics.TabIndex = 3;
            this.btnAnalytics.Text = "Averages";
            this.btnAnalytics.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(387, 479);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 39);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 536);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAnalytics);
            this.Controls.Add(this.gboConfig);
            this.Controls.Add(this.gboAlphabet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(667, 472);
            this.Name = "Form1";
            this.Text = "Foreign Alphabet";
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
        private System.Windows.Forms.GroupBox gboConfig;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.OpenFileDialog ofdAlphabetFileDialogue;
        private System.Windows.Forms.TreeView trvAlphabetGroups;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAnalytics;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chkDescription;
        private System.Windows.Forms.ListBox lboDescription;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}

