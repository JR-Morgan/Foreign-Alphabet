using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Foreign_Alphabet
{
    public class AlphabetParser
    {

        public Alphabet ParseFile(string filePath)
        {
            // Validating XML
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "AlphabetFile.xsd");

            XDocument doc = XDocument.Load(filePath);
            bool errors = false;
            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            if(errors)
            {
                throw new System.Xml.XmlException("Loaded XML file does not follow the current XML Schema");
            }



            //Parsing XML
            //TODO check version number

            XElement rootElement = doc.Element("alphabet-file");

            Alphabet alphabet = new Alphabet
            {
                AlphabetName = rootElement.Attribute("name") != null ? rootElement.Attribute("name").Value : "Unamed Group",
            };

            //TODO simplify below code
            { // Display Options
                XElement displayOptions = rootElement.Element("alphabet-options").Element("display-options");
                alphabet.DefaultDisplay = displayOptions.Attribute("default").Value;
                foreach (XElement element in displayOptions.Elements())
                {
                    alphabet.DisplayOptions.Add(element.Attribute("id").Value, element.Attribute("name").Value);
                }
            }

            { // Type Options
                XElement typeOptions = rootElement.Element("alphabet-options").Element("type-options");
                alphabet.DefaultType = typeOptions.Attribute("default").Value;
                foreach (XElement element in typeOptions.Elements())
                {
                    alphabet.TypeOptions.Add(element.Attribute("id").Value, element.Attribute("name").Value);
                }
            }

            //Groups
            Dictionary<string, CharacterGroup> groups = new Dictionary<string, CharacterGroup>();
            
            {
                List<CharacterGroup> rootGroups = new List<CharacterGroup>();
                XElement alphabetClasses = rootElement.Element("alphabet-classes");
                foreach (XElement eGroup in alphabetClasses.Elements())
                {
                    rootGroups.Add(ParseGroupElement(eGroup));
                }

                //TODO better solution than this


                foreach (CharacterGroup g in rootGroups)
                {
                    groups.Add(g.ID, g);
                    foreach (CharacterGroup c in g.GetAllDescendantsGroups())
                    {
                        groups.Add(c.ID, c);
                    }
                    alphabet.CharacterGroups.Add(g);
                }
                alphabet.RootGroups = rootGroups;
            }
            



            // Characters
            {
                XElement alphabetCharacters = rootElement.Element("alphabet-characters");
                foreach(XElement eCharacter in alphabetCharacters.Elements())
                {
                    
                    Character character = new Character();
                    foreach (XElement eReading in eCharacter.Elements())
                    {
                        //Splitting readings by whitespace
                        List<string> reading = eReading.Value
                            .Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();
                        character.Readings.Add(eReading.Attribute("id").Value, reading);
                        
                    }

                    
                    List<string> groupIDs = eCharacter.Attribute("class").Value
                        .Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach(string groupID in groupIDs)
                    {
                        if (!groups.ContainsKey(groupID))
                        {
                            throw new KeyNotFoundException("key \"" + groupID + "\" was not found in groups");
                        }
                        groups[groupID].Characters.Add(character);
                    }
                    
                }
                
            }

            return alphabet;
        }

        private CharacterGroup ParseGroupElement(XElement rootElement)
        {

            CharacterGroup characterGroup = new CharacterGroup
            {
                Name = rootElement.Attribute("name") != null ? rootElement.Attribute("name").Value : "Unamed Group",
                ID = rootElement.Attribute("id").Value
            };

            foreach (XElement child in rootElement.Elements())
            {
                characterGroup.ChildGroups.Add(ParseGroupElement(child));
            }
            return characterGroup;
        }

    }
}
