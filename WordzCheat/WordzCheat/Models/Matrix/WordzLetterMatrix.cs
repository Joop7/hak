using System;
using System.Collections.Generic;
using System.Linq;
using WordzCheat.Models.Exceptions;
using WordzCheat.Models.Factories;

namespace WordzCheat.Models.Matrix
{
    public class WordzLetterMatrix : LetterMatrix
    {
        const int MATRIX_SIZE = 4;

        public WordzLetterMatrix(string[] inLetters)
        {
            if (inLetters.Length < MATRIX_SIZE * MATRIX_SIZE)
                throw new WrongNumberOfElements();
            else
                elements = MatrixElementsFactory.GetElements(MATRIX_SIZE, inLetters);
        }

        public List<string> FindWords(List<string> inDictionary)
        {
            List<string> words = new List<string>();

            foreach (string word in inDictionary)
            {
                if (IsInMatrix(word))
                    words.Add(word);
            }

            return words;
        }

        #region private methods
        
        private bool IsInMatrix(string word)
        {
            List<List<int>> possibleIndexSequence = new List<List<int>>();
            foreach (char letter in word)
            {
                List<MatrixElement> possibleElements = elements.FindAll(item => item.Value.Equals(letter.ToString()));
                if (possibleElements.Count == 0)
                    return false;

                if (possibleIndexSequence.Count == 0)
                {
                    foreach (MatrixElement element in possibleElements)
                    {
                        List<int> newIndexSequence = new List<int>() { element.Index };
                        possibleIndexSequence.Add(newIndexSequence);
                    }
                }
                else
                {
                    List<List<int>> newPossibleIndexSequence = new List<List<int>>();

                    foreach (MatrixElement element in possibleElements)
                    {
                        foreach (List<int> indexSequence in possibleIndexSequence)
                        {
                            if (!indexSequence.Contains(element.Index))
                            {
                                List<int> newIndexSequence = indexSequence.ToList();
                                newIndexSequence.Add(element.Index);
                                newPossibleIndexSequence.Add(newIndexSequence);
                            }
                        }
                    }

                    if (newPossibleIndexSequence.Count == 0)
                        return false;
                    else
                        possibleIndexSequence = newPossibleIndexSequence;
                }
            }

            foreach (List<int> indices in possibleIndexSequence)
            {
                if (IndexSequenceExists(indices))
                    return true;
            }

            return false;
        }

        private bool IndexSequenceExists(List<int> inIndexSequence)
        {
            List<int> previusElementNeigbors = new List<int>();
            foreach (int index in inIndexSequence)
            {
                if ((previusElementNeigbors.Count != 0) && !previusElementNeigbors.Contains(index))
                    return false;

                previusElementNeigbors = elements[index].NeighborIndices.ToList();
            }
            return true;
        }

        #endregion
    }
}