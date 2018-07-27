using System;
using System.Collections.Generic;
namespace StacksAndQueues
{
    class SortStack
    {
        public static Stack<T> Sort<T>(Stack<T> stack) where T: IComparable
        {
            Stack<T> additional = new Stack<T>();
            while(stack.Count > 0)
            {
                var stackTop = stack.Pop();
                while(additional.Count > 0 &&  additional.Peek().CompareTo(stackTop) < 0)
                {
                    stack.Push(additional.Pop());
                }
                additional.Push(stackTop);
            }
            return additional;
        }
    }
}