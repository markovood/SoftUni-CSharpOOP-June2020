using System;

namespace ConvertToDouble
{
    public class Program
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            try
            {
                double numberAsDouble = ConvertToDouble(number);
                if (double.IsNaN(numberAsDouble) || double.IsInfinity(numberAsDouble))
                {
                    throw new ArgumentException();
                }

                Console.WriteLine(numberAsDouble);
            }
            catch (SystemException)
            {
                Console.WriteLine("Conversion was unsuccessful, input data was invalid!");
            }
        }

        public static double ConvertToDouble(string number)
        {
            try
            {
                double result = Convert.ToDouble(number);
                return result;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw oe;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw fe;
            }
        }
    }
}