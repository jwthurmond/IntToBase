using System.Text;

namespace IntToBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digs = "2MT1GZ3F4RAPU5VJ67Q9KBCD8HNS";
            var base10Characters = "0123456789";
            Console.WriteLine(IntConverter(100000000, digs));
        }

        private static bool ChractersAreUnique(string characters)
        {
            //check to see if all characters are unique
            var charactersArray = characters.ToCharArray();
            var charactersArrayDistinct = charactersArray.Distinct().ToArray();
            return charactersArray.Length == charactersArrayDistinct.Length;
        }

        private static string IntConverter(int x, string digs)
        {
            if (!ChractersAreUnique(digs))
            {
                throw new InvalidDataException("Characters must be unique");
            }
            int baseValue = digs.Length;
            StringBuilder digits = new StringBuilder("");
            int sign;
            if (x < 0)
            {
                sign = -1;
            }
            else if (x == 0)
            {
                return digs.Substring(0, 1);
            }
            else
            {
                sign = 1;
            }

            x *= sign;


            while (x != 0)
            {
                digits.Append(digs[x % baseValue]);
                x = (x / baseValue);
            }

            if (sign < 0)
            {
                digits.Append('-');
            }
            
            return Reverse(digits.ToString());
        }

        private static string Reverse(string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}