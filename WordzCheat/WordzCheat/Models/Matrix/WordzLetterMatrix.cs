using System;
using System.Collections.Generic;
using System.Linq;
using WordzCheat.Models.Dictionaries;
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

        public override List<string> FindeWords(IWordDictionary inDictionary)
        {
            List<string> words = new List<string>();
            foreach (MatrixElement element in elements)
            {
                foreach (int neighborIndex in element.NeighborIndices)
                {
                    int[] startingLetterIndices = new int[] { element.Index, neighborIndex };
                    List<string> newWords = FindWordsRecursive(inDictionary, startingLetterIndices, words);
                    foreach (string newWord in newWords)
                        words.Add(newWord);
                }
            }
            return words;
        }

        #region private methods

        private List<string> FindWordsRecursive(IWordDictionary inDictionary, int[] inLetterIndices, List<string> words)
        {
            string word = GetWord(inLetterIndices);
            if (inDictionary.ContainsWord(word))
                words.Add(word);

            if (inDictionary.ContainsWordsStartingWithPattern(word))
            {
                foreach (int letterIndex in elements[inLetterIndices.Last()].NeighborIndices)
                {
                    List<string> newWords = FindWordsRecursive(inDictionary, CreateNewArray(inLetterIndices, letterIndex), words);
                    foreach (string newWord in newWords)
                        words.Add(newWord);
                }
            }

            return words;
        }

        private string GetWord(int[] inLetterIndices)
        {
            string word = "";
            foreach (int index in inLetterIndices)
                word += elements[index].Value;

            return word;
        }

        private int[] CreateNewArray(int[] inArray, int inNewElement)
        {
            int[] newArray = new int[inArray.Length + 1];
            
            inArray.CopyTo(newArray, 0);
            newArray[inArray.Length] = inNewElement;
            
            return newArray;
        }

        #endregion
    }
}