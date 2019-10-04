using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet.Characters
{
    public class CharacterMetaData
    {
        public readonly string id;
        public readonly string groupID;
        public readonly string groupName;
        public readonly string name;
        public readonly bool display;
        public readonly bool type;

        public CharacterMetaData(string id, string groupID, string groupName, string name, bool display, bool type)
        {
            this.id = id;
            this.groupID = groupID;
            this.groupName = groupName;
            this.name = name;
            this.display = display;
            this.type = type;
        }
    }
}
