namespace Stream_Progress_Before
{
    public class File
    {
        private string name;

        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
