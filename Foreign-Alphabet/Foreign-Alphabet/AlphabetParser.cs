using Foreign_Alphabet.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Foreign_Alphabet
{
    /*
     * This code is temporary until I finalise the structure of the XML files which at this stage of development are constantly changing
     * and are still not final, there are many things that they cannot do by definition, or can only do badly
     * Therefore, this whole class is a bit of a mess which will be my top priority once I finalise the program
     * 
     * Appologies for below.
     */
    public class AlphabetParser
    {

        public Alphabet ParseFile(string filePath)
        {
            // Validating XML
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "AlphabetFile.xsd");

            XDocument doc = XDocument.Load(filePath);
            bool errors = false;
            string lastError = "";
            doc.Validate(schemas, (o, e) =>
            {
                lastError = e.Message;
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            if(errors)
            {
                throw new System.Xml.XmlException("Loaded XML file does not follow the current XML Schema" + lastError);
            }



            //Parsing XML
            //TODO check version number

            XElement rootElement = doc.Element("alphabet-file");

            Alphabet alphabet = new Alphabet
            {
                AlphabetName = rootElement.Attribute("name") != null ? rootElement.Attribute("name").Value : "Unamed Group",
            };



            //META GROUPS
            Dictionary<string, CharacterMetaType> metaTypes = new Dictionary<string, CharacterMetaType>();
            {
                XElement AlphabetCharacters = rootElement.Element("alphabet-characters-meta");

                foreach (XElement metaGroup in AlphabetCharacters.Elements())
                {
                    CharacterMetaType type = new CharacterMetaType( metaGroup.Attribute("id").Value,
                                                                    metaGroup.Attribute("name").Value,
                                                                    metaGroup.Attribute("display") != null ? metaGroup.Attribute("display").Value.ToLower() == "true" : false,
                                                                    metaGroup.Attribute("input") != null ? metaGroup.Attribute("input").Value.ToLower() == "true" : false
                                                                    );
                    metaTypes.Add(metaGroup.Attribute("id").Value, type);

                }
                
            }



            //UI OPTIONS
            {
                XElement options = rootElement.Element("ui-options");
                foreach(CharacterMetaType MetaType in metaTypes.Values)
                {
                    if(MetaType.id == options.Element("display-options").Attribute("defaultMeta").Value)
                    {
                        alphabet.DefaultDisplay = MetaType;
                    }
                    if (MetaType.id == options.Element("display-options").Attribute("defaultMeta").Value)
                    {
                        alphabet.DefaultType = MetaType;
                    }
                }
            }


            /*
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
            }*/

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
                    foreach (XElement eMeta in eCharacter.Elements())
                    {
                        List<string> value = eMeta.Value.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).ToList();

                        CharacterMetaType type = new CharacterMetaType();
                        //TODO optimise this loop (use extra dictionary?)
                        foreach (CharacterMetaType metaType in metaTypes.Values)
                        {
                            if (metaType.id == eMeta.Attribute("id").Value)
                            {
                                type = metaType;
                            }
                        }
                        if(type.id != null)
                        {
                            character.AddMetaData(eMeta.Name.ToString(), type, value);
                        }

                        

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
