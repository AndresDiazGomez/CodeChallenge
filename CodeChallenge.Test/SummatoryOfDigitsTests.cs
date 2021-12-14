using Xunit;

namespace CodeChallenge.Test
{
    public class SummatoryOfDigitsTests
    {
        [Theory]
        [InlineData(6, 6)]
        [InlineData(6, 123)]
        [InlineData(21, 687)]
        [InlineData(27, 999)]
        [InlineData(3, 12)]
        [InlineData(45, 123456789)]
        public void SummatoryOfDigits_GetSummatory_ReturnTheRightValue(int expectedNumber, int givenNumber)
        {
            Assert.Equal(expectedNumber, SummatoryOfDigits.GetSummatory(givenNumber));
        }

        [Theory]
        [InlineData(15, 5)]
        [InlineData(51, 12)]
        [InlineData(3331, 328)]
        public void SummatoryOfDigits_GetDigitSummatory_ReturnTheRightValue(int expectedNumber, int givenNumber)
        {
            Assert.Equal(expectedNumber, SummatoryOfDigits.GetDigitSummatory(givenNumber));
        }

        [Theory]
        [InlineData(1, 1234)]
        [InlineData(4, 5674)]
        public void SummatoryOfDigits_GetDigitSummatoryUntilOneDigit_ReturnTheRightValue(int expectedNumber, int givenNumber)
        {
            Assert.Equal(expectedNumber, SummatoryOfDigits.GetDigitSummatoryUntilOneDigit(givenNumber));
        }
    }
}