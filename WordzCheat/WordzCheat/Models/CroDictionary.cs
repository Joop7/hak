using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordzCheat.Models
{
    public class CroDictionary : WordDictionary
    {
        protected 

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