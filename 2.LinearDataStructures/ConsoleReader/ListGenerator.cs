using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ListGenerator
    {
        const int RandomListLength = 100;
        const int RandomListMin = 0;
        const int RandomListMax = 15;

        private static readonly Random random;

        static ListGenerator()
        {
            random = new Random();
        }


        /// <summary>
        /// Will genarate 100 items long list of number 0 to 15
        /// </summary>
        /// <returns>list of random integers</returns>
        public static List<int> GetListIntegers()
        {
            var randomList = GetListIntegers(RandomListMin, RandomListMax, RandomListLength);
            return randomList;
        }

        /// <summary>
        /// Will genarate 100 items long list of number <paramref name="min"/> to <paramref name="max"/>
        /// </summary>        
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>list of random integers</returns>
        public static List<int> GetListIntegers(int min, int max)
        {
            var randomList = GetListIntegers(min, max, RandomListLength);

            return randomList;
        }

        /// <summary>
        /// Will genarate <paramref name="randomListLength"/> items long list of number <paramref name="min"/> to <paramref name="max"/>
        /// </summary>        
        /// <param name="min">Starting number - lowes</param>
        /// <param name="max">Ending number - highest</param>
        /// <param name="randomListLength">How many numbers to generate</param>
        /// <returns>list of random integers</returns>
        public static List<int> GetListIntegers(int min, int max, int randomListLength)
        {
            List<int> randomList = new List<int>();
            for (int i = 0; i < randomListLength; i++)
            {
                var next = random.Next(min, max);
                randomList.Add(next);
            }

            return randomList;
        }

    }
}
