using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet.Characters
{
    public class CharacterGroup 
    {
        /// <summary>Characters in this group (Not sub groups)</summary>
        public List<Character> Characters { get; set; }
        public List<CharacterGroup> ChildGroups { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }


        public CharacterGroup(List<CharacterGroup> ChildGroups, List<Character> Characters)
        {
            this.ChildGroups = ChildGroups;
            this.Characters = Characters;
        }

        public CharacterGroup()
        {
            this.ChildGroups = new List<CharacterGroup>();
            this.Characters = new List<Character>();
        }

        /// <summary>
        /// Returns all characters from this group and all it's descendants
        /// </summary>
        /// <returns></returns>
        public List<Character> GetAllCharacters()
        {

            List<Character> characters = Characters;

            foreach (CharacterGroup g in ChildGroups)
            {
                foreach (Character c in g.GetAllCharacters())
                {
                    characters.Add(c);
                }

            }
            return characters;
        }

        /// <summary>
        /// Returns all decendents of this group
        /// </summary>
        /// <returns></returns>
        public List<CharacterGroup> GetAllDescendantsGroups()
        {

            List<CharacterGroup> groups = ChildGroups;

            foreach (CharacterGroup g in groups)
            {
                foreach (CharacterGroup c in g.GetAllDescendantsGroups())
                {
                    groups.Add(c);
                }

            }
            return groups;
        }




    }
}
