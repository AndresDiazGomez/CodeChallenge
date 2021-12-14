namespace CodeChallenge
{
    public static class NextGreatElement
    {
        /// <summary>
        /// Given an array, print the Next Greater Element (NGE) for every element.
        /// The Next greater Element for an element x is the first greater element on the right side of x in the array.
        /// Elements for which no greater element exist, consider the next greater element as -1. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
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
