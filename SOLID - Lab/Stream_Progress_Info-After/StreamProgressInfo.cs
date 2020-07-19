using Stream_Progress_Info_After.Contracts;

namespace Stream_Progress_Info_After
{
    public class StreamProgressInfo
    {
        private IStreamable streamable;

        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}