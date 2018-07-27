using System;
using System.Collections.Generic;
using Xunit;
using StacksAndQueues;

namespace Solutions.Tests
{
    public class AnimalShelterTest
    {
        public static TheoryData<Animal[], string> DequeueCatTestData =>  
            new TheoryData<Animal[], string>
                {
                    {new Animal[]{new Dog("A"),new Cat("B"),new Dog("C"),new Dog("D")}, "B"},
                    {new Animal[]{new Dog("A"),new Cat("B"),new Cat("C"),new Dog("D")}, "B"},
                    {new Animal[]{new Cat("A")}, "A"},
                    {new Animal[]{new Dog("A"),new Dog("B"),new Dog("C"),new Cat("D")}, "D"},
                };
        
        [Theory, MemberData(nameof(DequeueCatTestData))]
        public void ReturnOldestCatFromShelter(Animal[] input, string expectedCatName)
        {
            var shelter = CreateAnimalShelterWithAnimals(input);
            var cat = shelter.DequeueCat();
            Assert.IsType<Cat>(cat);
            Assert.Equal(expectedCatName, cat.Name);
        }

        [Fact]
        public void ReturnNullWhenDequeueCatIfThereIsNoCatsInShelter()
        {
            var shelter = CreateAnimalShelterWithAnimals(new Animal[]{new Dog("A"),new Dog("B"),new Dog("C"),new Dog("D")});
            var cat = shelter.DequeueCat();
            Assert.Null(cat);
        }

        public static TheoryData<Animal[], string> DequeueDogTestData =>  
            new TheoryData<Animal[], string>
                {
                    {new Animal[]{new Dog("A"),new Cat("B"),new Dog("C"),new Dog("D")}, "A"},
                    {new Animal[]{new Cat("A"),new Cat("B"),new Cat("C"),new Dog("D")}, "D"},
                    {new Animal[]{new Dog("A")}, "A"},
                    {new Animal[]{new Cat("A"),new Dog("B"),new Cat("C"),new Cat("D")}, "B"},
                };
        
        [Theory, MemberData(nameof(DequeueDogTestData))]
        public void ReturnOldestDogFromShelter(Animal[] input, string expectedDogName)
        {
            var shelter = CreateAnimalShelterWithAnimals(input);
            var dog = shelter.DequeueDog();
            Assert.IsType<Dog>(dog);
            Assert.Equal(expectedDogName, dog.Name);
        }

        [Fact]
        public void ReturnNullWhenDequeueDogIfThereIsNoDogsInShelter()
        {
            var shelter = CreateAnimalShelterWithAnimals(new Animal[]{new Cat("A"),new Cat("B"),new Cat("C"),new Cat("D")});
            var dog = shelter.DequeueDog();
            Assert.Null(dog);
        }

        public static TheoryData<Animal[], Type> DequeueAnyTestData =>  
            new TheoryData<Animal[], Type>
                {
                    {new Animal[]{new Dog("A"),new Cat("B"),new Dog("C"),new Dog("D")}, typeof(Dog)},
                    {new Animal[]{new Cat("A"),new Cat("B"),new Cat("C"),new Dog("D")}, typeof(Cat)},
                    {new Animal[]{new Cat("A")}, typeof(Cat)},
                    {new Animal[]{new Dog("A")}, typeof(Dog)},
                    {new Animal[]{new Dog("A"),new Dog("B"),new Dog("C"),new Dog("D")}, typeof(Dog)},
                    {new Animal[]{new Cat("A"),new Cat("B"),new Cat("C"),new Cat("D")}, typeof(Cat)},
                };
        
        [Theory, MemberData(nameof(DequeueAnyTestData))]
        public void ReturnOldestAnimalFromShelter(Animal[] input, Type expectedAnimalType)
        {
            var shelter = CreateAnimalShelterWithAnimals(input);
            var animal = shelter.DequeueAny();
            Assert.IsType(expectedAnimalType, animal);
            Assert.Equal("A", animal.Name);
        }

        [Fact]
        public void ReturnNullWhenDequeueAnyItThereIsNoAnimalsInShelter()
        {
            var shelter = CreateAnimalShelterWithAnimals(new Animal[]{});
            var animal = shelter.DequeueAny();
            Assert.Null(animal);
        }

        private static AnimalShelter CreateAnimalShelterWithAnimals(Animal[] animals)
        {
            var shelter = new AnimalShelter();
            foreach (var animal in animals)
            {
                shelter.Enqueue(animal);
            }          
            return shelter;
        }
    }
}