using System;

namespace StacksAndQueues
{
    class SetOfStacks<T>
    {
        readonly int _capacity;
        SetOfStacks<T> _previous;
        Node _head;
        int _count;
        
        public SetOfStacks(int capacity){
            _capacity = capacity;
        }

        public SetOfStacks(SetOfStacks<T> stack){
            _capacity = stack._capacity;
            _previous = stack._previous; 
            _count = stack._count;
            _head = stack._head;
        }

        public void Push(T value)
        {
            if (_count >= _capacity)
            {
                _previous = new SetOfStacks<T>(this);
                _count = 0;
                _head = null;               
            }
            var node = new Node(value);
            if (_head == null){
                _head = node;
            }
            else {
                node.Next = _head;
                _head = node;
            }
            _count++;
        }

        public T PopAt(int index)
        {
            if (index == 0)
            {
                return Pop();
            }
            SetOfStacks<T> cursor = _previous;
            while (index-- > 0){
                if (cursor._previous == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                cursor = cursor._previous;
            }
            return cursor.Pop();
        }
        
        public T Pop()
        {
           while (_count == 0){
               if (_previous == null)
               {
                   throw new ArgumentOutOfRangeException();
               }
                _count =  _previous._count;
                _head =  _previous._head;
                _previous = _previous._previous;
           }

           var value = _head.Value;
           _head = _head.Next;
           _count --;
           return value;
        }

        class Node{
            public Node(T value){
                Value = value;
            }
            public Node Next;
            public T Value;
        }
    }
}