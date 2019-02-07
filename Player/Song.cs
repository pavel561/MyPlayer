using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.Generic;

namespace Player.Music
{
	[Serializable]
	public class Song:PlayingItem
    {
        public Artist Artist;
        public Album Album;
			
		public Song()
		{

		}
		public Song(string name, string path)
		{
			this.Path = path;
			this.Name = name;
			//this.Artist = new Artist(null,null);
			//this.Album = Album.
		}
		public Song(string name, string artistName, string artistGenre, int duration)
		{
			Artist = new Artist(artistName, artistGenre);
			Name = name;
			Duration = duration;

		}
		//public void Deconstruct(this Song song, out string name, out string minuts,)
		//{

		//}
		public override int CompareTo(object obj)
		{
			Song song = obj as Song;
			if (this.Artist.Genre > song.Artist.Genre)
				return 1;
			if (this.Artist.Genre < song.Artist.Genre)
				return -1;
			else
				return 0;

			//return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
		}
		public override string ToString()
		{
			return ($"{Name} - {Artist} - {Album} - {Duration}");
		}
	}
}
