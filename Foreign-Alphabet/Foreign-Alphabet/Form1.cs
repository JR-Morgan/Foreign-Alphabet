using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Foreign_Alphabet
{
    public partial class Form1 : Form
    {

        private Alphabet alphabet;
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

                /*
                String msg = "";
                foreach (Character c in alphabet.getAllCharacters())
                {
                    msg += c.character;
                }
                System.Windows.Forms.MessageBox.Show(msg);
                */
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
                    alphabet.subGroup.AddLast(parseElement(node));
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
                    alphabet.characters.AddLast(c);
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

    }
}
