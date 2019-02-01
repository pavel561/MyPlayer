using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Song:IComparable
    {
        public int Duration;
        public string Name;
        public Artist Artist;
        public Album Album;
		public bool? LikeState { get; private set; } = null;
		public void Like()
		{
			LikeState = true;
		}
		public void Dislike()
		{
			LikeState = false;
		}
		public Song()
		{

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
		public int CompareTo(object obj)
		{
			//if (this.Name == null)
			//    return 0;

			//var songToCompare = (obj as Song);

			//var result = this.Name?.CompareTo(songToCompare);

			//return result ?? 0;

			//return result == null ? 0 : result.Value;

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
