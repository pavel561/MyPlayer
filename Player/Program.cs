using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var player = new Player();
            //player.Volume = 20;			//Ошибка, т.к. сеттер у ствойства приватный
            player.VolumeChange(-101);

			var song1 = CreateSong();
			var song2 = CreateSong("Obla Di Obla Da");
			var song3 = CreateSong("Baskov", 200);
			player.Add(song1, song2, song3);

			player.Play();
			player.VolumeUp();
			player.VolumeUp();
			player.VolumeChange(25);
			player.VolumeChange(25);
			player.VolumeDown();
			player.VolumeDown();
			player.Lock();
			player.Stop();
			player.VolumeUp();
			player.VolumeDown();
			player.Unlock();
			player.Stop();

			int totalDuration = 0;
			int minDuration;
			int maxDuration;

			player.Add(GetSongsData(ref totalDuration, out minDuration, out maxDuration));
			Console.WriteLine($"Total duration: {totalDuration}, min: {minDuration}, max:{maxDuration}");
            TraceInfo(player);
			

			Console.ReadLine();
        }
        public static Song[] GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
			minDuration = 1000;
			maxDuration = 0;
            var album = new Album();
            album.Name = "Back in Black";
            album.Year = 1980;

            var artist = new Artist();
            artist.Genre = "Rock";
            artist.Name = "AC/DC";
			Console.WriteLine($"{artist.Name}");
			Console.WriteLine($"{artist.Genre}");

			var artist2 = new Artist("Pink Floyd");
            Console.WriteLine($"{artist2.Name}");
            Console.WriteLine($"{artist2.Genre}");

            var artist3 = new Artist("Iowa", "Pop");
            Console.WriteLine($"{artist3.Name}");
            Console.WriteLine($"{artist3.Genre}");
			var songs = new Song[10];
			var random = new Random();

			for (int i = 0; i < 10; i++)
			{
				var song = new Song()
				{
					Duration = random.Next(1000),
					Name = $"new song {i}",
					Album = album,
					Artist = artist

				};
				songs[i] = song;
				totalDuration += song.Duration;
				if (song.Duration < minDuration) minDuration = song.Duration;
				maxDuration = Math.Max(maxDuration, song.Duration);
			}
            return songs;
        }
        public static void TraceInfo(Player player)
        {
            Console.WriteLine(player.Songs[0].Album);
            Console.WriteLine(player.Songs[0].Name);
            Console.WriteLine(player.Songs[0].Artist);
            Console.WriteLine(player.Songs[0].Duration);
			Console.WriteLine(player.Volume);
        }
		public static Song CreateSong()
		{
			//return new Song() { Name = "Unknown name", Duration = 120 };
			return CreateSong( "Unknown name", 120 );
		}
		public static Song CreateSong(string name)
		{
			//return new Song() { Name = name, Duration = 120 };
			return CreateSong(name , 120 );
		}
		public static Song CreateSong(string name, int duration)
		{
			return new Song() { Name = name, Duration = duration};
		}
	}
}
