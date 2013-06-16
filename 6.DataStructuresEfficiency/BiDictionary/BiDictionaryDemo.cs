using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionaryImplementation
{
    /// <summary>
    /// Implement a class BiDictionary<K1,K2,T> that allows adding triples 
    /// {key1, key2, value} and fast search by key1, key2 or by 
    /// both key1 and key2. Note: multiple values can be stored for given key.
    /// </summary>
    class BiDictionaryDemo
    {
        static void Main()
        {
            var biDictionary = new BiDictionary<int, string, string>();

            biDictionary.Add(5, "Blagoevgrad", "Petkan");
            biDictionary.Add(5, "Sofia", "Ivan");
            biDictionary.Add(5, "Sofia", "Stamat");
            biDictionary.Add(55, "Varna", "Shisho bakshisho");
            biDictionary.Add(5, "Pleven", "Maria");
            biDictionary.Add(15, "Sofia", "Minka Svirkata");
            
            Console.WriteLine(@"biDictionary.Add(5, ""Blagoevgrad"", ""Petkan"");
biDictionary.Add(5, ""Sofia"", ""Ivan"");
biDictionary.Add(5, ""Sofia"", ""Stamat"");
biDictionary.Add(55, ""Varna"", ""Shisho bakshisho"");
biDictionary.Add(5, ""Pleven"", ""Maria"");
biDictionary.Add(15, ""Sofia"", ""Minka Svirkata"");
");
         
            var five = biDictionary.FindAllByFirstKey(5);
            PrintEnumerable(five, "biDictionary.FindAllByFirstKey(5)");
            
            var sofia = biDictionary.FindAllBySecondKey("Sofia");
            PrintEnumerable(sofia,"biDictionary.FindAllBySecondKey(\"Sofia\");" );

            var fiveSofia = biDictionary.FindAll(5, "Sofia");
            PrintEnumerable(fiveSofia,"biDictionary.FindAll(5, \"Sofia\")");
        }

        private static void PrintEnumerable(IEnumerable<string> enumerable, string message = "Enumerable printout")
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in enumerable)
            {
                result.AppendFormat("{0} ", item);
            }

            Console.WriteLine("{1}: {0}", result.ToString(), message);
        }
    }
}
