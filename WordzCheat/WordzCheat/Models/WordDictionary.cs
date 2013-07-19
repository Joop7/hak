using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WordzCheat.Models
{
    public abstract class WordDictionary
    {

        protected abstract Dictionary<string, string[]> _wordsByFirstLetter {get;}


        public WordDictionary(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var lines = reader.ReadToEnd();
                
            }
        }
    }
}