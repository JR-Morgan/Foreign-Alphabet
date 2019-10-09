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
        public CharacterMetaData MetaData { get; set; }


        public CharacterMetaModeException(Character character, CharacterMetaData MetaData, string message)
            : base($"Character \"{character}\" does not contain meta data for: \"{MetaData.Name}\" in group: \"{MetaData.GroupID}\"\n" + message)
        {
            this.character = character;
            this.MetaData = MetaData;
        }

    }
}