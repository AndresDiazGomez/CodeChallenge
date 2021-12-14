namespace CodeChallenge
{
    public static class SummatoryOfDigits
    {
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

        public static int GetDigitSummatory(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            return GetSummatory(number) + GetDigitSummatory(number - 1);
        }

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
