using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WordzCheat.Models
{
    public class WordDictionary
    {
        string[] _words;

        public WordDictionary(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _words = reader.ReadToEnd().Split('\n');
            }
        }

        public bool ContainsWord(string inWord)
        {
            return _words.Contains(inWord);
        }

        public bool ContainsPatternInWords(string pattern)
        {
            foreach (string word in _words)
            {
                if (word.Contains(pattern))
                    return true;
            }
            return false;
        }
    }
}