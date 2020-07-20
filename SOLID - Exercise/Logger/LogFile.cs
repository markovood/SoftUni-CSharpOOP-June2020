using System.Text;

using Logger.Contracts;

namespace Logger
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size => this.GetSize();

        public string Path => @"..\..\..\log.txt";

        public void Write(string message)
        {
            this.sb.AppendLine(message);
        }

        private int GetSize()
        {
            int size = 0;
            foreach (var symbol in this.sb.ToString())
            {
                if (char.IsLetter(symbol))
                {
                    size += symbol;
                }
            }

            return size;
        }
    }
}