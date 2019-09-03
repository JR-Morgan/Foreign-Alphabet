using System.Collections.Generic;

namespace Foreign_Alphabet
{
    public class Character
    {
        public Dictionary<string, List<string>> readings;
        public Dictionary<string, List<string>> meanings;

        public Character()
        {
            readings = new Dictionary<string, List<string>>();
            meanings = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> GetAllMetaData()
        {
            Dictionary<string, List<string>> merge = new Dictionary<string, List<string>>();
            foreach (string key in readings.Keys)
            {
                merge.Add(key, readings[key]);
            }
            foreach (string key in meanings.Keys)
            {
                merge.Add(key, meanings[key]);
            }
            return merge;
        }
    }
}