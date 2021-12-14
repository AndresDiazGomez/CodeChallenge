namespace CodeChallenge
{
    public class PhoneNumber
    {
        private Dictionary<char, char[]> _phoneNumberKey = new() 
        {
            { PhoneNumberKey.One.NumberKey, PhoneNumberKey.One.Letters },
            { PhoneNumberKey.Two.NumberKey, PhoneNumberKey.Two.Letters },
            { PhoneNumberKey.Three.NumberKey, PhoneNumberKey.Three.Letters },
            { PhoneNumberKey.Four.NumberKey, PhoneNumberKey.Four.Letters },
            { PhoneNumberKey.Five.NumberKey, PhoneNumberKey.Five.Letters },
            { PhoneNumberKey.Six.NumberKey, PhoneNumberKey.Six.Letters },
            { PhoneNumberKey.Seven.NumberKey, PhoneNumberKey.Seven.Letters },
            { PhoneNumberKey.Eight.NumberKey, PhoneNumberKey.Eight.Letters },
            { PhoneNumberKey.Nine.NumberKey, PhoneNumberKey.Nine.Letters },
            { PhoneNumberKey.Zero.NumberKey, PhoneNumberKey.Zero.Letters },
        };

        public PhoneNumber()
        {
        }

        /// <summary>
        /// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
        /// Map digits to letters just like they are on the telephone buttons.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> GetPhoneMessage(string input)
        {
            return GetPhoneMessage(new List<string>(), input.Length, 0, new char[input.Length], input.ToCharArray());
        }

        private List<string> GetPhoneMessage(List<string> list, int totalLenght, int position, char[] message, char[] input)
        {
            if (position == totalLenght)
            {
                list.Add(string.Join("", message));
            }
            else
            {
                char inputKey = input[position];
                if (!_phoneNumberKey.ContainsKey(inputKey))
                {
                    throw new ArgumentException($"One of the input keys ({inputKey}) doesn't exist in the phone", nameof(input));
                }
                char[] keyChars = _phoneNumberKey[inputKey];
                for (int j = 0; j < keyChars.Length; j++)
                {
                    message[position] = keyChars[j];
                    GetPhoneMessage(list, totalLenght, position + 1, message, input);
                }
            }
            return list;
        }

        private class PhoneNumberKey
        {
            public static PhoneNumberKey One = new('1', new[] { '(' });
            public static PhoneNumberKey Two = new('2', new[] { 'A', 'B', 'C' });
            public static PhoneNumberKey Three = new('3', new[] { 'D', 'E', 'F' });
            public static PhoneNumberKey Four = new('4', new[] { 'G', 'H', 'I' });
            public static PhoneNumberKey Five = new('5', new[] { 'J', 'K', 'L' });
            public static PhoneNumberKey Six = new('6', new[] { 'M', 'N', 'O' });
            public static PhoneNumberKey Seven = new('7', new[] { 'P', 'Q', 'R', 'S' });
            public static PhoneNumberKey Eight = new('8', new[] { 'T', 'U', 'V' });
            public static PhoneNumberKey Nine = new('9', new[] { 'W', 'X', 'Y', 'Z' });
            public static PhoneNumberKey Zero = new('0', new[] { ' ' });

            private PhoneNumberKey(char numberKey, char[] chars)
            {
                NumberKey = numberKey;
                Letters = chars;
            }

            public char NumberKey { get; private set; }
            public char[] Letters { get; private set; }

        }
    }
}
