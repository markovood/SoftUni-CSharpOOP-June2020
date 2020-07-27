using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var person = new Person
            // (
            //     null,
            //     -1
            // );

            var person = new Person
             (
                 "Pesho",
                 15
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
