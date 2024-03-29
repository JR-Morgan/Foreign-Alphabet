﻿using Foreign_Alphabet;
using Foreign_Alphabet.Characters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        //The method of selecting characters
        private SelectionMethod selectionMethod = SelectionMethod.Random;
        //The IDs of the character groups that are selected
        private List<CharacterGroup> SelectedGroups { get; set; }
        //The reading/meaning to be displayed
        private CharacterMetaData displayMode;
        //The reading/meaning to be typed
        private CharacterMetaData inputMode;
        //The default color of the text box
        private Color txtDefaultColor;
        //The errored color of the text box
        private Color txtWarningColor;

        private AlphabetManager alphabetManager;
        public Form1()
        {
            InitializeComponent();
            this.SelectedGroups = new List<CharacterGroup>();
            txtDefaultColor = Color.FromName("Window");
            txtWarningColor = Color.FromName("NavajoWhite");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            rtbCharacterDisplay.Font = fontDialog.Font;
            cboSelectionMethod.SelectedItem = selectionMethod;
            lblInstructions.Text = "Load an alphabet";
            txtFile.Text = "";
        }
        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile(ofdAlphabetFileDialogue);
        }

        private void LoadFile(OpenFileDialog odf)
        {
            if (odf.ShowDialog() == DialogResult.OK)
            {
                string filePath = odf.FileName;
                AlphabetParser alphabetParser = new AlphabetParser();
                alphabetManager = new AlphabetManager(alphabetParser.ParseFile(filePath));
                txtFile.Text = Path.GetFileNameWithoutExtension(filePath);

                trvAlphabetGroups.Nodes.Clear();
                trvAlphabetGroups.Nodes.AddRange(GetTreeNodes(this.alphabetManager.Alphabet.RootGroups).ToArray());

                cboSelectionMethod.Items.Clear();
                UpdateSelectedCharacters();

                foreach (SelectionMethod mode in (SelectionMethod[])Enum.GetValues(typeof(SelectionMethod)))
                {
                    cboSelectionMethod.Items.Add(mode);
                }

                
                cboTypeMode.ValueMember = "ID";
                cboTypeMode.DisplayMember = "Name";
                cboTypeMode.DataSource = new BindingSource(alphabetManager.Alphabet.InputOptions, null);



                cboDisplayMode.ValueMember = "ID";
                cboDisplayMode.DisplayMember = "Name";
                cboDisplayMode.DataSource = new BindingSource(alphabetManager.Alphabet.DisplayOptions, null);
                

                lblInstructions.Text = "Select alphabet group";

                cboSelectionMethod.SelectedItem = selectionMethod;

                cboDisplayMode.SelectedIndex = cboDisplayMode.FindStringExact(
                    alphabetManager.Alphabet.DefaultDisplay.ID
                    );
                cboTypeMode.SelectedIndex = cboTypeMode.FindStringExact(
                    alphabetManager.Alphabet.DefaultInput.ID
                    );


                //analyticsForm = new FrmAverages();
                //btnAnalytics.Enabled = true;
            }
        }


        private List<TreeNode> GetTreeNodes(IEnumerable<CharacterGroup> rootGroups)
        {
            List<TreeNode> rootNodes = new List<TreeNode>();
            foreach (CharacterGroup rootGroup in rootGroups)
            {
                rootNodes.Add(ProcessTreeNode(rootGroup));
            }
            return rootNodes;
        }

        private TreeNode ProcessTreeNode(CharacterGroup group)
        {
            TreeNode node = new TreeNode()
            {
                Text = group.Name,
                Tag = group
            };
            node.Expand();
            foreach (CharacterGroup g in group.ChildGroups)
            {
                node.Nodes.Add(ProcessTreeNode(g));
            }

            return node;
        }

        private void UpdateSelectedCharacters()
        {
            SelectedGroups.Clear();

            foreach (TreeNode rootNode in trvAlphabetGroups.Nodes)
            {
                AddSelectedNodes(rootNode);
            }


            btnNext.Enabled = SelectedGroups.Count > 0;
            txtCharacterInput.Enabled = SelectedGroups.Count > 0;
            if (SelectedGroups.Count > 0)
            {
                lblInstructions.Text = "";
                NextCharacter();
            }
            else
            {
                lblInstructions.Text = "Select alphabet group";
            }
        }

        private void AddSelectedNodes(TreeNode rootNode)
        {
            if (rootNode.Checked)
            {
                SelectedGroups.Add((CharacterGroup)rootNode.Tag);
            }
            else
            {
                foreach (TreeNode c in rootNode.Nodes)
                {
                    AddSelectedNodes(c);
                }
            }

        }

        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
            if (e.Action != TreeViewAction.Unknown)
            {
                //label1.Text = (Int32.Parse(label1.Text) + 1).ToString();
                SetChildrenChecked(e.Node, e.Node.Checked);
                if (!e.Node.Checked)
                {
                    SetParentsChecked(e.Node, false);
                }
                UpdateSelectedCharacters();
            }

        }
        private void SetChildrenChecked(TreeNode parentNode, bool check)
        {
            parentNode.Checked = check;
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                SetChildrenChecked(childNode, check);
            }
        }
        private void SetParentsChecked(TreeNode rootNode, bool check)
        {
            rootNode.Checked = check;
            if (rootNode.Parent != null)
            {
                SetParentsChecked(rootNode.Parent, check);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextCharacter();
        }

        private void NextCharacter()
        {

            Character c;
            try
            {
                c = alphabetManager.NewCharacter(selectionMethod, SelectedGroups);
            }
            catch (ArgumentException)
            {
                return;
            }
            
            try
            {
                DisplayCharacter(c);
            }
            catch (CharacterMetaModeException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
                


            CheckTypeValid(c);

            //TODO readings and meanings
            foreach (TabPage existingPage in tabDataDisplayer.TabPages)
            {
                if(existingPage.Name != "tabHideAll")
                {
                    existingPage.Controls.Clear();
                }
            }
            foreach (KeyValuePair<CharacterMetaData, List<string>> kv in c.Data)
            {
                TabPage tabPage;
                string tabDataKey = $"tabData{ kv.Key.GroupID}";
                string listDataKey = $"lstData{ kv.Key.GroupID}";
                if (!tabDataDisplayer.TabPages.ContainsKey(tabDataKey))
                {
                    tabPage = new TabPage()
                    {
                        Name = tabDataKey,
                        Text = kv.Key.GroupName
                    };
                    tabDataDisplayer.TabPages.Add(tabPage);
                }
                else
                {
                    tabPage = tabDataDisplayer.TabPages[tabDataKey];
                }

                if(!tabPage.Controls.ContainsKey(listDataKey))
                {
                    tabPage.Controls.Add(new ListBox()
                    {
                        Name = listDataKey,
                        Dock = DockStyle.Fill,
                        Font = new Font("Meiryo", 14f)
                    });
                }

                ((ListBox)tabPage.Controls[listDataKey]).Items.Add(kv.Key.Name + ":\t " + String.Join(",", kv.Value) + "\n");

            }

            //chkReading.Enabled = formattedCharacterReadings.Count != 0;
            //lboReading.Visible = formattedCharacterReadings.Count != 0 && lboReading.Visible;

            //lboReading.Items.Clear();
            //lboReading.Items.AddRange(formattedCharacterReadings.ToArray());

        }

        private void TxtCharacterInput_TextChanged(object sender, EventArgs e)
        {
            bool correct = false;
            if (alphabetManager.CurrentCharacter.Data.ContainsKey(inputMode))
            {
                foreach (string s in alphabetManager.CurrentCharacter.Data[inputMode])
                {
                    if (txtCharacterInput.Text.ToLower().Trim() == s.ToLower().Trim())
                    {
                        correct = true;
                    }
                }
                if (correct)
                {
                    txtCharacterInput.Text = "";
                    NextCharacter();
                }
            }
        }

        private void ChkDescription_CheckedChanged(object sender, EventArgs e)
        {
            //lboReading.Visible = chkReading.Checked;
        }
        private void ChkReading_CheckedChanged(object sender, EventArgs e)
        {
            //lboMeaning.Visible = chkMeaning.Checked;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                rtbCharacterDisplay.Font = fontDialog.Font;
            }
        }

        private void FontColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codTextColor.ShowDialog() == DialogResult.OK)
            {
                rtbCharacterDisplay.ForeColor = codTextColor.Color;
            }
        }

        private void BackgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codBGColor.ShowDialog() == DialogResult.OK)
            {
                rtbCharacterDisplay.BackColor = codBGColor.Color;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile(ofdAlphabetFileDialogue);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //ResetLoadedAlphabet();
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            //analyticsForm.Show();
        }

        private void CboSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectionMethod = (SelectionMethod)cboSelectionMethod.SelectedItem;
        }


        private void DisplayCharacter(Character character)
        {
            if (character.Data.ContainsKey(displayMode))
            {
                rtbCharacterDisplay.Text = string.Join(",", character.Data[displayMode]);
                rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            }
            else
            {
                throw new CharacterMetaModeException(character, displayMode, "displayMode");
            }
        }

        private void CboTypeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputMode = (CharacterMetaData) cboTypeMode.SelectedItem;
            if (alphabetManager.CurrentCharacter != null)
            {
                CheckTypeValid(alphabetManager.CurrentCharacter);
            }

        }
        private void CboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            displayMode = (CharacterMetaData)cboDisplayMode.SelectedItem;
            if (SelectedGroups.Count > 0)
                NextCharacter();
        }

        private void CheckTypeValid(Character c)
        {
            bool valid = c.Data.ContainsKey(inputMode);

            txtCharacterInput.Text = !valid ? $"Character does have {inputMode.Name} data " : "";
            txtCharacterInput.BackColor = valid ? txtDefaultColor : txtWarningColor;

            txtCharacterInput.Enabled = valid && SelectedGroups.Count > 0;
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //CODE FROM MICROSOFT DOCS

            Graphics g = e.Graphics;
            Brush _textBrush;
            Font _tabFont;

            // Get the item from the collection.
            TabPage _tabPage = tabDataDisplayer.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabDataDisplayer.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(e.BackColor);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
                _tabFont = new Font("Arial", 14.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
                _tabFont = new Font("Arial", 14.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            }
             

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

    }
}
