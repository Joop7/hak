using System;
using System.Collections.Generic;
using System.IO;

namespace WordzCheat.Models.Dictionaries
{
    public interface IWordDictionary
    {
        bool ContainsWord(string inWord);
        bool ContainsWordsStartingWithPattern(string inPattern);
    }
}