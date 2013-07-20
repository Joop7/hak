using System;
using System.Collections.Generic;
using System.Linq;

namespace WordzCheat.Models.Matrix
{
    public class MatrixElement
    {
        public string Value { get; private set; }
        public int Index { get; private set; }
        public int[] NeighborIndices { get; private set; }

        public MatrixElement(string inValue, int inIndex, int[] inNeighborIndices)
        {
            Value = inValue;
            Index = inIndex;
            NeighborIndices = inNeighborIndices;
        }
    }
}