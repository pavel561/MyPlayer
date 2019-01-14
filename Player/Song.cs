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

		public int CompareTo(object obj)
		{
			//if (this.Name == null)
			//    return 0;

			//var songToCompare = (obj as Song);

			//var result = this.Name?.CompareTo(songToCompare);

			//return result ?? 0;

			//return result == null ? 0 : result.Value;

			return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
		}
		public override string ToString()
		{
			return ($"{Name} - {Artist}, Alb. - {Album}, Dur. - {Duration}");
		}
	}
}
