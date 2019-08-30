using System.Collections.Generic;

namespace Foreign_Alphabet
{
    public class Character
    {
        public Dictionary<string,string> readings;
        public Dictionary<string, string> meanings;
        public string str;

        public Character()
        {
            readings = new Dictionary<string, string>();
            meanings = new Dictionary<string, string>();
        }
    }
}