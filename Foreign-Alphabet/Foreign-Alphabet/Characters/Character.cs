using System.Collections.Generic;

namespace Foreign_Alphabet.Characters
{
    /// <summary>
    /// Class for storing meta data about a character for example, its readings and meanings.
    /// </summary>
    public class Character
    {
        /// <summary> Dictionary of MetaData groups, eg readings and meanings </summary>
        private Dictionary<string, Dictionary<CharacterMetaType, List<string>>> MetaGroups;

        public Character()
        {
            MetaGroups = new Dictionary<string, Dictionary<CharacterMetaType, List<string>>>();
        }

        /// <summary>
        /// returns the MetaData group specified by the ID
        /// </summary>
        /// <param name="group">The ID of the Meta Type Group that should be returned</param>
        /// <exception cref="KeyNotFoundException">Thrown if the key is not found</exception>
        /// <returns></returns>
        public Dictionary<CharacterMetaType, List<string>> GetMetaGroup(string group)
        {
            return MetaGroups[group];
        }

        public Dictionary<string, Dictionary<CharacterMetaType, List<string>>> GetMetaGroups()
        {
            return MetaGroups;
        }

        /// <summary>
        /// Adds a new group
        /// </summary>
        /// <param name="group">The ID of the Meta Type Group</param>
        public void AddMetaGroup(string group)
        {
            MetaGroups.Add(group, new Dictionary<CharacterMetaType, List<string>>());
        }

        public bool ContainsMetaGroup(string group)
        {
            return MetaGroups.ContainsKey(group);
        }

        public void AddMetaData(string group, CharacterMetaType type, List<string> data)
        {
            if (!ContainsMetaGroup(group))
            {
                AddMetaGroup(group);
            }
            MetaGroups[group].Add(type, data);

        }

    }
}