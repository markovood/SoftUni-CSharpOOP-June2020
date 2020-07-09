using System;

namespace Telephony
{
    public class SmartPhone : StationaryPhone, IBrowser
    {
        public SmartPhone(string callMsg) :
            base(callMsg)
        {
        }

        public void Browse(string URL)
        {
            if (IsValid(URL))
            {
                Console.WriteLine($"Browsing: {URL}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        private bool IsValid(string URL)
        {
            foreach (var symbol in URL)
            {
                if (char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}