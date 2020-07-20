using Logger.Layouts.Contracts;

namespace Logger.Contracts
{
    public interface ILogFile
    {
        string Path { get; }
        int Size { get; }
        void Write(string message);
    }
}