using System;
using System.Collections.Generic;

namespace WordzCheat.Models.Matrix
{
    public abstract class LetterMatrix
    {
        protected List<MatrixElement> elements;

        public abstract List<string> FindWords(List<string> inDictionary);
    }
}