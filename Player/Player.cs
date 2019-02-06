using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extentions;
using System.IO;
using System.Xml.Serialization;

namespace MusicPlayer
{
	class Player
    {
		public delegate void SongStarted(List<Song> song, int position);
		public event SongStarted SongStartedEvent;

		public delegate void LockedChange(bool state);
		public event LockedChange LockedChengeEvent;

		public delegate void SongListChanged(List<Song> songs, int position);
		public event SongListChanged SongListChangedEvent;

		//public List<string> filePath;

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
		public SoundPlayer soundPlayer;// = new SoundPlayer();
		public List<Song> Songs = new List<Song>();
		//public Skin skin;

		//public Song[] Songs { get; private set; }

        public Player()
        {
            Volume = 0;
            _locked = false;
            _playing = false;
			Repeat = false;
			Shaffle = false;
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
				//skin.Render($"Payer is locked");
				//skin.Render(;
			}
			else
			{
				if (Volume < 100)
				{
					Volume++;
					//Console.WriteLine($"Volume up to {Volume}");
					//skin.Render($"Volume up to {Volume}");
				}
				else
				{
					//Console.WriteLine($"Volume is maximum");
					//skin.Render($"Volume is maximum");
				}
			}
        }
        public void VolumeDown()
        {
			if (_locked)
			{
				//Console.WriteLine($"Player is locked.");
				//skin.Render($"Payer is locked");
				return;
			}
			{
				if (Volume > 0)
				{
					Volume--;
					//Console.WriteLine($"Volume down to {Volume}");
					//skin.Render($"Volume down to {Volume}");
				}
				else
				{
					//Console.WriteLine($"Volume is maximum");
					//skin.Render($"Volume is maximum");
				}
			}
        }
        public void VolumeChange(int step)
        {
			if(_locked)
			{
				//Console.WriteLine($"Player is locked.");
				//skin.Render($"Payer is locked");
				return;
			}
			else
			{
				Volume += step;
				//Console.WriteLine($"Volume change to {Volume}");
				//skin.Render($"Volume change to {Volume}");
			}
           
        }
        public bool Play()
        {
			if (_locked)
			{
				//Console.WriteLine($"Player is locked.");
				//skin.Render($"Player is locked.");
			}
			else
			{
				_playing = true;
				for (int i = 0; i < Songs.Count; i++)
				{
					SongStartedEvent(Songs, i);
					using (soundPlayer = new SoundPlayer(Songs[i].Path))
					{
						soundPlayer.PlaySync();
					}
					
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
				//skin.Render($"Player is locked.");
			}
			else
			{
				_playing = false;
				//Console.WriteLine($"Player has stopped.");
				//skin.Render($"Player has stopped.");
			}
			return _playing;
        }
        public void Lock()
        {
            //Console.WriteLine($"Player is locked.");
			//skin.Render($"Player is locked.");
			_locked = true;
        }
        public void Unlock()
        {
            //Console.WriteLine($"Player is unlocked.");
			//skin.Render($"Player is unlocked.");
			_locked = false;
        }

		public void Load(string filepath)
		{
			var dirInfo = new DirectoryInfo(filepath);
			if(dirInfo.Exists)
			{
				var files = dirInfo.GetFiles("*.wav");
				//if(files)
				foreach (FileInfo file in files)
				{
					string name = file.Name;
					string path = file.FullName;
					Songs.Add(new Song(name, path));
				}
				SongListChangedEvent?.Invoke(Songs, 0);
			}
		}
		public void Clear()
		{
			Songs.Clear();
			SongListChangedEvent?.Invoke(Songs, 0);
		}
		public void PlaylistSrlz()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
			using (FileStream fs = new FileStream("D://Playlist.xml", FileMode.OpenOrCreate))
			{
				serializer.Serialize(fs, Songs);
				//.WriteLine("Объект сериализован");
			}			
		}
		public void PlaylistDeSrlz()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
			using (FileStream fs = new FileStream("D://Playlist.xml", FileMode.Open))
			{
				Songs = (List<Song>) serializer.Deserialize(fs);
				//Console.WriteLine("Объект десериализован");
			}
		}
	}
}
