using System;
using System.Linq;

namespace StackImplementation
{
    class StackMain
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<string>();
            stack.Push("ivane");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());

            stack.Push("Sralo");
            stack.Push("me4e");
            stack.Push("na");
            stack.Push("pute4e");
            Console.WriteLine(stack.Pop());
        }
    }
}