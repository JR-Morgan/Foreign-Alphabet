using System;
using System.Runtime.Serialization;
using Foreign_Alphabet;
using Foreign_Alphabet.Characters;

namespace WinForm
{
    [Serializable]
    internal class CharacterMetaModeException : Exception
    {

        public Character character { get; set; }
        public string metaMode { get; set; }


        public CharacterMetaModeException(Character character, string metaMode, string metaModeName, string message)
            : base($"Character {character} does not contain a {metaModeName} of type: {metaMode}\n" + message)
        {
            this.character = character;
            this.metaMode = metaMode;
        }
        public CharacterMetaModeException(Character character, string MetaMode, string metaModeName)
            : base($"Character {character} does not contain a {metaModeName} mode of type: {MetaMode}")
        {
            this.character = character;
            this.metaMode = MetaMode;
        }


    }
}