using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    /// <summary>
    /// http://bgcoder.com/Contest/Practice/17
    /// </summary>

    class Program
    {
        static void Main()
        {
            //var changes = new int[] { 5, 2, 8, 4 };// ReadChanges();
            //var initial = 8;// int.Parse(Console.ReadLine());
            //var max = 20;// int.Parse(Console.ReadLine());
            var changes =  ReadChanges();
            var initial = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());


            var steps = new bool[changes.Length + 2, max + 1];
            steps[0, initial] = true;
            //var initialMinus = initial - changes[0];
            //var initialPlus = initial + changes[0];
           
            for (int i = 0; i < steps.GetLength(0); i++)
            {
                for (int j = 0; j < steps.GetLength(1); j++)
                {
                    if (i == changes.Length)
                    {
                        bool found = false;
                        for (int k = steps.GetLength(1) - 1; k >= 0; k--)
                        {
                            if (steps[i, k])
                            {
                                Console.WriteLine(k);
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine(-1);                            
                        }
                        
                        break;
                    }
                    
                    if (steps[i,j])
                    {
                        var minus = j - changes[i];    
                        if (minus >= 0 && minus <= max)
	                    {
                            steps[i + 1, minus] = true; 
	                    }

                        var plus = j + changes[i];
                        if (plus >= 0 && plus <= max)
                        {
                            steps[i + 1, plus] = true;
                        }                           
                    }
                }

                
            }           
        }

        private static int[] ReadChanges()
        {
            var changeStrings = Console.ReadLine().Split(new char[] { ' ', ',' }, 
                StringSplitOptions.RemoveEmptyEntries);
            
            var changes = new int[changeStrings.Length];

            for (int i = 0; i < changeStrings.Length; i++)
            {
                changes[i] = int.Parse(changeStrings[i]);
            }

            return changes;
        }
    }
}
