using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{

    public class MinimumEditDistanceMain
    {
        static void Main()
        {
            var replace = 1.0;
            var delete = 0.9;
            var insert = 0.8;

            var originalWord = "developer"; // "duma";
            var editedWord = "enveloped"; // "uma";
            
            //var originalWord =  "duma";
            //var editedWord =  "umak";

            //var originalWord = "rqpa";
            //var editedWord = "baba";

            var medMatrix = new double[editedWord.Length + 1, originalWord.Length + 1];

            FillBaseCases(originalWord, medMatrix, delete, editedWord, insert);

            for (int editedWordIndex = 1; editedWordIndex < medMatrix.GetLength(0); editedWordIndex++)
            {
                for (int originalWordIndex = 1; originalWordIndex < medMatrix.GetLength(1); originalWordIndex++)
                {
                    var originalChar = originalWord[originalWordIndex - 1];
                    var editedChar = editedWord[editedWordIndex - 1];
                    var actionCost = 0.0;

                    // case where edited word (sofar)is shorter from original
                    // action = delete or nothing if chars are same
                    if (editedWordIndex < originalWordIndex)
                    {
                        if (originalChar != editedChar)
                        {
                            actionCost = delete;
                        }
                    }

                    // case wher edited word (sofar) is longer than original 
                    // action = replace or nothing if chars are same
                    else //if (editedWordIndex > originalWordIndex)
                    {
                        if (originalChar != editedChar)
                        {
                            actionCost = replace;
                        }
                    }

                    var minOfThreeCells = GetMinActionCost(editedWordIndex, originalWordIndex, medMatrix);

                    medMatrix[editedWordIndex, originalWordIndex] = actionCost + minOfThreeCells;
                }
            }

            PrintMEDMatrix(originalWord, medMatrix, editedWord);

            Console.WriteLine("Minimum Edit Distance between {0} and {1} is {2}",
                originalWord, editedWord, medMatrix[medMatrix.GetLength(0) - 1, medMatrix.GetLength(1) - 1]);
        }

        private static double GetMinActionCost(int row, int col, double[,] medMatrix)
        {
            var min = medMatrix[row - 1, col];
            
            if (medMatrix[row - 1, col - 1] < min)
            {
                min = medMatrix[row - 1, col - 1];
            }

            if (medMatrix[row, col - 1] < min)
            {
                min = medMatrix[row, col - 1];
            }

            return min;
        }
  
        private static void FillBaseCases(string originalWord, double[,] medMatrix, double delete, string editedWord, double insert)
        {
            for (int i = 1; i <= originalWord.Length; i++)
            {
                medMatrix[0, i] = medMatrix[0, i - 1] + delete;
            }

            for (int i = 1; i <= editedWord.Length; i++)
            {
                medMatrix[i, 0] = medMatrix[i - 1, 0] + insert;
            }
        }
  
        private static void PrintMEDMatrix(string originalWord, double[,] medMatrix, string editedWord)
        {
            Console.Write("{0,8}", '_'); 
            for (int i = 0; i < originalWord.Length; i++)
            {
                Console.Write("{0,4}", originalWord[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < medMatrix.GetLength(0); i++)
            {
                if (i > 0)
                {
                    Console.Write("{0,4}", editedWord[i - 1]);
                }
                else
                {
                    Console.Write("{0,4}", '_');
                }
                for (int j = 0; j < medMatrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", medMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
