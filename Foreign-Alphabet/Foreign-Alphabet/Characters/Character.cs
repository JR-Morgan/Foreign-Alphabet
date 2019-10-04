using System.Collections.Generic;

namespace Foreign_Alphabet.Characters
{
    /// <summary>
    /// Class for storing data about a character
    /// </summary>
    public class Character
    {
        public Dictionary<CharacterMetaData, List<string>> Data { get; set; }

        public Character()
        {
            Data = new Dictionary<CharacterMetaData, List<string>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public Dictionary<CharacterMetaData, List<string>> GetFromGroup(string groupID)
        {
            Dictionary<CharacterMetaData, List<string>> Data = new Dictionary<CharacterMetaData, List<string>>();
            foreach (CharacterMetaData meta in this.Data.Keys)
            {
                if(meta.groupID == groupID)
                {
                    Data.Add(meta, this.Data[meta]);
                }
            }
            return Data;
        }
    }
}