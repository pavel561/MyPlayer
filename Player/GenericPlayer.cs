using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Generic
{
	public abstract class GenericPlayer<T> //where T: PlayingItem
	{
		public delegate void ItemStarted(List<T> itemList, int position);
		public event ItemStarted ItemStartedEvent;

		public delegate void LockedChange(bool state);
		public event LockedChange LockedChengeEvent;

		public delegate void ItemListChanged(List<T> itemList, int position);
		public event ItemListChanged ItemListChangedEvent;

		public void ItemListChangedMasterEvent(List<T> itemList, int position)
		{
			ItemListChangedEvent?.Invoke(itemList, position);
		}
		public void ItemStartedMasterEvent(List<T> itemList, int position)
		{
			ItemListChangedEvent?.Invoke(itemList, position);
		}
		const int MAX_VOLUME = 100;
		const int MIN_VOLUME = 0;

		private int _volume;
		private bool _locked;
		protected bool _playing;
		public bool Locked { get { return _locked; } }
		public bool Repeat { get; private set; }
		public bool Shaffle { get; private set; }

		public List<T> PlayingItemsList = new List<T>();

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
				if (value < MIN_VOLUME)
				{
					_volume = MIN_VOLUME;
				}
				else if (value > MAX_VOLUME)
				{
					_volume = MAX_VOLUME;
				}
				else
				{
					_volume = value;
				}
			}
		}
		public GenericPlayer()
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
			if (_locked)
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
			if (_locked)
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
		public abstract bool Play();

		public abstract bool Stop();
		
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

		public abstract void Load(string filepath);

	}
}
