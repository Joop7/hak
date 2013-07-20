using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordzCheat.Models.Dictionaries;

namespace WordzCheat.Models.Matrix
{
    public abstract class LetterMatrix
    {
        protected List<MatrixElement> elements;

        public abstract List<string> FindeWords(IWordDictionary inDictionary);
    }
}