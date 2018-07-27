using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class AnimalShelter
    {
        Queue<Dog> _dogs = new Queue<Dog>();
        Queue<Cat> _cats = new Queue<Cat>();
        private int _order = 0;
        public void Enqueue(Animal animal)
        {
            animal.Order = _order++;
            if (animal is Dog)
            {
                _dogs.Enqueue(animal as Dog);
            }
            else
            {
                _cats.Enqueue(animal as Cat);
            }
        }

        public Cat DequeueCat()
        {
            return _cats.Count > 0 ? _cats.Dequeue() : null;
        }

        public Dog DequeueDog()
        {
            return _dogs.Count > 0 ? _dogs.Dequeue() : null;
        }

        public Animal DequeueAny()
        {
            if (_cats.Count  == 0)
            {
                return DequeueDog();
            }
            if (_dogs.Count  == 0)
            {
                return DequeueCat();
            }

            var dogs = _dogs.Peek();
            var cats = _cats.Peek();

            return dogs.Order < cats.Order ? _dogs.Dequeue() as Animal: _cats.Dequeue() as Animal;
        }

    }

    class Dog : Animal{
        public Dog(string name):base(name){}
    }
    class Cat : Animal{
        public Cat(string name):base(name){}
    }
    public abstract class Animal
    {
        public int Order;
        public readonly string Name;
        public Animal(string name){
            Name = name;
        }
    }
}