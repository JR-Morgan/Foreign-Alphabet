using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Foreign_Alphabet
{
    public partial class Form1 : Form
    {

        private Alphabet alphabet;
        private List<Character> SelectedCharacters;
        private Character lastSelectedCharacter;


        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFile()
        {
            String filePath;

            if (ofdAlphabetFileDialogue.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = ofdAlphabetFileDialogue.FileName;
                txtFile.Text = filePath;
                if (txtFile.Text.EndsWith(".xml"))
                {
                    ResetLoadedAlphabet();
                    XDocument doc = XDocument.Load(filePath);
                    this.alphabet = ParseElement(doc.Element("alphabet"));


                    trvAlphabetGroups.Nodes.Add(PopulateTree(this.alphabet));
                }
            }

        }
        private TreeNode PopulateTree(Alphabet alphabet)
        {
            TreeNode node = new TreeNode()
            {
                Text = alphabet.Name,
                Tag = alphabet
            };
            node.Expand();
            foreach (Alphabet a in alphabet.subGroup)
            {
                node.Nodes.Add(PopulateTree(a));
            }

            return node;
        }

        private Alphabet ParseElement(XElement rootElement)
        {
            Alphabet alphabet = new Alphabet
            {
                Name = rootElement.Attribute("name").Value
            };
            foreach (XElement node in rootElement.Elements())
            {
                if (node.Name == "alphabet")
                {
                    alphabet.subGroup.Add(ParseElement(node));
                }
                else if (node.Name == "char")
                {
                    Character c = new Character
                    {
                        character = node.Value
                    };
                    foreach (XAttribute a in node.Attributes())
                    {
                        c.representation.Add(a.Name.ToString(), a.Value);
                    }
                    alphabet.characters.Add(c);
                }

            }
            return alphabet;
        }

        private void ResetLoadedAlphabet()
        {
            trvAlphabetGroups.Nodes.Clear();
            alphabet = new Alphabet();
            UpdateSelectedCharacters();
        }
        
        private void UpdateSelectedCharacters()
        {
            SelectedCharacters = alphabet.GetAllEnabledCharacters();
            btnNext.Enabled = SelectedCharacters.Count != 0;
        }

        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {


            if (e.Action != TreeViewAction.Unknown)
            {
                SetChildrenChecked(e.Node, e.Node.Checked);
                if(!e.Node.Checked)
                {
                    SetParentsChecked(e.Node, false);
                }

                UpdateSelectedCharacters();
            }
            
        }
        private void SetChildrenChecked(TreeNode parentNode, bool check)
        {
            ((Alphabet)parentNode.Tag).Enabled = check;
            parentNode.Checked = check;

            foreach (TreeNode childNode in parentNode.Nodes)
            {
                SetChildrenChecked(childNode, check);
            }
        }

        private void SetParentsChecked(TreeNode RootNode, bool check)
        {
            ((Alphabet)RootNode.Tag).Enabled = check;
            RootNode.Checked = check;

            if(RootNode.Parent != null)
            {
                SetParentsChecked(RootNode.Parent, check);
            }
            
        }
        private Character RandomCharacter(List<Character> characters)
        {
            Random rand = new Random();
            Character c = characters[rand.Next(characters.Count)];

            while (c == lastSelectedCharacter && characters.Count > 1)
            {
                c = characters[rand.Next(characters.Count)];
            }

            lastSelectedCharacter = c;
            return c;
        }
        private void NextCharacter()
        {
            Character c = RandomCharacter(SelectedCharacters);
            rtbCharacterDisplay.Text = c.character;
            List<String> description = new List<String>();
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;

            foreach (String s in c.representation.Keys)
            {
                switch(s)
                {
                    case "latin":
                        description.Add("Latin : " + c.representation[s]);
                        break;
                    case "ipa":
                        description.Add("  IPA : " + c.representation[s]);
                        break;
                    case "audio":
                        //TODO audio;
                        break;
                }
                
            }

            chkDescription.Enabled = description.Count != 0;

            lboDescription.Items.Clear();
            lboDescription.Items.AddRange(description.ToArray());
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NextCharacter();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            rtbCharacterDisplay.Font = fontDialog.Font;
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }


        private void ChkDescription_CheckedChanged(object sender, EventArgs e)
        {
            lboDescription.Visible = chkDescription.Checked;
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
            LoadFile();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetLoadedAlphabet();
        }
    }
}
