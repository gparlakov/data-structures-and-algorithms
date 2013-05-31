using System;
using System.Linq;

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
            this.currentElem++;
            if (this.currentElem == this.stackElements.Length - 1)
            {
                this.DoubleSizeOfArray();
            }
            this.stackElements[this.currentElem] = element;
        }

        public T Peek()
        {
            if (this.currentElem < 0)
            {
                throw new ArgumentException("The stack is empty");
            }
            T result = this.stackElements[this.currentElem];
            return result;
        }

        public T Pop()
        {
            if (this.currentElem < 0)
            {
                throw new ArgumentException("The stack is empty");
            }
            T result = this.stackElements[this.currentElem];
            this.currentElem--;
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