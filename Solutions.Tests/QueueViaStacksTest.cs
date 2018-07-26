using System;
using Xunit;
using StacksAndQueues;

namespace Solutions.Tests
{
    public class QueueViaStacksTest
    {
        public static TheoryData<int[]> OrderingTestData =>  
            new TheoryData<int[]>
                {
                    { new[]{1,2,3,4,5,6}},
                    { new[]{1} }
                };
        
        [Theory, MemberData(nameof(OrderingTestData))]
        public void ReturnValuesInFIFOOrdering(int[] input)
        {
            QueueViaStacks<int> queue = CreateQueueViaStacksFromArray(input);

            CollectionsEqual(input, queue);
        }

        [Fact]
        public void ReturnValuesInFIFOOrderingAfterModifications()
        {
            QueueViaStacks<int> queue = CreateQueueViaStacksFromArray(new []{9,6,1,2});
            Assert.Equal(9, queue.Peek());
            Assert.Equal(9, queue.Remove());
            Assert.Equal(6, queue.Remove());
            queue.Add(3);
            queue.Add(4);
            CollectionsEqual(new []{1,2,3,4}, queue);
        }  

        private static void CollectionsEqual(int[] expected, QueueViaStacks<int> actual)
        {
            Assert.Equal(expected.Length, actual.Count());
            foreach (var item in expected)
            {
                Assert.Equal(item, actual.Remove());      
            }
        }

        private static QueueViaStacks<int> CreateQueueViaStacksFromArray(int[] input) 
        {
            QueueViaStacks<int> queue = new QueueViaStacks<int>();
            foreach (var item in input)
            {
                queue.Add(item);        
            }
            return queue;
        }
    }
}