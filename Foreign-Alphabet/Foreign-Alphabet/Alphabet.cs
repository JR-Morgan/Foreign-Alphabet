using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet{
    class Alphabet
    {
        public string AlphabetName { get; set; }
        /// <summary>
        /// List of all groups incliding child groups
        /// </summary>
        public List<CharacterGroup> CharacterGroups { get; set; }
        public List<CharacterGroup> RootGroups { get; set; }
        //For now these are lists, so the id is ignored at the moment.
        public Dictionary<string, string> DisplayOptions { get; set; }
        public Dictionary<string, string> TypeOptions { get; set; }
        public string DefaultDisplay { get; set; }
        public string DefaultType { get; set; }

        /// <summary>
        /// Creates a new empty alphabet
        /// </summary>
        public Alphabet()
        {
            this.AlphabetName = "";
            this.CharacterGroups = new List<CharacterGroup>();
            this.DisplayOptions = new Dictionary<string, string>();
            this.TypeOptions = new Dictionary<string, string>();
        }

        /// <summary>
        /// returns all characters in the alphabet
        /// </summary>
        /// <returns></returns>
        public List<Character> GetAllCharacters()
        {
            //TODO
            return null;
        }

        /// <summary>
        /// Recursivly loops through all descendant groups of each group given, and returns all characters<br/>
        /// <remarks><br/>
        /// <remarks><br/>
        /// NOTE: If both a parent and it's child group are given in <paramref name="groups">groups</paramref> then <br/>
        /// It will not result in duplicates however will take extra unnessesery time to compute.<br/>
        /// Therefore it is advised that you only give it the highest level group(s).
        /// </remarks>
        /// </summary>
        /// <param name="groups">collection of group keys</param>
        /// <returns>Returns all characters in a collection of groups without duplicates</returns>
        public List<Character> GetCharacters(IEnumerable<CharacterGroup> groups)
        {
            HashSet<Character> characters = new HashSet<Character>();
            foreach(CharacterGroup group in groups)
            {
                characters.UnionWith(group.GetAllCharacters());
            }

            return characters.ToList() ;
        }
    }







    /*public class Alphabet
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
    */
}
