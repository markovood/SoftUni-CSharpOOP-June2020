namespace Farm
{
    public class StartUp
    {
        public static void Main()
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();

            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

            Dog someDog = new Dog();
            someDog.Eat();
            someDog.Bark();
            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}