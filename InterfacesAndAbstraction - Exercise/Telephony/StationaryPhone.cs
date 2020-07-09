using System;

namespace Telephony
{
    public class StationaryPhone : ITelephone
    {
        private string callMsg;

        public StationaryPhone(string callMsg)
        {
            this.callMsg = callMsg;
        }

        public void Call(string number)
        {
            if (IsValidNumber(number))
            {
                Console.WriteLine(this.callMsg + $"{number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        private bool IsValidNumber(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}