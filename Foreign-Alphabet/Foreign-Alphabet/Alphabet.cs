using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foreign_Alphabet.Characters;

namespace Foreign_Alphabet {
    public class Alphabet
    {
        public string AlphabetName { get; set; }
        /// <summary>List of all groups incliding child groups</summary>
        public List<CharacterGroup> CharacterGroups { get; set; }
        public List<CharacterGroup> RootGroups { get; set; }
        public Dictionary<string, List<CharacterMetaData>> MetaTypeGroups { get; set; }
        public CharacterMetaData DefaultDisplay { get; set; }
        public CharacterMetaData DefaultType { get; set; }
        public List<CharacterMetaData> TypeOptions { get; set; }
        public List<CharacterMetaData> DisplayOptions { get; set; }

        /// <summary>
        /// Creates a new empty alphabet
        /// </summary>
        public Alphabet()
        {
            this.AlphabetName = "";
            this.CharacterGroups = new List<CharacterGroup>();
            this.MetaTypeGroups = new Dictionary<string, List<CharacterMetaData>>();
            this.TypeOptions = new List<CharacterMetaData>();
            this.DisplayOptions = new List<CharacterMetaData>();
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
}
