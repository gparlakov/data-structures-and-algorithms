using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTableMain
    {
        static void Main(string[] args)
        {
            var hashTest = new HashTableMy<string, int>();
            hashTest.Add("Joro", 5);
            hashTest.Add("Joro", 35);
            hashTest.Add("Joro", 45);
            hashTest.Add("Joro", 15);
            hashTest.Add("Joro", 5);
            hashTest.Add("Joro", 35);
            hashTest.Add("Joro", 45);
            hashTest.Add("Joro", 15);
            hashTest.Add("Joro", 5);
            hashTest.Add("Joro", 35);
            hashTest.Add("Joro", 45);
            hashTest.Add("Joro", 15);

            hashTest.Remove("Joro");
            int joroValue = 0;
            Console.WriteLine("hashTest.Find(\"Joro\") \nis found = {0} \nvalue = {1}  //Finds last added\n", hashTest.Find("Joro", out joroValue), joroValue);

            hashTest.Add("Ivan", 5);

            hashTest.Add("Petkan", 5);

            Console.WriteLine("Foreach all elements:");
            foreach (var item in hashTest)
            {
                Console.WriteLine(item);
            }

            hashTest.Add("Joro", 35);
            hashTest.Add("Joro", 45);
            hashTest.Add("Joro", 15);
            Console.WriteLine(hashTest["Petkan"]);
            
            Console.WriteLine();
            var keys = hashTest.Keys();
            Console.WriteLine("All Keys:");
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine();
            for (int i = 0; i < hashTest.Count; i++)
            {
                Console.WriteLine("hashTest[{1}] = {0}", hashTest[i], i);
            }                        
        }
    }
}
