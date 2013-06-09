using System;
using System.Collections.Generic;

namespace HashedSetImplementation
{
    public class HashedSetImplementationMain
    {
        static void Main()
        {            
            var setTest = new HashedSetImplementation.HashedSet<string>();

            setTest.Add("Ivan");
            setTest.Add("Petkan");
            setTest.Add("Maira");
            setTest.Add("Grozdan");            
            Console.WriteLine("First set:");
            PrintOutSet(setTest);

            var setAnother = new HashedSetImplementation.HashedSet<string>();
            setAnother.Add("Ivan");
            setAnother.Add("Keira");
            Console.WriteLine("\nSecondSet:");
            PrintOutSet(setAnother);

            var intersect = setTest.Intersect(setAnother);
            Console.WriteLine("\nIntersect:");
            PrintOutSet(intersect);

            var union = setTest.Union(setAnother);
            Console.WriteLine("\nUnion:");
            PrintOutSet(union);
        }
  
        private static void PrintOutSet(HashedSet<string> setTest)
        {
            foreach (var item in setTest)
            {
                Console.WriteLine(item);
            }
        }


    }
}
