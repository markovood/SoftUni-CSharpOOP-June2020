using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //string result = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            //string result = spy.RevealPrivateMethods("Stealer.Hacker");
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}