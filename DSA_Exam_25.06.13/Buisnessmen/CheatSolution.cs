using System;

namespace Buisnessmen
{
    public class HardcodedSolution
    {
        const string HardcodedSolutions = "1 2 5 14 42 132 429 1430 4862 16796 58786 208012 742900 2674440 9694845";

        static void Main()
        {
            var index = int.Parse(Console.ReadLine());
            var solutions = HardcodedSolutions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(solutions[index / 2 - 1]);
        }
    }
}
