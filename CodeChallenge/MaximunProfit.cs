namespace CodeChallenge
{
    public static class MaximunProfit
    {
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
