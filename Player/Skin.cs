using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.Music.Extentions;
using Player.Music;
using Player.Generic;


namespace Player.Skin
{
	public interface ISkin
	{
		void Clear();
		//public abstract void Render();
		void Render(string text);
		//public abstract void Render(bool locked, bool shaffle, bool repeat, int volume, bool playing, int position, List<string> playlist);
	}
	public class ClassicSkin:ISkin
	{
		public void Clear()
		{
			Console.Clear();
		}
		public void Render(string text)
		{
			Console.WriteLine(text);
		}
		public void NewScreen()
		{
			Console.Clear();
		}
	}
	public class ColorSkin : ISkin
	{
		public ColorSkin(ConsoleColor color)
		{
			Console.ForegroundColor = color;
		}
		public void Render(string text)
		{
			Console.WriteLine(text);
		}
		//public void Render(ConsoleColor color,string text)
		//{
		//	ConsoleColor prewColor = Console.ForegroundColor;
		//	Console.ForegroundColor = color;
		//	Console.WriteLine(text);
		//	Console.ForegroundColor = prewColor;
		//}
		public void Clear()
		{
			Console.Clear();
		}
		//public void NewScreen()
		//{
		//	Console.Clear();
		//}
	}
	public class ColorSkinRnd : ISkin
	{
		public void Clear()
		{
			Console.Clear();
		}
		public void Render(string text)
		{
			Console.WriteLine(text);
		}
		//public void NewScreen()
		//{
		//	Console.Clear();
		//}
	}
	class AnimatedColorSkin : ISkin
	{
		public const int SkinHeight = 44;
		public int StatusPosition { get; set; }
		public int NamePosition { get; set; }
		public int PlaylistPosition { get; set; }
		public int TimeLinePosition { get; set; }
		public int MessagePosition { get; set;
		}
		public AnimatedColorSkin()
		{
			StatusPosition = 0;
			NamePosition = 2;
			MessagePosition = 4;
			TimeLinePosition = 6;
			PlaylistPosition = 8;
			//===================================================================
			//AnimatedSkinDemo
			RenderTimeLine();
			RenderStatusLine(false, false, false, 10);
			System.Threading.Thread.Sleep(1000);
			RenderStatusLine(true, false, false, 10);
			System.Threading.Thread.Sleep(1000);
			RenderStatusLine(true, true, false, 10);
			System.Threading.Thread.Sleep(1000);
			RenderStatusLine(true, true, true, 10);
			System.Threading.Thread.Sleep(1000);
			RenderStatusLine(true, true, true, 50);
			System.Threading.Thread.Sleep(1000);
			//RenderSongNameLine("The Beatles - Here comes the sun - Abbey Road (1969)".ShortName());
			//RenderPlayListLine(songList, 0);
			System.Threading.Thread.Sleep(1000);
			RenderSongNameLine("The Beatles - The end - Abbey Road (1969)".ShortName());
			//RenderPlayListLine(songList, 1);
			System.Threading.Thread.Sleep(1000);
			RenderSongNameLine("The Beatles - Come together - Abbey Road (1969)".ShortName());
			//RenderPlayListLine(songList, 2);

			//===================================================================
		}
		public void ClearLine()
		{
			if(Console.CursorTop > 0)
			{
				Console.CursorTop--;
				Console.CursorLeft = 0;
				Console.WriteLine("".PadRight(SkinHeight));
				Console.CursorTop--;
				Console.CursorLeft = 0;
			}
			
		}
		public void Clear()
		{
			Console.Clear();
		}
		public void Render(string text)
		{
			//Console.WriteLine(text);
			RenderMessageLine(text);
		}
		public void RenderAnimated(bool locked, bool shaffle, bool repeat, int volume, bool playing, int position, List<string> playlist)
		{
			RenderStatusLine(locked, shaffle, repeat, volume);
			RenderSongNameLine(playlist[position]);
			//RenderMessageLine(string message);
			RenderTimeLine();
			RenderPlayListLine(playlist, position);

		}
		public void RenderStatusLine(bool locked, bool shaffle, bool repeat, int volume)
		{
			string lockedString;
			string shaffleString;
			string repeatString;
			string volumeString;

			if(locked == true)
			{
				lockedString = "[ON] ";
			}
			else
			{
				lockedString = "[OFF]";
			}
			if (shaffle == true)
			{
				shaffleString = "[ON]-off";
			}
			else
			{
				shaffleString = "on-[OFF]";
			}
			if (repeat == true)
			{
				repeatString = "[ON]-off";
			}
			else
			{
				repeatString = "on-[OFF]";
			}

			volumeString = volume.ToString();

			Console.CursorLeft = 0;
			Console.CursorTop = StatusPosition;
			Console.WriteLine("LOCK(L)  SHAFFLE(H)   REPEAT(R)  VOLUME(+/-)");
			Console.WriteLine($" {lockedString,5}    {shaffleString,5}    {repeatString,5}  {volumeString,5}");
			//Console.WriteLine(text);
		}
		public void RenderSongNameLine(string songName)
		{
			Console.CursorLeft = 0;
			Console.CursorTop = NamePosition;
			WriteSeparatorString('-');
			WriteFormatString(songName);
			//Console.WriteLine("".PadRight(SkinHeight, '-'));
		}
		public void RenderSongNameLine(string songName, int position)
		{
			Console.CursorLeft = 0;
			Console.CursorTop = NamePosition;
			WriteSeparatorString('-');
			WriteFormatString(songName);
			//Console.WriteLine("".PadRight(SkinHeight, '-'));
		}
		public void RenderSongNameLine(List<Song> songs, int position)
		{
			Console.CursorLeft = 0;
			Console.CursorTop = NamePosition;
			WriteSeparatorString('-');
			WriteFormatString(songs[position].ToString());
			Console.WriteLine("".PadRight(SkinHeight, '-'));
		}
		public void RenderMessageLine(string message)
		{

			Console.CursorLeft = 0;
			Console.CursorTop = MessagePosition;
			WriteSeparatorString('-');
			WriteFormatString(message);
			//WriteSeparatorString('-');
		}
		public void RenderTimeLine()
		{
			Console.CursorLeft = 0;
			Console.CursorTop = TimeLinePosition;
			WriteSeparatorString('-');
			WriteFormatString(DateTime.Now.ToShortTimeString());
			//WriteSeparatorString('-');
		}
		public void RenderPlayListLine(List<Song> listSongs, int currentPosition)
		{
			Console.CursorLeft = 0;
			Console.CursorTop = PlaylistPosition;
			WriteSeparatorString('-');
			for (int i = 0; i < listSongs.Count; i++)
			{
				if (currentPosition == i)
				{
					WriteFormatString(" >> " + listSongs[i]);
				}
				else
				{
					WriteFormatString("    " + listSongs[i].Name);
				}

			}
			WriteSeparatorString('-');
		}
		public void RenderPlayListLine(List<PlayingItem> listSongs, int currentPosition)
		{

			Console.CursorLeft = 0;
			Console.CursorTop = PlaylistPosition;
			WriteSeparatorString('-');
			for (int i = 0; i < listSongs.Count; i++)
			{
				if (currentPosition == i)
				{
					WriteFormatString(" >> " + listSongs[i]);
				}
				else
				{
					WriteFormatString("    " + listSongs[i].Name);
				}

			}
			WriteSeparatorString('-');
		}
		public void RenderPlayListLine(List<string> listSongs, int currentPosition)
		{

			Console.CursorLeft = 0;
			Console.CursorTop = PlaylistPosition;
			WriteSeparatorString('-');
			for (int i = 0; i < listSongs.Count; i++)
			{
				if(currentPosition == i)
				{
					WriteFormatString(" >> " + listSongs[i]);
				}
				else
				{
					WriteFormatString("    " + listSongs[i]);
				}

			}
			WriteSeparatorString('-');
		}
		public void NewScreen()
		{
			Console.Clear();
		}
		public void WriteFormatString(string text)
		{
			if (text.Length < SkinHeight)
			{
				Console.WriteLine($" {text}".PadRight(SkinHeight));
			}
			else
			{
				Console.WriteLine($" {text}".ShortName(SkinHeight));
			}
		}
		public void WriteSeparatorString(char symbol)
		{
			Console.WriteLine("".PadRight(SkinHeight, symbol));
		}
	}
}
