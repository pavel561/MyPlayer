using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extentions;

namespace MusicPlayer
{
    class Player
    {
        const int MAX_VOLUME = 100;
        const int MIN_VOLUME = 0;
        private int _volume;
		private bool _locked;
		private bool _playing;
        public int Volume
        {
            get
            {
                return (_volume);
            }
            private set
            {
                if(value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if(value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

		public List<Song> Songs = new List<Song>();
		//public Song[] Songs { get; private set; }

        public Player()
        {
            Volume = 0;
            _locked = false;
            _playing = false;
        }

        public void VolumeUp()
        {
			if(_locked)
			{
				Console.WriteLine($"Payer is locked");
			}
			else
			{
				if (Volume < 100)
				{
					Volume++;
					Console.WriteLine($"Volume up to {Volume}");
				}
				else
				{
					Console.WriteLine($"Volume is maximum");
				}
			}
        }
        public void VolumeDown()
        {
			if (_locked)
			{
				Console.WriteLine($"Player is locked.");
				return;
			}
			{
				if (Volume > 0)
				{
					Volume--;
					Console.WriteLine($"Volume down to {Volume}");
				}
				else
				{
					Console.WriteLine($"Volume is maximum");
				}
			}
        }
        public void VolumeChange(int step)
        {
			if(_locked)
			{
				Console.WriteLine($"Player is locked.");
				return;
			}
			else
			{
				Volume += step;
				Console.WriteLine($"Volume change to {Volume}");
			}
           
        }
        public bool Play()
        {
			if (_locked)
			{
				Console.WriteLine($"Player is locked.");
			}
			else
			{
				_playing = true;
				foreach (Song song in Songs)
				{
					Console.WriteLine($"Player is playing: {song.Name}, duration is {song.Duration} sec.");
					System.Threading.Thread.Sleep(1000);
				}
			}
			return _playing;
		}
			
        public bool Stop()
        {
			if (_locked)
			{
				Console.WriteLine($"Player is locked.");
			}
			else
			{
				_playing = false;
				Console.WriteLine($"Player has stopped.");
			}
			return _playing;
        }
        public void Lock()
        {
            Console.WriteLine($"Player is locked.");
            _locked = true;
        }
        public void Unlock()
        {
            Console.WriteLine($"Player is unlocked.");
            _locked = false;
        }
		public void Add(List<Song> songsArray)
		{
			//В перспективе принимать ссылки на файлы ФС
			//Принимать файлы плейлистов
			//Сохранять файл плейлиста
			Songs = songsArray;
		}
		public void Add(Song song)
		{
			//В перспективе принимать ссылки на файлы ФС
			//Принимать файлы плейлистов
			//Сохранять файл плейлиста
			Songs.Add(song);

		}
		public void Sort()				//Дописать метод сортировки песен
		{
			Songs.Sort();
		}
		public void Shuffle()           //Дописать метод перемешивания песен
		{
			Random rnd = new Random();

			for (int i = Songs.Count - 1; i >= 0; i--)
			{
				var song = Songs[rnd.Next(Songs.Count - 1)];
				Songs.Remove(song);
				Songs.Add(song);
			}
		}
    }
}
