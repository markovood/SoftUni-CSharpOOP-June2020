using System;

namespace SquareRoot
{
    public class SquareRoot
    {
        public static void Main()
        {

            try
            {
                int number = int.Parse(Console.ReadLine());
                double root = CalculateSquareRoot(number);
                Console.WriteLine(root);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double CalculateSquareRoot(int number)
        {
            if (number < 0)
            {
                throw new InvalidOperationException();
            }

            return Math.Sqrt(number);
        }
    }
}