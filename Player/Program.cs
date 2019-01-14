using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extentions;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
			var player = new Player();

			B5_Player_8_10_ParamsParameters(player);
			B5_Player_9_10_MethodOverloading();
			B5_Player_10_10_DefaultAndNamedParamters();

			//player.Volume = 20;			//Ошибка, т.к. сеттер у ствойства приватный
			player.VolumeChange(-101);
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


			//var artist2 = new Artist("Pink Floyd");
			//Console.WriteLine($"{artist2.Name}");
			//Console.WriteLine($"{artist2.Genre}");

			//var artist3 = new Artist("Iowa", "Pop");
			//Console.WriteLine($"{artist3.Name}");
			//Console.WriteLine($"{artist3.Genre}");
			//TraceInfo(player);



			//-L9-HW-Player-2/3. Substring
			foreach (Song song in player.Songs)
			{
				Console.WriteLine(song.Name.ShortName());
			}
			
			Console.ReadLine();
        }
        
        public static void TraceInfo(Player player)
        {
            Console.WriteLine(player.Songs[0].Album);
            Console.WriteLine(player.Songs[0].Name);
            Console.WriteLine(player.Songs[0].Artist);
            Console.WriteLine(player.Songs[0].Duration);
			Console.WriteLine(player.Volume);
        }
		//B5_Player_9_10_MethodOverloading()
		public static Song CreateSong()
		{
			//return new Song() { Name = "Unknown name", Duration = 120 };
			return CreateSong( "Unknown name", 0 );
		}
		public static Song CreateSong(string name)
		{
			//return new Song() { Name = name, Duration = 120 };
			return CreateSong(name , 0 );
		}
		public static Song CreateSong(string name, int duration)
		{
			return new Song() { Name = name, Duration = duration};
		}
		//=================================================================
		public static Artist AddArtist(string Name = "Unknown Artist", string Genre = "Unknown genre" )
		{
			return new Artist(Name, Genre);
		}
		public static Album AddAlbum(string Name = "Unknown Album", string Year = "-")
		{
			if (Year == "-") Year = "0";
			return new Album(Name, Convert.ToInt32(Year));
		}
		public static void B5_Player_10_10_DefaultAndNamedParamters()
		{
			Album alb = AddAlbum("White Album");
			Album alb2 = AddAlbum(Name: "Rubber soul", Year: "1966");
			Album alb3 = AddAlbum(Year: "1965", Name: "Help");
			Album alb4 = AddAlbum(Year: "1968");

			Artist art = AddArtist();
			Artist art2 = AddArtist("The Beatles");
			Artist art3 = AddArtist("Queen", "Rock");
			Artist art4 = AddArtist("Би-2", "Rock");

			Console.WriteLine($"{art.Name} - {art.Genre}");
			Console.WriteLine($"{art2.Name} - {art2.Genre}");
			Console.WriteLine($"{art3.Name} - {art3.Genre}");
			Console.WriteLine($"{art4.Name} - {art4.Genre}");

			Console.WriteLine($"{alb.Name} - {alb.Year}");
			Console.WriteLine($"{alb2.Name} - {alb2.Year}");
			Console.WriteLine($"{alb3.Name} - {alb3.Year}");
			Console.WriteLine($"{alb4.Name} - {alb4.Year}");
		}
		public static void B5_Player_9_10_MethodOverloading()
		{
			Song song = CreateSong();
			Song song2 = CreateSong("Here comes the sun");
			Song song3 = CreateSong("Under Pressure", 320);

			Console.WriteLine($"{song.Name} - {song.Duration}");
			Console.WriteLine($"{song2.Name} - {song2.Duration}");
			Console.WriteLine($"{song3.Name} - {song3.Duration}");
		}
		public static void B5_Player_8_10_ParamsParameters(Player player)
		{
			int totalDuration = 0;
			int minDuration;
			int maxDuration;

			var song1 = CreateSong();
			var song2 = CreateSong("Obla Di Obla Da");
			var song3 = CreateSong("Baskov", 200);

			player.Add(song1);
			//player.Add(song1, song2);
			//player.Add(song1, song2, song3);
			player.Add(GetSongsData(ref totalDuration, out minDuration, out maxDuration));
			Console.WriteLine($"Плейлист :");
			foreach (Song song in player.Songs)
			{
				Console.WriteLine($"Испольнитель - {song.Artist.Name}; Альбом - {song.Album.Name}; Композиция - {song.Name}; Продолжительность - {song.Duration} ");
			}
			Console.WriteLine($"Total duration: {totalDuration}, min: {minDuration}, max:{maxDuration}");
		}

		public static List<Song> GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
		{
			minDuration = 1000;
			maxDuration = 0;

			var songs = new List<Song>();
			var random = new Random();

			var artist = new Artist();
			artist.Genre = "Rock";
			artist.Name = "AC/DC";
			Console.WriteLine($"{artist.Name}");
			Console.WriteLine($"{artist.Genre}");

			var album = new Album();
			album.Name = "Back in Black";
			album.Year = 1980;

			Console.WriteLine($"{album.Name}");
			Console.WriteLine($"{album.Year}");

			for (int i = 0; i < 10; i++)
			{
				var song = new Song()
				{
					Duration = random.Next(1000),
					Name = $"new song {i}",
					Album = album,
					Artist = artist

				};
				songs.Add(song);
				totalDuration += song.Duration;
				if (song.Duration < minDuration) minDuration = song.Duration;
				maxDuration = Math.Max(maxDuration, song.Duration);
			}
			return songs;
		}
	}
}
