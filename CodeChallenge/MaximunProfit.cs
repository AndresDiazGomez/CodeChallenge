namespace CodeChallenge
{
    public static class MaximunProfit
    {
        /// <summary>
        /// Maximum profit by buying and selling a share at most twice.
        /// In daily share trading, a buyer buys shares in the morning and sells them on the same day.
        /// If the trader is allowed to make at most 2 transactions in a day, whereas the second transaction can only start after the first one is complete (Buy->sell->Buy->sell). 
        /// Given stock prices throughout the day, find out the maximum profit that a share trader could have made.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetMaximumProfit(IList<int> input)
        {
            if (input.Count < 4)
            {
                throw new ArgumentException("Input lenght are not longer enough to calculate the value", nameof(input));
            }
            int max = 0;
            for (int i = 0; i < input.Count - 2; i++)
            {
                int leftDelta = GetMaxDelta(input.Take(i + 2).ToList());
                int rightDelta = GetMaxDelta(input.Skip(i + 2).ToList());
                int totalDelta = leftDelta + rightDelta;
                if (totalDelta > max)
                {
                    max = totalDelta;
                }
            }
            return max;
        }

        //public static int GetMaximumProfit(IList<int> input, int transactions)
        //{
        //    int transactionsTimesTwo = transactions * 2;
        //    if (input.Count < transactionsTimesTwo)
        //    {
        //        throw new ArgumentException("Input lenght are not longer enough to calculate the value", nameof(input));
        //    }
        //    int max = 0;
        //    for (int i = 0; i < input.Count - transactionsTimesTwo; i++)
        //    {
        //        int leftDelta = GetMaxDelta(input.Take(i + 2).ToList());
        //        int rightDelta = GetMaxDelta(input.Skip(i + 2).ToList());
        //        int totalDelta = leftDelta + rightDelta;
        //        if (totalDelta > max)
        //        {
        //            max = totalDelta;
        //        }
        //    }
        //    return max;
        //}

        private static int GetMaxDelta(IList<int> input)
        {
            int maxDelta = 0;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    int delta = input[j] - input[i];
                    if (delta > maxDelta)
                    {
                        maxDelta = delta;
                    }
                }
            }
            return maxDelta;
        }
    }
}
