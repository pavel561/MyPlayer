﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Music
{
    public class Album
    {
        public byte[] Thumbnail;
        public string Name;
        public int Year;
		public Album()
		{
			this.Name = "Unknown album";
		}
		public Album(string name)
		{
			this.Name = name;
		}
		public Album(string name, int year)
		{
			this.Name = name;
			this.Year = year;
		}
		public override string ToString()
		{
			return ($"{Name}");
		}
	}
}
