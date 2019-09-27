﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using Foreign_Alphabet;
using System.Drawing;

namespace WinForm
{
    public partial class Form1 : Form
    {
        //The method of selecting characters
        private SelectionMethod selectionMethod = SelectionMethod.Random;
        //The IDs of the character groups that are selected
        private List<CharacterGroup> SelectedGroups { get; set; }
        //The reading/meaning to be displayed
        private string displayMode;
        //The reading/meaning to be typed
        private string typeMode;
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

                foreach (SelectionMethod mode in (SelectionMethod[]) Enum.GetValues(typeof(SelectionMethod)))
                {
                    cboSelectionMethod.Items.Add(mode);
                }

                cboTypeMode.DataSource = new BindingSource(alphabetManager.Alphabet.TypeOptions, null);
                cboTypeMode.ValueMember = "Key";
                cboTypeMode.DisplayMember = "Value";

                cboDisplayMode.DataSource = new BindingSource(alphabetManager.Alphabet.DisplayOptions, null);
                cboDisplayMode.ValueMember = "Key";
                cboDisplayMode.DisplayMember = "Value";

                lblInstructions.Text = "Select alphabet group";

                cboSelectionMethod.SelectedItem = selectionMethod;

                cboDisplayMode.SelectedIndex = cboDisplayMode.FindStringExact(
                    alphabetManager.Alphabet.DisplayOptions[alphabetManager.Alphabet.DefaultDisplay]
                    );
                cboTypeMode.SelectedIndex = cboTypeMode.FindStringExact(
                    alphabetManager.Alphabet.TypeOptions[alphabetManager.Alphabet.DefaultType]
                    );


                //analyticsForm = new FrmAverages();
                //btnAnalytics.Enabled = true;
            }
        }
        

        private List<TreeNode> GetTreeNodes(IEnumerable<CharacterGroup> rootGroups)
        {
            List<TreeNode> rootNodes = new List<TreeNode>();
            foreach(CharacterGroup rootGroup in rootGroups)
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

            foreach(TreeNode rootNode in trvAlphabetGroups.Nodes)
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
            } else
            {
                foreach(TreeNode c in rootNode.Nodes)
                {
                    AddSelectedNodes(c);
                }
            }
            
        }

        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
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
            Character c = alphabetManager.NewCharacter(selectionMethod, SelectedGroups);
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

            List<string> formattedCharacterReadings = new List<String>();
            foreach (KeyValuePair<string, List<string>> kv in c.Readings)
            {
                formattedCharacterReadings.Add(kv.Key + ":\t " + String.Join(",", kv.Value));
            }

            chkReading.Enabled = formattedCharacterReadings.Count != 0;
            lboReading.Visible = formattedCharacterReadings.Count != 0 && lboReading.Visible;

            lboReading.Items.Clear();
            lboReading.Items.AddRange(formattedCharacterReadings.ToArray());

            


        }

        private void TxtCharacterInput_TextChanged(object sender, EventArgs e)
        {
            bool correct = false;
            if (alphabetManager.CurrentCharacter.Readings.ContainsKey(typeMode))
            {
                foreach (string s in alphabetManager.CurrentCharacter.Readings[typeMode])
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
            lboReading.Visible = chkReading.Checked;
        }
        private void ChkReading_CheckedChanged(object sender, EventArgs e)
        {
            lboMeaning.Visible = chkMeaning.Checked;
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
            selectionMethod = (SelectionMethod) cboSelectionMethod.SelectedItem;
        }

        
        private void DisplayCharacter(Character character)
        {
            if (character.Readings.ContainsKey(displayMode)) {
                rtbCharacterDisplay.Text = string.Join(",", character.Readings[displayMode]);
                rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            } else
            {
                throw new CharacterMetaModeException(character, displayMode, "displayMode");
            }
        }

        private void CboTypeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeMode = ((KeyValuePair<string,string>) cboTypeMode.SelectedItem).Key;
            if(alphabetManager.CurrentCharacter != null)
            {
                CheckTypeValid(alphabetManager.CurrentCharacter);
            }
            
        }
        private void CboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            displayMode = ((KeyValuePair<string, string>) cboDisplayMode.SelectedItem).Key;
            if (SelectedGroups.Count > 0)
                NextCharacter();
        }

        private void CheckTypeValid(Character c)
        {
            bool valid = c.Readings.ContainsKey(typeMode);

            txtCharacterInput.Text = !valid ? $"Character does have a {typeMode} reading " : "";
            txtCharacterInput.BackColor = valid ? txtDefaultColor : txtWarningColor;

            txtCharacterInput.Enabled = valid && SelectedGroups.Count > 0;
        }

    }
}