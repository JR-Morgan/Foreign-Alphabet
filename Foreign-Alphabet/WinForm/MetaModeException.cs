using Foreign_Alphabet;
using System;
using System.Runtime.Serialization;

namespace WinForm
{
    [Serializable]
    internal class CharacterMetaModeException : Exception
    {

        public Character character { get; set; }
        public string MetaMode { get; set; }


        public CharacterMetaModeException(Character character, string metaMode, string metaModeName, string message)
            : base($"Character {character} does not contain a {metaModeName} of type: {metaMode}\n" + message)
        {
            this.character = character;
            this.MetaMode = metaMode;
        }
        public CharacterMetaModeException(Character character, string MetaMode, string metaModeName)
            : base($"Character {character} does not contain a {metaModeName} mode of type: {MetaMode}")
        {
            this.character = character;
            this.MetaMode = MetaMode;
        }


    }
}