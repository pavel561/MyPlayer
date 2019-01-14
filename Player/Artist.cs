using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Artist
    {
        public Genres Genre;
        public string Name;
		public enum Genres:int {Unknown = 0, Rock, Punk, Pop, Juzz, HipHop, Folk, Electro, Country, Latin, Blues, Other};

        public Artist()
        {
            this.Name = "Unknown artist";
			this.Genre = Genres.Unknown; //Genres.Unknown.ToString();

		}
        public Artist(string name)
        {
            this.Name = name;
            this.Genre = Genres.Unknown;//"Unknown genre";
		}
        public Artist(string name, string genre)
        {
            this.Name = name;
            this.Genre = Genres.Unknown;
		}
		public override string ToString()
		{
			return ($"{Name}");
		}
	}
}
