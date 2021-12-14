using System.Text;

namespace CodeChallenge
{
    public class OpenClose
    {
        private static readonly OpenClose Box = new('[', ']');
        private static readonly OpenClose Curly = new('{', '}');
        private static readonly OpenClose Round = new('(', ')');

        private readonly char _close;
        private readonly char _open;

        private OpenClose(char open, char close)
        {
            _open = open;
            _close = close;
        }

        /// <summary>
        /// Check for Balanced Brackets in an expression (well-formedness).
        /// Given an expression string exp, write a program to examine whether the pairs and the orders of “{“, “}”, “(“, “)”, “[“, “]” are correct in exp.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool MeetOpenClose(string value)
        {
            if (value == null || value.Length < 2 || value.Length % 2 != 0)
            {
                return false;
            }
            var closingChars = GetAllClosingSigns();
            var builder = new StringBuilder(value);
            while (builder.Length > 1)
            {
                int currentLength = builder.Length;
                char firstChar = builder[0];
                OpenClose firstElement = ToOpenClose(firstChar);
                if (firstElement == null || closingChars.Contains(firstChar))
                {
                    return false;
                }
                for (int i = 1; i < builder.Length; i++)
                {
                    if (firstElement._close == builder[i] && i % 2 != 0)
                    {
                        builder.Remove(i, 1);
                        builder.Remove(0, 1);
                        if (builder.Length == 0)
                        {
                            return true;
                        }
                        break;
                    }
                }
                if (currentLength == builder.Length)
                {
                    return false;
                }
            }
            return false;
        }

        private static char[] GetAllClosingSigns()
        {
            return new[] { Curly._close, Box._close, Round._close };
        }

        private static OpenClose ToOpenClose(char value)
        {
            if (value == Box._open)
            {
                return Box;
            }
            if (value == Curly._open)
            {
                return Curly;
            }
            if (value == Round._open)
            {
                return Round;
            }
            return null;
        }
    }
}