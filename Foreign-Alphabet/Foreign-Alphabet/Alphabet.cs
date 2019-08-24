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

        public bool enabled;

        public LinkedList<Alphabet> subGroup;
        public LinkedList<Character> characters;

        public Alphabet()
        {
            subGroup = new LinkedList<Alphabet>();
            characters = new LinkedList<Character>();
        }
        public LinkedList<Character> getAllCharacters()
        {
            LinkedList<Character> characters = this.characters;

            foreach(Alphabet a in subGroup)
            {
                foreach(Character c in a.getAllCharacters())
                {
                    characters.AddLast(c);
                }
                
            }

            return characters;
        }
    }
}
