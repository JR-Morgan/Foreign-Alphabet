using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Foreign_Alphabet
{
    public partial class Form1 : Form
    {

        public Alphabet Alphabet { get; set; }
        private List<Character> selectedCharacters;
        private Character lastCharacter;
        private long deltaT;

        private FrmAverages analyticsForm;


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
                    this.Alphabet = ParseElement(doc.Element("alphabet"));


                    trvAlphabetGroups.Nodes.Add(PopulateTree(this.Alphabet));

                    analyticsForm = new FrmAverages();
                    btnAnalytics.Enabled = true;
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
                Name = rootElement.Attribute("name") != null ? rootElement.Attribute("name").Value : "Unamed Group"
            };
            
            foreach (XElement node in rootElement.Elements())
            {
                switch (node.Name.ToString())
                {
                    case "alphabet":
                        alphabet.subGroup.Add(ParseElement(node));
                        break;
                    case "char":
                        Character c = new Character();
                        foreach (XElement cNode in node.Elements())
                        {
                            switch (cNode.Name.ToString())
                            {
                                case "reading":
                                    c.readings.Add(cNode.Attribute("name").Value, cNode.Value);
                                    break;
                                case "meaning":
                                    c.meanings.Add(cNode.Attribute("name").Value, cNode.Value);
                                    break;
                                case "string":
                                    c.str = cNode.Value;
                                    break;
                            }
                        }
                        alphabet.characters.Add(c);
                        break;
                }

            }
            return alphabet;
        }

        private void ResetLoadedAlphabet()
        {
            trvAlphabetGroups.Nodes.Clear();
            Alphabet = new Alphabet();
            UpdateSelectedCharacters();
        }

        private void UpdateSelectedCharacters()
        {
            selectedCharacters = Alphabet.GetAllEnabledCharacters();
            btnNext.Enabled = selectedCharacters.Count != 0;
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

            if (RootNode.Parent != null)
            {
                SetParentsChecked(RootNode.Parent, check);
            }

        }
       private Character SequentialCharacter(List<Character> characters)
       {
            int lastCharIndex = characters.IndexOf(lastCharacter);
            return characters[(lastCharIndex + 1) % (characters.Count)];
       }

        private Character RandomCharacter(List<Character> characters)
        {
            Random rand = new Random();
            Character c = characters[rand.Next(characters.Count)];

            while (c == lastCharacter && characters.Count > 1)
            {
                c = characters[rand.Next(characters.Count)];
            }

            return c;
        }
        private void NextCharacter(List<Character> characters)
        {
            deltaT = DateTime.Now.Ticks;
            Character c;
            switch(cboSelectionMethod.Text)
            {
                case "Random":
                    c = RandomCharacter(characters);
                    break;
                case "Sequential":
                    c = SequentialCharacter(characters);
                    break;
                default:
                    c = RandomCharacter(characters);
                    break;
            }
            lastCharacter = c;
            rtbCharacterDisplay.Text = c.str;
            List<String> characterReadings = new List<String>();
            List<String> characterMeanings = new List<String>();
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;

            foreach (String s in c.readings.Keys)
            {
                characterReadings.Add(s + ":\t " + c.readings[s]);  
            }
            foreach (String s in c.meanings.Keys)
            {
                characterMeanings.Add(s + ":\t " + c.meanings[s]);
            }

            chkReading.Enabled = characterReadings.Count != 0;
            chkMeaning.Enabled = characterMeanings.Count != 0;

            lboReading.Items.Clear();
            lboReading.Items.AddRange(characterReadings.ToArray());
            lboMeaning.Items.Clear();
            lboMeaning.Items.AddRange(characterMeanings.ToArray());
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            

            NextCharacter(selectedCharacters);
            if(lastCharacter != null)
            {
                analyticsForm.AddChart(lastCharacter, DateTime.Now.Ticks - deltaT);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            rtbCharacterDisplay.Font = fontDialog.Font;
            cboSelectionMethod.SelectedItem = cboSelectionMethod.Items[0];
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
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
            LoadFile();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetLoadedAlphabet();
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            analyticsForm.Show();
        }
    }
}
