using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace Foreign_Alphabet
{
    public partial class Form1 : Form
    {
        //The method of selecting characters
        private SelectionMode selectionMethod = SelectionMode.Random;
        //The IDs of the character groups that are selected
        private List<CharacterGroup> SelectedGroups { get; set; }
        //The reading/meaning to be displayed
        private string displayMode;
        //The reading/meaning to be typed
        private string typeMode;

        private AlphabetManager alphabetManager;
        public Form1()
        {
            InitializeComponent();
            this.SelectedGroups = new List<CharacterGroup>();
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
                foreach (SelectionMode mode in (SelectionMode[]) Enum.GetValues(typeof(SelectionMode)))
                {
                    cboSelectionMethod.Items.Add(mode);
                }


                //cboTypeMode.Items.Clear();
                cboTypeMode.DataSource = new BindingSource(alphabetManager.Alphabet.TypeOptions, null);
                cboTypeMode.ValueMember = "Key";
                cboTypeMode.DisplayMember = "Value";

                //cboDisplayMode.Items.Clear();
                cboDisplayMode.DataSource = new BindingSource(alphabetManager.Alphabet.DisplayOptions, null);
                cboDisplayMode.ValueMember = "Key";
                cboDisplayMode.DisplayMember = "Value";

                lblInstructions.Text = "Select alphabet group";

                cboSelectionMethod.SelectedItem = selectionMethod;
                //FIXME - latin is default all
                object d = cboDisplayMode.SelectedItem;




                //string find = alphabetManager.Alphabet.DisplayOptions[alphabetManager.Alphabet.DefaultDisplay];
                //int index = cboDisplayMode.FindStringExact(find);
                //cboDisplayMode.SelectedIndex = index;

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
        private void ResetAlphabet()
        {
            cboTypeMode.Items.Clear();
            cboDisplayMode.Items.Clear();
            cboSelectionMethod.SelectedItem = selectionMethod;
            UpdateSelectedCharacters();
        }
        private void UpdateSelectedCharacters()
        {
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



        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetChildrenChecked(e.Node, e.Node.Checked);
                if (e.Node.Checked)
                {
                    SelectedGroups.Add((CharacterGroup) e.Node.Tag);
                    
                } else
                {
                    SetParentsChecked(e.Node, false);
                    if(SelectedGroups.Contains((CharacterGroup)e.Node.Tag))
                    {
                        SelectedGroups.Remove((CharacterGroup)e.Node.Tag);
                    }
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
        private void SetParentsChecked(TreeNode RootNode, bool check)
        {
            RootNode.Checked = check;

            if (RootNode.Parent != null)
            {
                SetParentsChecked(RootNode.Parent, check);
            }

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextCharacter();
        }

        private void NextCharacter()
        {
            Character c = alphabetManager.NewCharacter((SelectionMode)cboSelectionMethod.SelectedItem, SelectedGroups);
            DisplayCharacter(c);

            List<string> characterReadings = new List<String>();
            foreach (KeyValuePair<string, List<string>> kv in c.Readings)
            {
                characterReadings.Add(kv.Key + ":\t " + String.Join(",", kv.Value));
            }

            chkReading.Enabled = characterReadings.Count != 0;
            lboReading.Visible = characterReadings.Count != 0 && lboReading.Visible;

            lboReading.Items.Clear();
            lboReading.Items.AddRange(characterReadings.ToArray());

            btnNext.Enabled = SelectedGroups.Count != 0;
            txtCharacterInput.Enabled = SelectedGroups.Count != 0;
        }

        private void TxtCharacterInput_TextChanged(object sender, EventArgs e)
        {
            bool correct = false;
            foreach (String s in alphabetManager.CurrentCharacter.Readings[typeMode])
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
            selectionMethod = (SelectionMode) cboSelectionMethod.SelectedItem;
        }

        
        private void DisplayCharacter(Character character)
        {
            rtbCharacterDisplay.Text = string.Join(",", character.Readings[displayMode]);
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void CboTypeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeMode = ((KeyValuePair<string,string>) cboTypeMode.SelectedItem).Key;
        }
        private void CboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {

            displayMode = ((KeyValuePair<string, string>) cboDisplayMode.SelectedItem).Key;
            if (SelectedGroups.Count > 0)
                NextCharacter();
        }

    }
}
