using Xunit;

namespace CodeChallenge.Test
{
    public class NextGreatElementTests
    {
        [Fact]
        public void NextGreatElement_GetNextGreatElement_ReturnTheRightValue()
        {
            var inputArray = new[] { 4, 5, 2, 25 };

            var result = NextGreatElement.GetNextGreatElement(inputArray);

            Assert.Collection(result, 
                element => Assert.Equal(5, element.Value),
                element => Assert.Equal(25, element.Value),
                element => Assert.Equal(25, element.Value),
                element => Assert.Equal(-1, element.Value));
        }

        [Fact]
        public void NextGreatElement_GetNextGreatElement_ReturnTheRightValue_Case2()
        {
            var inputArray = new[] { 13, 7, 6, 12 };

            var result = NextGreatElement.GetNextGreatElement(inputArray);

            Assert.Collection(result,
                element => Assert.Equal(-1, element.Value),
                element => Assert.Equal(12, element.Value),
                element => Assert.Equal(12, element.Value),
                element => Assert.Equal(-1, element.Value));
        }
    }
}