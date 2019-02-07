using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Music
{
    public class Artist: IComparable
    {
        public Genres Genre;
        public string Name;
		public enum Genres:int {Unknown = 0, Rock, Punk, Pop, Jazz, HipHop, Folk, Electro, Country, Latin, Blues, Other};

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
			this.Genre = (Genres)Enum.Parse(typeof(Genres), genre);
		}
		public override string ToString()
		{
			return ($"{Name}");
		}
		public int CompareTo(object obj)
		{
			Artist artist = obj as Artist;
			if (this.Genre > artist.Genre)
				return 1;
			if (this.Genre < artist.Genre)
				return -1;
			else
				return 0;
			//return this.Genre?.CompareTo((obj as Artist)?.Genre) ?? 0;
		}
	}
}
