namespace CodeChallenge
{
    public static class NumberDecomposition
    {
        /// <summary>
        /// Return a list of numbers that can be decomposed in such way that the sum of them results in the number itself.
        /// A number cannot be repeated (appear twice in the same sum operation) neither be zero (0).
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<List<int>> Decompose(int number)
        {
            if (number <= 2)
                return new List<List<int>>();
            return Decompose(new List<List<int>>(), new List<int>() { number - 1 }, number, 1, 1);
        }

        private static List<List<int>> Decompose(List<List<int>> results, List<int> stack, int targetNumber, int startLoopNumber, int currentLoopNumber)
        {
            int currentStartNumber = stack[0];
            if (currentStartNumber == 0)
            {
                return results;
            }
            int currentSummatory = stack.Sum();
            if (startLoopNumber == 0)
            {
                int newStartNumber = currentStartNumber - 1;
                int newStartLoop = targetNumber - newStartNumber;
                if (newStartLoop >= newStartNumber)
                {
                    newStartLoop = newStartNumber - 1;
                }
                Decompose(results, new List<int>() { newStartNumber }, targetNumber, newStartLoop, newStartLoop);
            }
            else if (currentLoopNumber == 0)
            {
                Decompose(results, new List<int>() { currentStartNumber }, targetNumber, startLoopNumber - 1, startLoopNumber - 1);
            } 
            else if (currentSummatory + currentLoopNumber == targetNumber)
            {
                stack.Add(currentLoopNumber);
                results.Add(stack);
                Decompose(results, new List<int>() { currentStartNumber }, targetNumber, startLoopNumber - 1, startLoopNumber - 1);
            }
            else if (currentSummatory + currentLoopNumber < targetNumber)
            {
                stack.Add(currentLoopNumber);
                Decompose(results, stack, targetNumber, startLoopNumber, currentLoopNumber - 1);
            }
            else
            {
                Decompose(results, stack, targetNumber, startLoopNumber, currentLoopNumber - 1);
            }
            return results;
        }
    }
}
