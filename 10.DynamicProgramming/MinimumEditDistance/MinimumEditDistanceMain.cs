using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    public class MinimumEditDistanceMain
    {
        const double Replace = 1.0;
        const double Delete = 0.9;
        const double Insert = 0.8;
        
        // works for two words of length differecne of 1
        static void Main()
        {
            //var originalWord = "developer"; // "duma";
            //var editedWord = "enveloped"; // "uma";
            //var originalWord =  "dbbk";
            //var editedWord =  "baba";
            var originalWord = "kosmonavt";//qq
            var editedWord = "pisatelqt";

            var med = FindMED(editedWord, originalWord);
        }
  
        private static double FindMED(string editedWord, string originalWord)
        {
            var medMatrix = new double[editedWord.Length + 1, originalWord.Length + 1];

            FillBaseCases(originalWord, medMatrix, Delete, editedWord, Insert);

            for (int editedWordIndex = 1; editedWordIndex < medMatrix.GetLength(0); editedWordIndex++)
            {
                for (int originalWordIndex = 1; originalWordIndex < medMatrix.GetLength(1); originalWordIndex++)
                {
                    var originalChar = originalWord[originalWordIndex - 1];
                    var editedChar = editedWord[editedWordIndex - 1];
                    var actionCost = 0.0;

                    if (originalChar != editedChar)
                    {
                        // in the cell M,N we'll have the solution of problem from 
                        //string with length N to string with length M
                        // and we take the char N (n - 1) from original 
                        //string and compare it to char M (m-1) in desired string
                        // if chars are different  we check to see where is the
                        //best solution of least problem
                        // if it's in the upper cell - solution from string M to 
                        //edited N - 1 so we insert the 1 char left
                        // upper - left cell - solution of problem form M - 1 to
                        //N - 1 so we replace the char to get to that problem
                        // left - solution of M - 1 to N so we delete the extra 
                        //char to get that solution
                        Cells cell = Cells.Up;

                        var minOfThreeCells =
                            GetMinActionCost(editedWordIndex, originalWordIndex, medMatrix, out cell);

                        if (cell == Cells.Up)
                        {
                            actionCost = Insert;
                        }
                        if (cell == Cells.UpLeft)
                        {
                            actionCost = Replace;
                        }
                        if (cell == Cells.Left)
                        {
                            actionCost = Delete;
                        }

                        medMatrix[editedWordIndex, originalWordIndex] = actionCost + minOfThreeCells;
                    }
                    // the chars are the same so we take the uper left solution 
                    // because we wond use that char like dum -> umm 
                    // when we reach last m we see they are same so we take m
                    // and we have du->um which is the solution of the problem from upper left cell
                    // so in here 
                    else
                    {
                        medMatrix[editedWordIndex, originalWordIndex] =
                            medMatrix[editedWordIndex - 1, originalWordIndex - 1];
                    }
                }
            }

            PrintMEDMatrix(originalWord, medMatrix, editedWord);

            var result = medMatrix[medMatrix.GetLength(0) - 1, medMatrix.GetLength(1) - 1];
            Console.WriteLine("Minimum Edit Distance between {0} and {1} is {2}",
                originalWord, editedWord, result);

            return result;
        }  
       
        private static double GetMinActionCost(int row, int col, 
            double[,] medMatrix, out Cells fromWhichCell)
        {
            var min = medMatrix[row - 1, col];
            fromWhichCell = Cells.Up;
            
            if (medMatrix[row - 1, col - 1] < min)
            {
                min = medMatrix[row - 1, col - 1];
                fromWhichCell = Cells.UpLeft;
            }

            if (medMatrix[row, col - 1] < min)
            {
                min = medMatrix[row, col - 1];
                fromWhichCell = Cells.Left;
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

    public enum Cells
    {
        Up = 1,
        UpLeft = 2,
        Left = 3
    }
}
