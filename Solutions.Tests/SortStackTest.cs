using System;
using System.Collections.Generic;
using Xunit;
using StacksAndQueues;

namespace Solutions.Tests
{
    public class SortStackTest
    {
        public static TheoryData<Stack<int>,Stack<int>> SortingTestData =>  
            new TheoryData<Stack<int>,Stack<int>>
                {
                    { new Stack<int>(new[]{7,1,3,4,6}), new Stack<int>(new[]{7,6,4,3,1})},
                    { new Stack<int>(new[]{7}), new Stack<int>(new[]{7})},
                    { new Stack<int>(), new Stack<int>()},
                    { new Stack<int>(new[]{-1,1}), new Stack<int>(new[]{1,-1})},
                    { new Stack<int>(new[]{1,1,3,3,7}), new Stack<int>(new[]{7,3,3,1,1})}
                };
        
        [Theory, MemberData(nameof(SortingTestData))]
        public void ReturnSortedStack(Stack<int> input, Stack<int> expected)
        {
            var actual = SortStack.Sort(input);
            Assert.Equal(expected, actual);
        }
    }
}