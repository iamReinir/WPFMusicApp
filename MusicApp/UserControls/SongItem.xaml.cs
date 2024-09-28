using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicApp.UserControls
{
    public partial class SongItem : UserControl
    {
        public SongItem()
        {
            InitializeComponent();
        }

		public string Id
		{
			get { return (string)GetValue(IdProperty); }
			set { SetValue(IdProperty, value); }
		}

		public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
			"Id", typeof(string), typeof(SongItem));
		public string Path
		{
			get { return (string)GetValue(PathProperty); }
			set { SetValue(PathProperty, value); }
		}

		public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
			"Path", typeof(string), typeof(SongItem));
		public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(SongItem));


		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
			"Image", typeof(ImageSource), typeof(SongItem));


		public string Channel
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
            "Channel", typeof(string), typeof(SongItem));


        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
            "IsActive", typeof(bool), typeof(SongItem));

    }
}
