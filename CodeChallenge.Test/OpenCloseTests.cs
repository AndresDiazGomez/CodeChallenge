using Xunit;

namespace CodeChallenge.Test
{
    public class OpenCloseTests
    {
        [Theory]
        [InlineData(null!, false)]
        [InlineData("", false)]
        [InlineData("a", false)]
        [InlineData("(", false)]
        [InlineData("()", true)]
        [InlineData("(]", false)]
        [InlineData("()]", false)]
        [InlineData("()()()()[][][]{}{}", true)]
        [InlineData("((((((([[[[[)", false)]
        [InlineData("([}]){", false)]
        [InlineData("([{}])", true)]
        [InlineData("(((())))", true)]
        [InlineData("((({))))", false)]
        [InlineData("[()]{}{[()()]()}", true)]
        public void OpenClose_IsRight_ReturnTheRightValue(string? value, bool expected)
        {
            Assert.Equal(expected, OpenClose.MeetOpenClose(value!));
        }
    }
}