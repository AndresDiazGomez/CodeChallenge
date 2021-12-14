using Xunit;

namespace CodeChallenge.Test
{
    public class MaximunProfitTests
    {
        [Theory]
        [InlineData(new[] { 10, 22, 5, 75, 65, 80 }, 87)]
        [InlineData(new[] { 2, 30, 15, 10, 8, 25, 80 }, 100)]
        [InlineData(new[] { 100, 30, 15, 10, 8, 25, 80 }, 72)]
        [InlineData(new[] { 90, 80, 70, 60, 50 }, 0)]
        public void MaximunProfit_GetMaximumProfit_ReturnTheMaxProfit(int[] data, int expectedResult)
        {
            var result = MaximunProfit.GetMaximumProfit(data);

            Assert.Equal(expectedResult, result);
        }

        //[Theory]
        //[InlineData(new[] { 10, 22, 5, 75, 65, 80 }, 2, 87)]
        //[InlineData(new[] { 12, 14, 17, 10, 14, 13, 12, 15 }, 3, 12)]
        //[InlineData(new[] { 100, 30, 15, 10, 8, 25, 80 }, 3, 72)]
        //[InlineData(new[] { 90, 80, 70, 60, 50 }, 1, 0)]
        //public void MaximunProfit_GetMaximumProfitWithTransactions_ReturnTheMaxProfit(int[] data, int transactions, int expectedResult)
        //{
        //    var result = MaximunProfit.GetMaximumProfit(data, transactions);

        //    Assert.Equal(expectedResult, result);
        //}
    }
}