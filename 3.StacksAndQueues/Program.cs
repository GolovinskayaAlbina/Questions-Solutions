using System;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new SetOfStacks<int>(3);
            for (int i=0;i<10;i++){
                stack.Push(i);
            }
             stack.PopAt(1);
             stack.PopAt(1);
             stack.PopAt(1);
            for (int i=0;i<7;i++){
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
