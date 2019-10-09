using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet.Characters
{
    public class CharacterMetaData
    {
        public string ID { get; }
        public string GroupID { get; }
        public string GroupName { get; }
        public string Name { get; }
        public bool Display { get; }
        public bool Input { get; }

        public CharacterMetaData(string id, string groupID, string groupName, string name, bool display, bool input)
        {
            ID = id;
            GroupID = groupID;
            GroupName = groupName;
            Name = name;
            Display = display;
            Input = input;
        }
    }
}
