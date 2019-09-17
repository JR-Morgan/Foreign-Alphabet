using System.Collections.Generic;

namespace Foreign_Alphabet
{
    public class Character
    {
        public Dictionary<string, List<string>> Readings { get; set; }

        public Character()
        {
            this.Readings = new Dictionary<string, List<string>>();
        }
        public Character(Dictionary<string, List<string>> readings)
        {
            this.Readings = readings;
        }
    }
}