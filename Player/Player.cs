using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extentions;
using System.IO;



namespace MusicPlayer
{
	class Player
    {

        const int MAX_VOLUME = 100;
        const int MIN_VOLUME = 0;

        private int _volume;
		private bool _locked;
		private bool _playing;
		public bool Repeat { get; private set; }
		public bool Shaffle { get; private set; }

		public bool RepeatChange()
		{
			Repeat = !Repeat;
			return Repeat;
		}
		public bool ShaffleChange()
		{
			Shaffle = !Shaffle;
			return Shaffle;
		}

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
		public SoundPlayer soundPlayer = new SoundPlayer();
		public List<Song> Songs = new List<Song>();
		public Skin skin;

		//public Song[] Songs { get; private set; }

        public Player(Skin skin)
        {
            Volume = 0;
            _locked = false;
            _playing = false;
			Repeat = false;
			Shaffle = false;
			this.skin = skin;
        }
		public void Next()
		{

		}
		public void Preview()
		{

		}

        public void VolumeUp()
        {
			if(_locked)
			{
				//Console.WriteLine($"Payer is locked");
				skin.Render($"Payer is locked");
				//skin.Render(;
			}
			else
			{
				if (Volume < 100)
				{
					Volume++;
					//Console.WriteLine($"Volume up to {Volume}");
					skin.Render($"Volume up to {Volume}");
				}
				else
				{
					//Console.WriteLine($"Volume is maximum");
					skin.Render($"Volume is maximum");
				}
			}
        }
        public void VolumeDown()
        {
			if (_locked)
			{
				//Console.WriteLine($"Player is locked.");
				skin.Render($"Payer is locked");
				return;
			}
			{
				if (Volume > 0)
				{
					Volume--;
					//Console.WriteLine($"Volume down to {Volume}");
					skin.Render($"Volume down to {Volume}");
				}
				else
				{
					//Console.WriteLine($"Volume is maximum");
					skin.Render($"Volume is maximum");
				}
			}
        }
        public void VolumeChange(int step)
        {
			if(_locked)
			{
				//Console.WriteLine($"Player is locked.");
				skin.Render($"Payer is locked");
				return;
			}
			else
			{
				Volume += step;
				//Console.WriteLine($"Volume change to {Volume}");
				skin.Render($"Volume change to {Volume}");
			}
           
        }
        public bool Play()
        {
			if (_locked)
			{
				//Console.WriteLine($"Player is locked.");
				skin.Render($"Player is locked.");
			}
			else
			{
				_playing = true;
				foreach (Song song in Songs)
				{
					//Console.WriteLine($"Player is playing: {song.Name}, duration is {song.Duration} sec.");
					skin.Render($"Player is playing: {song.Name}, duration is {song.Duration} sec.".ShortName());
					//skin.RenderPlaylist(//$"Player is playing: {song.Name}, duration is {song.Duration} sec.".ShortName());
					//soundPlayer.SoundLocation = file_path;

					System.Threading.Thread.Sleep(1000);
				}
			}
			return _playing;
		}
			
        public bool Stop()
        {
			if (_locked)
			{
				//Console.WriteLine($"Player is locked.");
				skin.Render($"Player is locked.");
			}
			else
			{
				_playing = false;
				//Console.WriteLine($"Player has stopped.");
				skin.Render($"Player has stopped.");
			}
			return _playing;
        }
        public void Lock()
        {
            //Console.WriteLine($"Player is locked.");
			skin.Render($"Player is locked.");
			_locked = true;
        }
        public void Unlock()
        {
            //Console.WriteLine($"Player is unlocked.");
			skin.Render($"Player is unlocked.");
			_locked = false;
        }

		public void Load(string filePath)
		{
			var dirInfo = new DirectoryInfo(filePath);
			var files = dirInfo.GetFiles("*.wav");
			//if(files)
			foreach (FileInfo file in files)
			{
				soundPlayer.SoundLocation = file.FullName;
				string name = file.Name;
				string artist = null;
				string genre = "Unknown";
				int duration = (int)file.Length;
				Songs.Add(new Song(name, artist, genre, duration));

				//soundPlayer.PlaySync();
				//System.Threading.Thread.Sleep(2000);

				//var songTag = soundPlayer.;
				//Console.Write(file.Name + "  ");
				//Console.Write(file.CreationTime + "  ");
				//Console.WriteLine(file.Length + "  ");
			}

		}
		public void Clear()
		{
			Songs.Clear();
		}
		//public void Add(List<Song> songsArray)
		//{
		//	//В перспективе принимать ссылки на файлы ФС
		//	//Принимать файлы плейлистов
		//	//Сохранять файл плейлиста
		//	Songs = songsArray;
		//}
		//public void Add(Song song)
		//{
		//	//В перспективе принимать ссылки на файлы ФС
		//	//Принимать файлы плейлистов
		//	//Сохранять файл плейлиста
		//	Songs.Add(song);

		//}
		//public void Sort()				//Дописать метод сортировки песен
		//{
		//	Songs.Sort();
		//}
		//public void Shuffle()
		//{
		//	Random rnd = new Random();

		//	for (int i = Songs.Count - 1; i >= 0; i--)
		//	{
		//		var song = Songs[rnd.Next(Songs.Count - 1)];
		//		Songs.Remove(song);
		//		Songs.Add(song);
		//	}
		//}
    }
}
