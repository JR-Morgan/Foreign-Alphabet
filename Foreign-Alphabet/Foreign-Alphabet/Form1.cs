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

        private void loadFile()
        {
            String filePath = string.Empty;

            if (ofdAlphabetFileDialogue.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = ofdAlphabetFileDialogue.FileName;
                txtFile.Text = filePath;

                XDocument doc = XDocument.Load(filePath);
                this.alphabet = parseElement(doc.Element("alphabet"));


                trvAlphabetGroups.Nodes.Add(populateTree(this.alphabet));


            }

        }
        private TreeNode populateTree(Alphabet alphabet)
        {
            TreeNode node = new TreeNode()
            {
                Text = alphabet.Name,
                Tag = alphabet
            };
            foreach (Alphabet a in alphabet.subGroup)
            {
                node.Nodes.Add(populateTree(a));
            }

            return node;
        }

        private Alphabet parseElement(XElement rootElement)
        {
            Alphabet alphabet = new Alphabet
            {
                Name = rootElement.Attribute("name").Value
            };
            foreach (XElement node in rootElement.Elements())
            {
                if (node.Name == "alphabet")
                {
                    alphabet.subGroup.Add(parseElement(node));
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

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ((Alphabet)e.Node.Tag).Enabled = e.Node.Checked;


            if (e.Action != TreeViewAction.Unknown)
            {
                SetChildrenChecked(e.Node);
            }
            SelectedCharacters = alphabet.getAllEnabledCharacters();
            btnNext.Enabled = SelectedCharacters.Count != 0;
        }
        private void SetChildrenChecked(TreeNode treeNode)
        {
            foreach (TreeNode item in treeNode.Nodes)
            {
                if (item.Checked != treeNode.Checked)
                {
                    item.Checked = treeNode.Checked;
                }

                if (item.Nodes.Count > 0)
                {
                    SetChildrenChecked(item);
                }
            }
        }


        private void BtnNext_Click(object sender, EventArgs e)
        {
            Character c = RandomCharacter(SelectedCharacters);
            rtbCharacterDisplay.Text = c.character;
            List<String> description = new List<String>();
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            
            foreach (String s in c.representation.Keys)
            {
                description.Add(s + " : " + c.representation[s]);
            }

            chkDescription.Enabled = description.Count != 0;

            lboDescription.Items.Clear();
            lboDescription.Items.AddRange(description.ToArray());

            
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

        private void ChkDescription_CheckedChanged(object sender, EventArgs e)
        {
            lboDescription.Visible = chkDescription.Checked;
        }
    }
}
