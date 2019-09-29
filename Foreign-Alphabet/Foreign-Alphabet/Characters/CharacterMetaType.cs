using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet.Characters
{
    public struct CharacterMetaType
    {
        public readonly string id;
        public readonly string name;
        public readonly bool display;
        public readonly bool type;

        public CharacterMetaType(string id, string name, bool display, bool type)
        {
            this.id = id;
            this.name = name;
            this.display = display;
            this.type = type;
        }
    }
}
