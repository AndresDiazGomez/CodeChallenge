namespace CodeChallenge
{
    public static class Fibonacci
    {
        /// <summary>
        /// Write a function int fib(int n) that returns Fn. For example, if n = 0, then fib() should return 0. If n = 1, then it should return 1. For n > 1, it should return Fn-1 + Fn-2.
        /// Given a number n, print n-th Fibonacci Number.
        /// </summary>
        /// <param name="targetIndex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int GetFibonacciNumber(int targetIndex)
        {
            if (targetIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(targetIndex), "Cannot calculate fibonacci for negative numbers");
            }
            if (targetIndex == 0)
            {
                return 0;
            }
            return GetFibonacciNumber(targetIndex, 1, 1, 0);
        }

        private static int GetFibonacciNumber(int targetIndex, int currentIndex, int currentNumber, int lastNumber)
        {
            if (targetIndex == currentIndex)
            {
                return currentNumber;
            }
            return GetFibonacciNumber(targetIndex, currentIndex + 1, currentNumber + lastNumber, currentNumber);
        }
    }
}
