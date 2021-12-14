using Xunit;

namespace CodeChallenge.Test
{
    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("23", new[] { "AD", "AE", "AF", "BD", "BE", "BF", "CD", "CE", "CF" })]
        public void phoneNumber_GetPhoneMessage_ReturnRightValue(string number, string[] expectedData)
        {
            PhoneNumber phoneNumber = new();

            var result = phoneNumber.GetPhoneMessage(number);

            for (int i = 0; i < expectedData.Length; i++)
            {
                Assert.Equal(expectedData[i], result[i]);
            }
        }
    }
}