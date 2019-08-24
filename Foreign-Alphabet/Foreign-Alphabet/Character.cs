using System.Collections.Generic;

namespace Foreign_Alphabet
{
    public class Character
    {
        public Dictionary<string,string> representation;
        public string character;

        public Character()
        {
            representation = new Dictionary<string, string>();
        }
    }
}