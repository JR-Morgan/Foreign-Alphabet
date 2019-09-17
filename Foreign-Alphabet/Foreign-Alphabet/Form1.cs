using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace Foreign_Alphabet
{
    public partial class Form1 : Form
    {
        AlphabetManager alphabetManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
            rtbCharacterDisplay.Font = fontDialog.Font;
            cboSelectionMethod.SelectedItem = cboSelectionMethod.Items[0];
            lblInstructions.Text = "Load an alphabet";
            txtFile.Text = "";
        }
        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void LoadFile()
        {
            
            String filePath;
            if (ofdAlphabetFileDialogue.ShowDialog() == DialogResult.OK)
            {
                filePath = ofdAlphabetFileDialogue.FileName;
                AlphabetParser alphabetParser = new AlphabetParser();
                alphabetManager = new AlphabetManager(alphabetParser.ParseFile(filePath));
                txtFile.Text = Path.GetFileNameWithoutExtension(filePath);

            }

            //        ResetLoadedAlphabet();
            //        XDocument doc = XDocument.Load(filePath);
            //        this.Alphabet = ParseElement(doc.Element("alphabet"));


            //        trvAlphabetGroups.Nodes.Add(PopulateTree(this.Alphabet));

            //        string[] modeArray = new string[modes.Count];
            //        modes.CopyTo(modeArray);
            //        cboDisplayMode.Items.Clear();
            //        cboTypeMode.Items.Clear();
            //        cboDisplayMode.Items.AddRange(modeArray);
            //        cboTypeMode.Items.Add("None");
            //        cboTypeMode.Items.AddRange(modeArray);


            //        lblInstructions.Text = "Select alphabet group";

            //        cboDisplayMode.SelectedItem = Alphabet.DefaultDisplay;
            //        cboTypeMode.SelectedItem = Alphabet.DefaultType;

            //        analyticsForm = new FrmAverages();
            //        btnAnalytics.Enabled = true;
            //    }
            //}

        }



        private void TrvAlphabetGroups_AfterCheck(object sender, TreeViewEventArgs e)
        {


            //if (e.Action != TreeViewAction.Unknown)
            //{
            //    SetChildrenChecked(e.Node, e.Node.Checked);
            //    if (!e.Node.Checked)
            //    {
            //        SetParentsChecked(e.Node, false);
            //    }

            //    UpdateSelectedCharacters();
            //}

        }


        private void BtnNext_Click(object sender, EventArgs e)
        {
            //NextCharacter(selectedCharacters, displayMode, typeMode);
        }
        private void TxtCharacterInput_TextChanged(object sender, EventArgs e)
        {
            //bool correct = false;
            //foreach (String s in currentCharacter.GetAllMetaData()[typeMode])
            //{
            //    if (txtCharacterInput.Text.ToLower().Trim() == s.ToLower().Trim())
            //    {
            //        correct = true;
            //    }
            //}
            //if (correct)
            //{
            //    txtCharacterInput.Text = "";
            //    NextCharacter(selectedCharacters, displayMode, typeMode);
            //}
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
            //if (fontDialog.ShowDialog() == DialogResult.OK)
            //{
            //    rtbCharacterDisplay.Font = fontDialog.Font;
            //}
        }

        private void FontColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (codTextColor.ShowDialog() == DialogResult.OK)
            //{
            //    rtbCharacterDisplay.ForeColor = codTextColor.Color;
            //}
        }

        private void BackgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (codBGColor.ShowDialog() == DialogResult.OK)
            //{
            //    rtbCharacterDisplay.BackColor = codBGColor.Color;
            //}
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadFile();
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
            //selectionMethod = cboSelectionMethod.Text;
        }

        private void CboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displayMode = cboDisplayMode.Text;
            //if (selectedCharacters.Count > 0)
            //    displayCharacter(currentCharacter, displayMode);
        }

        private void CboTypeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //typeMode = cboTypeMode.Text;
            //btnNext.Visible = typeMode == "None";
            //txtCharacterInput.Visible = typeMode != "None";
        }


    }
}
/*
public partial class Form1 : Form
{

    public Alphabet Alphabet { get; set; }
    private List<Character> selectedCharacters;
    private Character currentCharacter;

    //The method of selecting characters
    private string selectionMethod;

    //The reading/meaning to be displayed
    private string displayMode;
    //The reading/meaning to be typed
    private string typeMode;
    //The options of readings/meanigns
    private HashSet<string> modes;

    private FrmAverages analyticsForm;
    //Time user takes to guess character
    private long deltaT;


    public Form1()
    {
        InitializeComponent();
    }

    private void LoadFile()
    {
        String filePath;
        lblInstructions.Text = "Error loading alphabet";
        if (ofdAlphabetFileDialogue.ShowDialog() == DialogResult.OK)
        {
            //Get the path of specified file
            filePath = ofdAlphabetFileDialogue.FileName;
            txtFile.Text = Path.GetFileNameWithoutExtension (filePath);
            if (filePath.EndsWith(".xml"))
            {

                ResetLoadedAlphabet();
                XDocument doc = XDocument.Load(filePath);
                this.Alphabet = ParseElement(doc.Element("alphabet"));


                trvAlphabetGroups.Nodes.Add(PopulateTree(this.Alphabet));

                string[] modeArray = new string[modes.Count];
                modes.CopyTo(modeArray);
                cboDisplayMode.Items.Clear();
                cboTypeMode.Items.Clear();
                cboDisplayMode.Items.AddRange(modeArray);
                cboTypeMode.Items.Add("None");
                cboTypeMode.Items.AddRange(modeArray);


                lblInstructions.Text = "Select alphabet group";

                cboDisplayMode.SelectedItem = Alphabet.DefaultDisplay;
                cboTypeMode.SelectedItem = Alphabet.DefaultType;

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
            Name = rootElement.Attribute("name") != null ? rootElement.Attribute("name").Value : "Unamed Group",
            DefaultDisplay = rootElement.Attribute("defaultDisplay") != null ? rootElement.Attribute("defaultDisplay").Value : "",
            DefaultType = rootElement.Attribute("defaultType") != null ? rootElement.Attribute("defaultType").Value : ""
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
                                c.readings.Add(cNode.Attribute("name").Value, new List<string>(cNode.Value.Trim().Split(',')));
                                //FIXME this breaks functional rules!
                                modes.Add(cNode.Attribute("name").Value);
                                break;
                            case "meaning":
                                c.meanings.Add(cNode.Attribute("name").Value, new List<string>(cNode.Value.Trim().Split(',')));
                                //FIXME this breaks functional rules!
                                modes.Add(cNode.Attribute("name").Value);
                                break;
                        }
                    }
                    alphabet.Characters.Add(c);
                    break;
            }
            alphabet.DefaultDisplay = rootElement.Attribute("defaultDisplay") != null ? rootElement.Attribute("defaultDisplay").Value : "" ;
            alphabet.DefaultType = rootElement.Attribute("defaultType") != null ? rootElement.Attribute("defaultType").Value : "";

        }
        return alphabet;
    }

    private void ResetLoadedAlphabet()
    {
        currentCharacter = null;
        trvAlphabetGroups.Nodes.Clear();
        Alphabet = new Alphabet();
        modes = new HashSet<string>();
        UpdateSelectedCharacters();
    }

    private void UpdateSelectedCharacters()
    {

        selectedCharacters = Alphabet.GetAllEnabledCharacters();
        btnNext.Enabled = selectedCharacters.Count != 0;
        txtCharacterInput.Enabled = selectedCharacters.Count != 0;
        if(selectedCharacters.Count != 0)
        {
            lblInstructions.Text = "";
            NextCharacter(selectedCharacters, displayMode, typeMode);
        } else
        {
            lblInstructions.Text = "Select alphabet group";
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
        int lastCharIndex = characters.IndexOf(currentCharacter);
        return characters[(lastCharIndex + 1) % (characters.Count)];
   }

    private Character RandomCharacter(List<Character> characters)
    {
        Random rand = new Random();
        Character c = characters[rand.Next(characters.Count)];

        while (c == currentCharacter && characters.Count > 1)
        {
            c = characters[rand.Next(characters.Count)];
        }

        return c;
    }
    private void NextCharacter(List<Character> characters, String display, String type)
    {
        //TODO
        //if (currentCharacter != null)
        //{
        //    analyticsForm.AddChart(currentCharacter, DateTime.Now.Ticks - deltaT);
        //}
        //deltaT = DateTime.Now.Ticks;

        //Select Character
        Character c;
        switch(selectionMethod)
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
        currentCharacter = c;

        displayCharacter(c, displayMode);


        //TODO Type
        List<String> characterReadings = new List<String>();
        List<String> characterMeanings = new List<String>();


        //Add Readings and Meanings
        foreach (String k in c.readings.Keys)
        {
            characterReadings.Add(k + ":\t " + String.Join(",", c.Readings[k]));  
        }
        foreach (String k in c.meanings.Keys)
        {
            characterMeanings.Add(k + ":\t " + String.Join("," , c.meanings[k]));
        }

        //Enable CheckBoxes
        chkReading.Enabled = characterReadings.Count != 0;
        chkMeaning.Enabled = characterMeanings.Count != 0;
        lboReading.Visible = characterReadings.Count != 0 && lboReading.Visible;
        lboMeaning.Visible = characterMeanings.Count != 0 && lboMeaning.Visible;

        lboReading.Items.Clear();
        lboReading.Items.AddRange(characterReadings.ToArray());
        lboMeaning.Items.Clear();
        lboMeaning.Items.AddRange(characterMeanings.ToArray());
    }

    private void displayCharacter(Character c, string display)
    {
        rtbCharacterDisplay.Text = string.Join(",", c.Readings[display]);
        rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
    }

    private void BtnNext_Click(object sender, EventArgs e)
    {
        NextCharacter(selectedCharacters, displayMode, typeMode);
    }
    private void TxtCharacterInput_TextChanged(object sender, EventArgs e)
    {
        bool correct = false;
        foreach(String s in currentCharacter.GetAllMetaData()[typeMode])
        {
            if (txtCharacterInput.Text.ToLower().Trim() == s.ToLower().Trim())
            {
                correct = true;
            }
        }
        if (correct)
        {
            txtCharacterInput.Text = "";
            NextCharacter(selectedCharacters, displayMode, typeMode);
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        rtbCharacterDisplay.SelectionAlignment = HorizontalAlignment.Center;
        rtbCharacterDisplay.Font = fontDialog.Font;
        cboSelectionMethod.SelectedItem = cboSelectionMethod.Items[0];
        lblInstructions.Text = "Load an alphabet";
        txtFile.Text = "";
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

    private void CboSelectionMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectionMethod = cboSelectionMethod.Text;
    }

    private void CboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayMode = cboDisplayMode.Text;
        if(selectedCharacters.Count > 0)
            displayCharacter(currentCharacter, displayMode);
    }

    private void CboTypeMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        typeMode = cboTypeMode.Text;
        btnNext.Visible = typeMode == "None";
        txtCharacterInput.Visible = typeMode != "None";
    }


} 
}*/
