using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Artist
    {
        public string Genre;
        public string Name;

        public Artist()
        {
            this.Name = "Unknown artist";
            this.Genre = "Unknown genre";
        }
        public Artist(string name)
        {
            this.Name = name;
            this.Genre = "Unknown genre";
        }
        public Artist(string name, string genre)
        {
            this.Name = name;
            this.Genre = genre;
        }
		public override string ToString()
		{
			return ($"{Name}");
		}
	}
}
