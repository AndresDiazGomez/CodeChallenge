namespace CodeChallenge
{
    public static class ParenthesesCombination
    {
        public static IList<string> GetAllCombinations(int numberOfParentheses)
        {
            if(numberOfParentheses < 1)
            {
                return new List<string>();
            }
            return GetAllCombinations(new List<string>(), numberOfParentheses, new char[2 * numberOfParentheses], 0, 0, 0);
        }

        private static IList<string> GetAllCombinations(IList<string> array, int numberOfParentheses, char[] currentCombination, int currentPosition, int openPosition, int closePosition)
        {
            if (closePosition == numberOfParentheses)
            {
                array.Add(string.Join("", currentCombination));
                return array;
            }
            if (openPosition > closePosition)
            {
                currentCombination[currentPosition] = ')';
                GetAllCombinations(array, numberOfParentheses, currentCombination, currentPosition + 1, openPosition, closePosition + 1);
            }
            if (openPosition < numberOfParentheses)
            {
                currentCombination[currentPosition] = '(';
                GetAllCombinations(array, numberOfParentheses, currentCombination, currentPosition + 1, openPosition + 1, closePosition);
            }
            return array;
        }
    }
}
