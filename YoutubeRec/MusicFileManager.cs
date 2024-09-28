using Model;
using System.Collections.Concurrent;

namespace YoutubeRec
{
	public class MusicFileManager // State machine
	{
		public IEnumerable<MusicFile> SavedData(IEnumerable<Song> songList) 
		{
			return songList.Select(song => MusicFile.From(converter, song));
		}
		public ConcurrentBag<MusicFile> FileList { get; set; } = new();	
		Convert converter;
		public string outputfolder = "./mpeg";
		public MusicFileManager(string apiKey, string outputto = null)
		{
			converter = new Convert(apiKey);			
			outputfolder = outputto ?? outputfolder;
			converter.output_folder = outputfolder;
		}		
		public async Task StartSearch(string q, int count)
		{
			YouTubeSearchResult searchResult;
			converter.videoCount = count;			
			searchResult = await converter.Search(q);
			if(searchResult != null)
				FileList = new ConcurrentBag<MusicFile>
					(searchResult.Items.Select(item => new MusicFile(converter, item)));
		}
		public async Task StartDownload()
		{
			await StartDownload(FileList.Select(file => file.Id).ToArray());
		}
		public async Task StartDownload(params string[] videoIds)
		{			
			List<Task> downloadTasks =  new List<Task>();
			foreach (var video in videoIds)
			{
				var file = FileList.FirstOrDefault(v => v.Id?.Equals(video) ?? false);
				if(file != null) downloadTasks.Add(Task.Run(file.Download));
			}
			await Task.WhenAll(downloadTasks.ToArray());			
		}
	}

	public class MusicFile //State machine
	{
		protected Convert converter;
		public Action WhenFinishedDownload;
		public MusicFile(Convert converter)
		{
			this.converter = converter;
		}
		public MusicFile(Convert converter, Item video)
		{
			this.converter = converter;	
			this.Id = video.Id.VideoId;
			this.Path = $"{converter.output_folder}/{Id}.mp3";
			Infomation = video.Snippet;			
			CurrentState = State.NotDownloaded;

		}
		public enum State
		{
			NotDownloaded = 0,
			Downloaded = 1,
			Downloading = 2,
			CantDownload = 3
		}
		public async Task Download()
		{
			if (CurrentState == State.CantDownload || CurrentState == State.Downloading)
				return;
			if (File.Exists(Path))
			{
				CurrentState = State.Downloaded;
				WhenFinishedDownload?.Invoke();
				return;
			}
			CurrentState = State.Downloading;
			await converter.DownloadVideoAsMp3(Id);
			if (File.Exists(Path))
			{
				CurrentState = State.Downloaded;
				WhenFinishedDownload?.Invoke();
			}
			else
				CurrentState = State.CantDownload;
		}		

		public void Delete()
		{
			converter.Delete(Id);
			CurrentState = State.NotDownloaded;
		}

		public bool isAvailable()
		{
			return File.Exists(Path);
		}

		public bool CantDownload()
		{
			return CurrentState == State.CantDownload;
		}
		public string Path { get; init; }
		public string Id { get; init; }
		public Snippet Infomation { get; init; }		
		public State CurrentState { get; set;}
		public bool IsPlaying { get; set; } = false;

		public static Song ToSong(MusicFile file)
		{
			return new Song
			{
				Path = file.Path,
				Id = file.Id,				
				ChannelId = file.Infomation.ChannelId,
				ChannelTitle = file.Infomation.ChannelTitle,
				CurrentState = file.CurrentState switch
				{					
					State.Downloaded => 1,
					State.Downloading => 2,
					State.CantDownload => 3,
					_ => 0,
				},
				Description = file.Infomation.Description,
				LiveBroadcastContent = file.Infomation.LiveBroadcastContent,
				PublishedAt = file.Infomation.PublishedAt,
				PublishTime = file.Infomation.PublishTime,
				Thumbnail_default_Height = file.Infomation.Thumbnails.Default.Height,
				Thumbnail_default_Url = file.Infomation.Thumbnails.Default.Url,
				Thumbnail_default_Width = file.Infomation.Thumbnails.Default.Width,
				Thumbnail_medium_Height = file.Infomation.Thumbnails.Medium.Height,
				Thumbnail_medium_Url = file.Infomation.Thumbnails.Medium.Url,
				Thumbnail_medium_Width = file.Infomation.Thumbnails.Medium.Width,
				Thumbnail_high_Height = file.Infomation.Thumbnails.High.Height,
				Thumbnail_high_Url = file.Infomation.Thumbnails.High.Url,
				Thumbnail_high_Width = file.Infomation.Thumbnails.High.Width,
				Title = file.Infomation.Title				
			};
		}
		public static MusicFile From(Convert converter, Song song)
		{
			return new MusicFile(converter)
			{
				Id = song.Id,
				Infomation = new Snippet
				{
					ChannelId = song.ChannelId,
					ChannelTitle = song.ChannelTitle,
					Description = song.Description,
					LiveBroadcastContent = song.LiveBroadcastContent,
					PublishedAt = song.PublishedAt,
					PublishTime = song.PublishTime,
					Thumbnails = new Thumbnails()
					{
						Default = new Thumbnail
						{
							Height = song.Thumbnail_default_Height,
							Url = song.Thumbnail_default_Url,
							Width = song.Thumbnail_default_Width,
						},
						Medium = new Thumbnail
						{
							Height = song.Thumbnail_medium_Height,
							Url = song.Thumbnail_medium_Url,
							Width = song.Thumbnail_medium_Width,
						},
						High = new Thumbnail
						{
							Height = song.Thumbnail_high_Height,
							Url = song.Thumbnail_high_Url,
							Width = song.Thumbnail_high_Width,
						}
					},
					Title = song.Title,
				},
				CurrentState = song.CurrentState switch
				{
					1 => State.Downloaded,
					2 => State.Downloading,
					3 => State.CantDownload,
					_ => State.NotDownloaded,
				},
				Path = song.Path,
				IsPlaying = false
			};
		}
	}	
}
