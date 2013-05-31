using System;
using System.Collections.Generic;
using Utils;

//using System.Linq;
namespace PrintMembersOfComplexSequence
{
    class PrintMembersOfComplexSequenceMain
    {
        const int MembersToPrintCount = 50;

        static void Main(string[] args)
        {
            int n = Utilities.ReadIntegerInput("n");
            CalculateMembers(n, MembersToPrintCount);
        }

        private static IEnumerable<int> CalculateMembers(int firstMember, int count)
        { 
            Queue<int> queueOfMembers = new Queue<int>();
            queueOfMembers.Enqueue(firstMember);

            List<int> members = new List<int>();
            members.Add(firstMember);

            while (members.Count < count)
            {
                int nextQueued = queueOfMembers.Dequeue();
                int[] nextThree = GetNextThree(nextQueued);

                members.AddRange(nextThree);

                queueOfMembers.Enqueue(nextThree[0]);
                queueOfMembers.Enqueue(nextThree[1]);
                queueOfMembers.Enqueue(nextThree[2]);
            }

            return members;
        }

        /// <summary>
        /// Calculates next Three members by given num: 
        /// { number + 1, 2 * number + 1, number + 2 } 
        /// </summary>
        /// <param name="number">Starting point</param>
        /// <returns>array of calculated next three </returns>
        private static int[] GetNextThree(int number)
        {
            int[] nextThree = new int[3];

            nextThree[0] = number + 1;
            nextThree[1] = 2 * number + 1;
            nextThree[2] = number + 2;

            return nextThree;
        }
    }
}