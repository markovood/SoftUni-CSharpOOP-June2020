using System;

namespace Stream_Progress_Info_After
{
    public class Program
    {
        public static void Main()
        {
            var file = new File("someName", 15, 500);
            var music = new Music("someArtist", "someAlbum", 5, 48);

            var fileStreamProgressInfo = new StreamProgressInfo(file);
            Console.WriteLine(fileStreamProgressInfo.CalculateCurrentPercent());

            var musicStreamProgressInfo = new StreamProgressInfo(music);
            Console.WriteLine(musicStreamProgressInfo.CalculateCurrentPercent());
        }
    }
}