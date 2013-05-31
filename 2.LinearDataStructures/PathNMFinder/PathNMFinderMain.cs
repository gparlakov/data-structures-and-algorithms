using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace PathNMFinder
{
    public class PathNMFinderMain
    {
        public static void Main()
        {
            int n;
            int m;
            ReadNM(out n, out m);

            var path = FindFirstShortesPath(n, m);

            Console.WriteLine(path);
        }

        private static string FindFirstShortesPath(int n, int m)
        {
            Queue<ValuePathPair> steps = new Queue<ValuePathPair>();
            steps.Enqueue(new ValuePathPair(n));
            var current = steps.Dequeue();
            while(current.Value != m)
            {
                AddNextThree(current, steps);
                current = steps.Dequeue();
            }

            var shortestPath = current.PathToHere;
            return shortestPath;
        }

        private static void AddNextThree(ValuePathPair current, Queue<ValuePathPair> steps)
        {
            var nPlusOne = current.Value + 1;
            var nPlusTwo = current.Value + 2;
            var nTimesTwo = current.Value * 2;
            var pathToHere = current.PathToHere;

            steps.Enqueue(new ValuePathPair(nPlusOne, pathToHere));
            steps.Enqueue(new ValuePathPair(nPlusTwo, pathToHere));
            steps.Enqueue(new ValuePathPair(nTimesTwo, pathToHere));
            
        }

        private static void ReadNM(out int n, out int m)
        {
            n = Utilities.ReadIntegerInput("n ");
            m = n - 1;
            do
            {
                m = Utilities.ReadIntegerInput("m -> (m > n)");
            } while (m < n);
        }
    }
}
