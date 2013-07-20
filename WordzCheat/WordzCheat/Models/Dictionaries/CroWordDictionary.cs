using System;
using System.Collections.Generic;
using System.Linq;

namespace WordzCheat.Models.Dictionaries
{
    public class CroWordDictionary : IWordDictionary
    {
        private Dictionary<char, string[]> _wordsByFirstLetter;

        public CroWordDictionary(Dictionary<char, string[]> inWordsByFirstLetter)
        {
            _wordsByFirstLetter = inWordsByFirstLetter;
        }

        public bool ContainsWord(string inWord)
        {
            char firstLetter = inWord[0];
            return _wordsByFirstLetter[firstLetter].Contains(inWord);
        }

        public bool ContainsWordsStartingWithPattern(string inPattern)
        {
            char firstLetter = inPattern[0];
            foreach (string word in _wordsByFirstLetter[firstLetter])
            {
                if (word.StartsWith(inPattern) && !word.Equals(inPattern))
                    return true;
            }
            return false;
        }
    }
}