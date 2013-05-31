using System;
using Utils;

namespace SumAndAverageOfIntegers
{
    /// <summary>
    /// 1.Write a program that reads from the console a sequence of positive integer numbers. 
    ///The sequence ends when empty line is entered. Calculate and print the
    ///sum and average of the elements of the sequence. Keep the sequence in List<int>.
    /// 2.Write a program that reads N integers from the console and reverses them using a 
    /// stack. Use the Stack<int> class
    /// 3.Write a program that reads a sequence of integers (List<int>) ending with an 
    ///empty line and sorts them in an increasing order.
    /// </summary>
    class SumAverageSortingMain
    {
        private static void Main(string[] args)
        {
            ConsoleIntegerReader reader = new ConsoleIntegerReader();
            var list = reader.ReadIntegers();
            if (list.Count == 0)
            {
                Console.WriteLine("Empty list!");
            }
            else
            {
                int sum = Utilities.Sum(list);
                double average = (double)sum / list.Count;

                Console.WriteLine("Sum is: {0}, Average: {1:f2}", sum, average);

                Utilities.PrintSorted(list);

                var stack = Utilities.PutInStack(list);
                Utilities.PrintFromStack(stack);
            }
        }
    }
}