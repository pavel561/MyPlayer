using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Generic
{
	public class PlayingItem:IComparable
	{
		public string Name;
		public int Duration;
		public string Path;
		[NonSerialized]
		public bool? LikeState = null;
		public void Like()
		{
			LikeState = true;
		}
		public void Dislike()
		{
			LikeState = false;
		}

		public virtual int CompareTo(object obj)
		{
			return this.Name?.CompareTo((obj as PlayingItem)?.Name) ?? 0;
		}
	}
}
