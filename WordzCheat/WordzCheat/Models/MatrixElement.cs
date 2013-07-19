using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordzCheat.Models
{
    public abstract class MatrixElement
    {
        public abstract string Value { get; private set; }
        abstract MatrixElement[] _neighbors;

        public void ChekWordInDictionary(string inWord)
        {
            string word = inWord + this.Value;
        }
    }
}