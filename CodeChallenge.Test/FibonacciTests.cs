using Xunit;

namespace CodeChallenge.Test
{
    public class FibonacciTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(5, 5)]
        [InlineData(9, 34)]
        public void Fibonacci_GetFibonacciNumber_ReturnTheFibonacciNumber(int targetIndex, int expectedResult)
        {
            var result = Fibonacci.GetFibonacciNumber(targetIndex);

            Assert.Equal(expectedResult, result);
        }
    }
}