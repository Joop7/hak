using System;
using System.Collections.Generic;
using System.Linq;
using WordzCheat.Models.Dictionaries;
using WordzCheat.Models.Exceptions;
using WordzCheat.Properties;

namespace WordzCheat.Models.Factories
{
    public enum Language
    {
        HR
    }
    public static class DictionaryFactory
    {
        public static IWordDictionary GetDictionary(Language inLanguage)
        {
            switch (inLanguage)
            {
                case Language.HR:
                    Dictionary<char, List<string>> wordsByFirstLetter = new Dictionary<char, List<string>>();
                    string[] delimiter = new string[] { "\r\n" };
                    string[] words = Resources.HRdict.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        if (!wordsByFirstLetter.Keys.Contains(word[0]))
                            wordsByFirstLetter.Add(word[0], new List<string>());

                        wordsByFirstLetter[word[0]].Add(word);
                    }
                    return new CroWordDictionary(wordsByFirstLetter);

                default:
                    throw new NoSuchDictionary();
            }
        }
    }
}