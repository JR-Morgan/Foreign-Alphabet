using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet
{
    public class Alphabet
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Enabled { get; set; } = false;

        public string DefaultDisplay { get; set; }
        public string DefaultType { get; set; }

        public List<Alphabet> subGroup;
        public List<Character> characters;

        public Alphabet()
        {
            subGroup = new List<Alphabet>();
            characters = new List<Character>();
        }
        public List<Character> GetAllEnabledCharacters()
        {
            
            List<Character> characters = this.characters;

            if(!Enabled)
            {
                characters = new List<Character>();
            }

            foreach(Alphabet a in subGroup)
            {
                foreach(Character c in a.GetAllEnabledCharacters())
                {
                    characters.Add(c);
                }
                
            }

            return characters;
        }
    }
}
