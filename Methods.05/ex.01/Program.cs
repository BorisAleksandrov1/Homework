
using System.Diagnostics.CodeAnalysis;

namespace ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                bool isDigitOdd = IsAnyDigitOdd(i);
                bool divideBy8 = IsDivideabelBy8(i);
                if (isDigitOdd && divideBy8)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool IsAnyDigitOdd(int i)
        {
            string temp = i.ToString();
            int tempInt;

            for (int j = 0; j < temp.Length; j++)
            {
                tempInt = int.Parse(temp[j].ToString());

                if (tempInt % 2 == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsDivideabelBy8(int i)
        {
            int sum = 0;
            string temp = i.ToString();
            int tempInt;

            for (int j = 0; j < temp.Length; j++)
            {
                tempInt = int.Parse(temp[j].ToString());

                sum += tempInt;
            }


            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}