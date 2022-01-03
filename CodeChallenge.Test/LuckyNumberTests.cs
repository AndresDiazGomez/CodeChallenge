using Xunit;

namespace CodeChallenge.Test
{
    public class LuckyNumberTests
    {
        [Theory]
        [InlineData(new[] { 2, 2, 3, 3 }, 2)]
        [InlineData(new[] { 2, 2, 3, 3, 3, 4, 4 }, 3)]
        [InlineData(new[] { 1, 2, 3, 4 }, 1)]
        [InlineData(new[] { 2, 2, 2, 3, 3 }, -1)]
        public void LuckyNumber_GetLuckyNumber_ReturnTheLuckyNumber(int[] data, int expectedResult)
        {
            var result = LuckyNumber.GetLuckyNumber(data);

            Assert.Equal(expectedResult, result);
        }
    }
}