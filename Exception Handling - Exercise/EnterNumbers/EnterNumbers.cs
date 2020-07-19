using System;

namespace EnterNumbers
{
    public class EnterNumbers
    {
        public static void Main()
        {
            int start = 1;
            int end = 100;

            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; i++)
            {
                try
                {
                    int num = ReadNumber(start, end);
                    nums[i] = num;
                }
                catch (SystemException)
                {
                    Console.WriteLine("Invalid number.");
                    Console.WriteLine("Start again:");
                    i = -1;
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            Console.WriteLine($"Enter number in range [{start}-{end}]");
            int num = int.Parse(Console.ReadLine());
            if (num < start || num > end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return num;
        }
    }
}