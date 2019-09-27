using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreign_Alphabet
{
    public class AlphabetManager
    {
        public Alphabet Alphabet { get; }
        public Character CurrentCharacter { get; set; }


        public AlphabetManager(Alphabet alphabet)
        {
            this.Alphabet = alphabet;
            
        }

        /// <summary>
        /// returns a new character with a selected mode.
        /// </summary>
        /// <param name="mode">Selection mode - the way inwhich the character is selected</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException ">thrown if mode is not implemented</exception>
        public Character NewCharacter(SelectionMethod mode, IEnumerable<CharacterGroup> groups)
        {
            
            List<Character> characters = Alphabet.GetCharacters(groups);
            Character c;
            switch (mode)
            {
                case SelectionMethod.Random:
                    c = RandomCharacter(characters, CurrentCharacter);
                    break;
                case SelectionMethod.Sequential:
                    c = SequentialCharacter(characters, CurrentCharacter);
                    break;
                default:
                    throw new NotImplementedException(String.Format("{0} is not an imlemented selection mode", mode));
            }
            CurrentCharacter = c;
            return c;
        }

        /// <summary>
        /// Returns a random character from a list of characters that isnt the current character
        /// </summary>
        /// <param name="characters">list of characters to select from</param>
        /// <param name="currentCharacter">the currently selected character (to avoid chosing the same character again)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if an argument is empty</exception>
        public Character RandomCharacter(List<Character> characters, Character currentCharacter)
        {
            if (characters.Count == 0) throw new ArgumentException("collection is empty", "characters");

            Character c;
            do
            {
                c = RandomCharacter(characters);
            } while (c == currentCharacter && characters.Count > 1);
            return c;
            
        }
        /// <summary>
        /// Returns a random character from a list of characters
        /// </summary>
        /// <param name="characters">list of characters to select from</param>
        /// <returns>returns selected character</returns>
        /// <exception cref="ArgumentNullException">Thrown if an argument is empty</exception>
        /// <exception cref="ArgumentException">Thrown if an argument is invalid</exception>
        private Character RandomCharacter(List<Character> characters)
        {
            if (characters == null) throw new ArgumentNullException("value was null", "characters");
            if (characters.Count == 0) throw new ArgumentException("collection is empty", "characters");

            Random rand = new Random();

            Character c = characters[rand.Next(characters.Count)];

            while (c == CurrentCharacter && characters.Count > 1)
            {
                c = characters[rand.Next(characters.Count)];
            }

            return c;
        }

        /// <summary>
        /// Returns the next character from the list of characters
        /// </summary>
        /// <param name="characters">list of characters to select from</param>
        /// <param name="currentCharacter">currently selected character</param>
        /// <returns>the next character in the list</returns>
        /// <exception cref="ArgumentNullException">Thrown if an argument is empty</exception>
        /// <exception cref="ArgumentException">Thrown if an argument is invalid</exception>
        private Character SequentialCharacter(List<Character> characters, Character currentCharacter)
        {
            if (characters == null) throw new ArgumentNullException("value was null", "characters");
            if (characters.Count == 0) throw new ArgumentException("collection is empty", "characters");

            int lastCharIndex = currentCharacter != null ? characters.IndexOf(currentCharacter) : 0;
            return characters[(lastCharIndex + 1) % (characters.Count)];
        }
    }
}
