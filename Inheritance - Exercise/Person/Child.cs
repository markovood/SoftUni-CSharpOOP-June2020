using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) :
            base(name, age)
        {
            //if (this.Age > 15)
            //{
            //    throw new ArgumentOutOfRangeException("age", "Cannot be above 15 y.o.");
            //}
        }
    }
}
