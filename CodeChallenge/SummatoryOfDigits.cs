namespace CodeChallenge
{
    public static class SummatoryOfDigits
    {
        /// <summary>
        /// Program for Sum of the digits of a given number.
        /// Given a number, find sum of its digits.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetSummatory(int number)
        {
            int sum = 0;
            while (number / 10 > 10)
            {
                sum += number % 10;
                number /= 10;
            }
            sum += number / 10;
            sum += number % 10;
            return sum;
        }

        /// <summary>
        /// Compute sum of digits in all numbers from 1 to n.
        /// Given a number n, find the sum of digits in all numbers from 1 to n. .
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetDigitSummatory(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            return GetSummatory(number) + GetDigitSummatory(number - 1);
        }

        /// <summary>
        /// Finding sum of digits of a number until sum becomes single digit.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetDigitSummatoryUntilOneDigit(int number)
        {
            var summatory = GetSummatory(number);
            if (summatory < 10)
            {
                return summatory;
            }
            return GetDigitSummatoryUntilOneDigit(summatory);
        }
    }
}
