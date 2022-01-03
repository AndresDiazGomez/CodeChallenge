namespace CodeChallenge
{
    public static class LuckyNumber
    {
        /// <summary>
        /// Given an array returns the lucky number which is the one that appear as many times as its number.
        /// If no number is found return -1.
        /// If found multiple results return the largest one.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetLuckyNumber(IEnumerable<int> input)
        {
            var group = input.GroupBy(number => number)
                .Where(item => item.Key ==  item.Count())
                .Select(item => item.Key);
            return group.LastOrDefault(-1);
        }
    }
}
