using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using YoutubeRec;

namespace MusicApp.UserControls
{

    public partial class SearchBox : UserControl
    {        
        public SearchBox()
        {
            InitializeComponent();
        }
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            "IsActive", typeof(bool), typeof(SearchBox));	

		private async void ButtonClick(object sender, RoutedEventArgs e)
		{
            Global.OldResult = new List<MusicFile>(Global.Manager.FileList);
            await Global.Manager.StartSearch(txtQuery.Text,5);
            Global.searchResults = new ObservableCollection<Music>(Global.Manager.FileList.Select((x, i) => new Music
            {
                Index = i + 1,
                Id = x.Id,
                Path = x.Path,
                Title = x.Infomation.Title,
                Author = x.Infomation.ChannelTitle,
                Thumb = x.Infomation.Thumbnails.Default.Url
            }).ToList());
            if (Global.RebindResult != null) Global.RebindResult();           
		}

		private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
                ButtonClick(null, null);
			}
		}
    }
}
