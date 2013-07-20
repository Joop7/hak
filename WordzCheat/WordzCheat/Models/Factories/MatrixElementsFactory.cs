using System;
using System.Collections.Generic;
using WordzCheat.Models.Matrix;
using WordzCheat.Models.Exceptions;

namespace WordzCheat.Models.Factories
{
    public static class MatrixElementsFactory
    {
        public static List<MatrixElement> GetElements(int inMatrixSize, string[] inElementValues)
        {
            switch (inMatrixSize) 
            {
                case 4:
                    int[][] listsOfNeighborIndices = new int[][]
                    {
                        new int[]{1,4,5},
                        new int[]{0,2,4,5,6},
                        new int[]{1,3,5,6,7},
                        new int[]{2,6,7},
                        new int[]{0,1,5,8,9},
                        new int[]{0,1,2,4,6,8,9,10},
                        new int[]{1,2,3,5,7,9,10,11},
                        new int[]{2,3,6,10,11},
                        new int[]{4,5,9,12,13},
                        new int[]{4,5,6,8,10,12,13,14},
                        new int[]{5,6,7,9,11,13,14,15},
                        new int[]{6,7,10,14,15},
                        new int[]{8,9,13},
                        new int[]{8,9,10,12,14},
                        new int[]{9,10,11,13,15},
                        new int[]{10,11,14}
                    };
                    
                    List<MatrixElement> elements = new List<MatrixElement>();
                    for(int elementIndex = 0; elementIndex < inMatrixSize*inMatrixSize; elementIndex++)
                        elements.Add(new MatrixElement(inElementValues[elementIndex], elementIndex, listsOfNeighborIndices[elementIndex]));

                    return elements;
                
                default:
                    throw new NoElementsDefined();
            }
        }
    }
}