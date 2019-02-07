using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player.Music.Extentions;
using System.IO;
using System.Xml.Serialization;
using Player.Generic;

namespace Player.Music
{
	class MusicPlayer : GenericPlayer<Song>
    {
		public SoundPlayer soundPlayer;// = new SoundPlayer();

		public MusicPlayer()
		{
			soundPlayer = new SoundPlayer();
		}
		~MusicPlayer()
		{
			Stop();
			soundPlayer.Dispose();
			soundPlayer = null;
			PlayingItemsList = null;

		}

        public override bool Play()
        {
			if (Locked)
			{
				//Console.WriteLine($"Player is locked.");
				//skin.Render($"Player is locked.");
			}
			else
			{
				_playing = true;
				for (int i = 0; i < PlayingItemsList.Count; i++)
				{
					ItemStartedMasterEvent(PlayingItemsList, i);
					using (soundPlayer = new SoundPlayer(PlayingItemsList[i].Path))
					{
						soundPlayer.PlaySync();
					}
					
					System.Threading.Thread.Sleep(1000);
				}
			}
			return _playing;
		}
			
        public override bool Stop()
        {
			if (Locked)
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

		public override void Load(string filepath)
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
					PlayingItemsList.Add(new Song(name, path));
				}
				ItemListChangedMasterEvent(PlayingItemsList, 0);
			}
		}
		public void Clear()
		{
			PlayingItemsList.Clear();
			ItemListChangedMasterEvent(PlayingItemsList, 0);
		}
		public void PlaylistSrlz()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
			using (FileStream fs = new FileStream("D://Playlist.xml", FileMode.OpenOrCreate))
			{
				serializer.Serialize(fs, PlayingItemsList);
				//.WriteLine("Объект сериализован");
			}			
		}
		public void PlaylistDeSrlz()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
			using (FileStream fs = new FileStream("D://Playlist.xml", FileMode.Open))
			{
				PlayingItemsList = (List<Song>) serializer.Deserialize(fs);
				//Console.WriteLine("Объект десериализован");
			}
		}
	}
}
