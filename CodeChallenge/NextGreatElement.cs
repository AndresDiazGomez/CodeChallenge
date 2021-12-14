namespace CodeChallenge
{
    public static class NextGreatElement
    {
        public static Dictionary<int, int> GetNextGreatElement(IList<int> numbers)
        {
            Dictionary<int, int> result = new();
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] > numbers[i])
                    {
                        result.Add(numbers[i], numbers[j]);
                        break;
                    } 
                }
                if (result.Count != i + 1)
                {
                    result.Add(numbers[i], -1);
                }
            }
            return result;
        }
    }
}
