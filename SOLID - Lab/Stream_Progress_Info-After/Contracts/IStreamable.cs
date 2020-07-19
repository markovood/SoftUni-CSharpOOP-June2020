namespace Stream_Progress_Info_After.Contracts
{
    public interface IStreamable
    {
        public int Length { get; }
        public int BytesSent { get; }
    }
}