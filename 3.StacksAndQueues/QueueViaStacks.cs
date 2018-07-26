using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class QueueViaStacks<T>
    {
        Stack<T> _mainStack = new Stack<T>();
        Stack<T> _additionalStack = new Stack<T>();

        public void Add(T item)
        {
             _mainStack.Push(item);
        }

        private static void Shift(Stack<T> source, Stack<T> destination)
        {
            while(source.Count > 0)
            {
                destination.Push(source.Pop());
            }
        }

        public T Peek()
        {
            if (_additionalStack.Count == 0)
            {
                Shift(_mainStack, _additionalStack);
            }        
            return _additionalStack.Peek();
        }

        public T Remove()
        {
           if (_additionalStack.Count == 0)
            {
                Shift(_mainStack, _additionalStack);
            }        
            return _additionalStack.Pop();
        }

        public int Count(){
            return _mainStack.Count + _additionalStack.Count;
        }
    }
}