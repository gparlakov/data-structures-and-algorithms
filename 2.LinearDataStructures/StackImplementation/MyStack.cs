using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    /// <summary>
    /// Implement the ADT stack as auto-resizable array.
    /// Resize the capacity on demand(when no space is available to 
    /// add / insert a new element).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>
    {
        private const int FirstCurrentIndex = -1;
        private const int StartingSizeOfArray = 1;

        private T[] stackElements;
        private int currentElem;

        public MyStack()
        {
            this.stackElements = new T[StartingSizeOfArray];
            this.currentElem = FirstCurrentIndex;
        }

        public MyStack(int startingSize)
        {
            this.stackElements = new T[startingSize];
            this.currentElem = FirstCurrentIndex;
        }

        public void Push(T element)
        {
            currentElem++;
            if (this.currentElem == this.stackElements.Length - 1)
            {
                DoubleSizeOfArray();
            }
            this.stackElements[currentElem] = element;
        }

        public T Peek()
        {
            if (currentElem < 0)
            {
                throw new ArgumentException("The stack is empty");
            }
            T result = this.stackElements[currentElem];
            return result;
        }

        public T Pop()
        {
            if (currentElem < 0)
            {
                throw new ArgumentException("The stack is empty");
            }
            T result = this.stackElements[currentElem];
            currentElem--;
            return result;
        }

        private void DoubleSizeOfArray()
        {
            T[] newStackElementsArray = new T[this.stackElements.Length * 2];
            this.stackElements.CopyTo(newStackElementsArray, 0);
            this.stackElements = newStackElementsArray;
        }
    }
}
