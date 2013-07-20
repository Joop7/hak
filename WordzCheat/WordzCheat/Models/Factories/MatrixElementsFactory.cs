using System;
using System.Collections.Generic;
using WordzCheat.Models.Matrix;
using WordzCheat.Models.Exceptions;

namespace WordzCheat.Models.Factories
{
    public static class MatrixElementsFactory
    {
        public static List<MatrixElement> GetElements(int inMatrixSize, string[] inElements)
        {
            switch (inMatrixSize) 
            {
                case 4:
                    int[][] neighborIndicesLists = new int[][]
                    {
                        new int[]{2,5,6},
                        new int[]{1,3,5,6,7},
                        new int[]{2,4,6,7,8},
                        new int[]{3,7,8},
                        new int[]{1,2,6,9,10},
                        new int[]{1,2,3,5,7,9,10,11},
                        new int[]{2,3,4,6,8,10,11,12},
                        new int[]{3,4,7,11,12},
                        new int[]{5,6,10,13,14},
                        new int[]{5,6,7,9,11,13,14,15},
                        new int[]{6,7,8,10,12,14,15,16},
                        new int[]{7,8,11,15,16},
                        new int[]{9,10,14},
                        new int[]{9,10,11,13,15},
                        new int[]{10,11,12,14,16},
                        new int[]{11,12,15}
                    };
                    
                    List<MatrixElement> elements = new List<MatrixElement>();
                    for(int elementIndex = 1; elementIndex <= inMatrixSize*inMatrixSize; elementIndex++)
                        elements.Add(new MatrixElement(inElements[elementIndex - 1], elementIndex, neighborIndicesLists[elementIndex - 1]));

                    return elements;
                
                default:
                    throw new NoElementsDefined();
            }
        }
    }
}