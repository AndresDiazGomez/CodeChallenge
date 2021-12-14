using Xunit;

namespace CodeChallenge.Test
{
    public class ParenthesesCombinationTests
    {
        [Fact]
        public void ParenthesesCombination_With_N0()
        {
            var result = ParenthesesCombination.GetAllCombinations(0);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ParenthesesCombination_With_N1()
        {
            var result = ParenthesesCombination.GetAllCombinations(1);

            Assert.Single(result);
            Assert.Equal("()", result[0]);
        }

        [Fact]
        public void ParenthesesCombination_With_N2()
        {
            var result = ParenthesesCombination.GetAllCombinations(2);

            Assert.Equal(2, result.Count);
            Assert.Equal("()()", result[0]);
            Assert.Equal("(())", result[1]);
        }

        [Fact]
        public void ParenthesesCombination_With_N3()
        {
            var result = ParenthesesCombination.GetAllCombinations(3);

            Assert.Equal(5, result.Count);
            Assert.Equal("()()()", result[0]);
            Assert.Equal("()(())", result[1]);
            Assert.Equal("(())()", result[2]);
            Assert.Equal("(()())", result[3]);
            Assert.Equal("((()))", result[4]);
        }
    }
}