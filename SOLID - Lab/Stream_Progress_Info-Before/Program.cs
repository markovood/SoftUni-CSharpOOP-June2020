using System;

namespace Stream_Progress_Before
{
    public class Program
    {
        static void Main()
        {
            var music = new Music("someArtist", "someAlbum", 5, 48);
            var file = new File("someName", 15, 500);

            var streamProgressInfo = new StreamProgressInfo(file);
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}