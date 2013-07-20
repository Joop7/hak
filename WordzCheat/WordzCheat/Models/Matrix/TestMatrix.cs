using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordzCheat.Models.Exceptions;
using WordzCheat.Models.Factories;

namespace WordzCheat.Models.Matrix
{
    public class TestMatrix
    {
        const int MATRIX_SIZE = 4;
        private List<MatrixElement> _elements;

        public TestMatrix(string[] inLetters)
        {
            if (inLetters.Length < MATRIX_SIZE * MATRIX_SIZE)
                throw new WrongNumberOfElements();
            else
                _elements = MatrixElementsFactory.GetElements(MATRIX_SIZE, inLetters);
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

        private bool IsInMatrix(string word)
        {
            List<List<int>> possibleIndexSequence = new List<List<int>>();
            foreach (char letter in word)
            {
                List<MatrixElement> possibleElements = _elements.FindAll(item => item.Value.Equals(letter.ToString()));
                if (possibleElements.Count == 0)
                    return false;

                foreach (MatrixElement element in possibleElements)
                {
                    if (possibleIndexSequence.Count == 0)
                    {
                        List<int> newIndexSequence = new List<int>();
                        newIndexSequence.Add(element.Index);
                        possibleIndexSequence.Add(newIndexSequence);
                    }
                    else
                    {
                        for (int i = 0; i < possibleIndexSequence.Count; i++)
                        {
                            possibleIndexSequence[i].Add(element.Index);
                        }
                    }
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
                if (previusElementNeigbors.Count != 0)
                {
                    if (!previusElementNeigbors.Contains(index))
                        return false;
                }

                previusElementNeigbors = _elements[index].NeighborIndices.ToList();
            }
            return true;
        }
    }
}