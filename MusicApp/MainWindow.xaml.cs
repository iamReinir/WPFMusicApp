using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Tar;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WMPLib;
using YoutubeRec;


namespace MusicApp
{
	public partial class MainWindow : Window
    {
		public class MusicItem
		{
			public MusicFile Data { get; set; }
			public MahApps.Metro.IconPacks.PackIconMaterialKind Kind { get; set; }
		}
        public ObservableCollection<MusicItem> list { get; set; }        
        public Music current;
		const string data = "data.dat";
		Func<int, int> NextSongIndex = (x) => x + 1;
        public Music CurrentSong { get => current; 
            
            set {
                current = value;
				StopPlaying();
				txtCurrentArtist.Text = value.Author;
				txtCurrentTitle.Text = value.Title;
				imgThumbnail.ImageSource = new BitmapImage(new Uri(value.Thumb, UriKind.Absolute));
				mediaElement.Source = new System.Uri(value.Path, System.UriKind.Relative);
                } 
        }
        public MainWindow()
        {
            InitializeComponent();            
            Global.RebindResult = () =>
            {                
                listResult.ItemsSource = Global.searchResults;             
            };
			PlaylistRefresh();
			mediaElement.MediaEnded += (obj,e) => NextButton_Click(obj, e);
		}
		private void PlaylistRefresh()
		{
			list = new ObservableCollection<MusicItem>(Global.Playlist.Select(item => new MusicItem
			{
				Data = item.Value,
				Kind = item.Value.isAvailable() ? MahApps.Metro.IconPacks.PackIconMaterialKind.Play
				: MahApps.Metro.IconPacks.PackIconMaterialKind.Download
			}));
			listHistory.ItemsSource = list;
		}
        public void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if( e.ChangedButton == MouseButton.Left )
            {
                this.DragMove();
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
        }

        bool playing = false;

		private void StopPlaying()
		{
			mediaElement.Stop();
			btnPauseIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;
			playing = false;
		}
		private void OnPause(object sender, RoutedEventArgs e)
		{			
			foreach(var item in Global.Playlist)
			{
				item.Value.IsPlaying = false;
				if (item.Key.Equals(CurrentSong?.Id))
				{
					item.Value.IsPlaying = true;
				}
			}
			PlaylistRefresh();
			if (playing)
            {
				mediaElement.Pause();
				btnPauseIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Play;
				playing = false;                
            }
            else 
            {                				
				mediaElement.Play();				
				btnPauseIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Pause;
				playing = true;
            }            
		}

		private async void PlaySong(object sender, RoutedEventArgs e)
		{
			var songId = ((Button)sender).Tag.ToString();			
			var curFile = Global.Manager.FileList.FirstOrDefault(file => file.Id.Equals(songId));
			if (Global.Playlist.TryGetValue(songId, out var _) == false)
			{
				Global.Playlist.TryAdd(curFile.Id,curFile);				
				curFile.Download();
			}
			PlaylistRefresh();
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			var thisSong = list.FirstOrDefault(i => i.Data.Id.Equals(CurrentSong.Id));
			if (thisSong != null)
			{
				var index = list.IndexOf(thisSong);
				index = NextSongIndex(index);
				if (index >= list.Count)
				{
					index = 0;
				}				
				var nextSong = list.ElementAtOrDefault(index).Data;				
				CurrentSong = new Music
				{
					Author = nextSong.Infomation.ChannelTitle,
					Id = nextSong.Id,
					Path = nextSong.Path,
					Title = nextSong.Infomation.Title,
					Thumb = nextSong.Infomation.Thumbnails.High.Url
				};				
			}
			OnPause(null, null);
		}

		private void PrevButton_Click(object sender, RoutedEventArgs e)
		{
			var thisSong = list.FirstOrDefault(i => i.Data.Id.Equals(CurrentSong.Id));			
			if (thisSong != null)
			{
				var index = list.IndexOf(thisSong);
				if (index <= 0)
				{
					index = list.Count - 1;
				}
				else --index;
				var nextSong = list.ElementAtOrDefault(index).Data;
				CurrentSong = new Music
				{
					Author = nextSong.Infomation.ChannelTitle,
					Id = nextSong.Id,
					Path = nextSong.Path,
					Title = nextSong.Infomation.Title,
					Thumb = nextSong.Infomation.Thumbnails.High.Url
				};				
			}			
			OnPause(null, null);
		}

		enum RepeatType
		{
			Repeat,
			RepeatOff,
			RepeatOne
		}
		bool repeat = true;

		private void RepeatType_Click(object sender, RoutedEventArgs e)
		{
			if (repeat)
			{
				repeat = false;
				btnRepeatIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.RepeatOnce;
				if (shuffle) ShuffleType_Click(null, null);
				NextSongIndex = (x) => x;
			}
			else
			{
				repeat = true;
				btnRepeatIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Repeat;
				if (shuffle) ShuffleType_Click(null, null);
				NextSongIndex = (x) => x + 1;
			}
			PlaylistRefresh();
		}
		bool shuffle = false;
		private void ShuffleType_Click(object sender, RoutedEventArgs e)
		{
			if (shuffle)
			{
				btnShuffleIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.ShuffleDisabled;
				NextSongIndex = (x) => x + 1;
				shuffle = false;
			}
			else
			{
				Random rng = new Random();
				btnShuffleIcon.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Shuffle;
				NextSongIndex = (x) => rng.Next(0,list.Count);
				shuffle = true;
			}
			
		}

		protected override void OnClosed(EventArgs e)
		{
			Global.Context.Database.ExecuteSqlRaw("delete from Song");
			Global.Context.ChangeTracker.Clear();
			Global.Context.Song.AddRange(Global.Playlist.Select(x => MusicFile.ToSong(x.Value)));
			Global.Context.SaveChanges();
			base.OnClosed(e);
			Global.Worker.ClearUp();
		}	

		private void Minimize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}		

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void PlayThis_Click(object sender, RoutedEventArgs e)
		{
			var id = ((Button)sender).Tag;
			var nextSong = list.FirstOrDefault(x => x.Data.Id.Equals(id)).Data;
			if (nextSong == null || nextSong.CantDownload())
			{
				MessageBox.Show("This song cannot be download. Please choose another song.");
				return;
			}
			if (!nextSong.isAvailable())
			{
				nextSong.Download();				
				MessageBox.Show("This song is being downloaded at the moment. Please wait.");
				return;
			}
			StopPlaying();
			CurrentSong = new Music
			{
				Author = nextSong.Infomation.ChannelTitle,
				Id = nextSong.Id,
				Path = nextSong.Path,
				Title = nextSong.Infomation.Title,
				Thumb = nextSong.Infomation.Thumbnails.High.Url
			};
			OnPause(null, null);
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			var id = ((Button)sender).Tag as string;
			Global.Playlist.TryRemove(id, out var x);		
			if (CurrentSong.Id.Equals(id))
			{
				NextButton_Click(null, null);
			}
			PlaylistRefresh();
        }
	}	
}
