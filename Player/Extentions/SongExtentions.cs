using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicPlayer.Extentions
{
	static class SongExtentions
	{
		const int MAX_LENGTH = 10;
		static public String ShortName(this String name)
		{
			if (name.Length > MAX_LENGTH)
			{
				return name.Substring(0, MAX_LENGTH).Insert(MAX_LENGTH, "...");
			}
			else
			{
				return name;
			}
		}
		static public List<Song> Shuffle(this List<Song> songs)
		{
			Random rnd = new Random();
			for (int i = songs.Count - 1; i >= 0; i--)
			{
				var song = songs[rnd.Next(songs.Count - 1)];
				songs.Remove(song);
				songs.Add(song);
			}
			return songs;
		}
	}
}

