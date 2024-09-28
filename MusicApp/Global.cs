using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeRec;
namespace MusicApp
{
	public static class Global
	{
		static Global()
		{
			var configBuilder = new ConfigurationBuilder();
			Configuration = configBuilder.AddJsonFile("appsettings.json").Build();
			Manager = new MusicFileManager(Configuration["ApiKey"], Configuration["MusicFolder"]);
			Context = new MusicContext()
			{
				ConnString = Configuration["ConnectionString"],
			};
			foreach (var song in Global.Manager.SavedData(Global.Context.Song.AsEnumerable()))
			{
				Playlist.TryAdd(song.Id, song);
				if (!song?.isAvailable() ?? false) song.Download();
			}
			Worker = new FolderWorker();
			Task.Run(Worker.PeriodCleanUp);
		}
		public static IConfiguration Configuration { get; set; }
		public static MusicFileManager Manager { get; private set; }
		public static ObservableCollection<Music> searchResults { get; set; } = new();
		public static ConcurrentDictionary<string, MusicFile> Playlist { get; set; } = new();
		public static Action RebindResult { get; set; }
		public static Action<MusicFile> SetCurrentSong { get; set; }
		public static List<MusicFile> OldResult { get; set; } = new();
		public static MusicContext Context { get; set; } = new();
		public static FolderWorker Worker { get; set; }
	}


	public class Music
	{
		public string Id { get; set; }
		public string Path { get; set; }
		public int Index { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public string Thumb { get; set; } = "./Images/p2.jpg";
	}

	public static class Ultility
	{
		private static Random rng = new Random();

		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}

	public class MusicContext : DbContext
	{
		public DbSet<Song> Song { get; set; }
		public string ConnString { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlite(ConnString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Song>(entity =>
				{
					entity.HasKey(e => e.Id);
				});
		}
	}
	public class FolderWorker
	{
		public void ClearUp()
		{
			try
			{
				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.FileName = "cmd.exe";
				startInfo.Arguments = "/C taskill /IM ffmpeg.exe /F";
				process.StartInfo = startInfo;
				process.Start();
				process.WaitForExit();
				var toNOTdelete = Global.Playlist.Select(x => x.Key + ".mp3")
					.Concat(Global.searchResults.Select(result => result.Id + ".mp3"))
					.ToList();
				System.IO.DirectoryInfo di = new DirectoryInfo(Global.Manager.outputfolder);
				foreach (FileInfo file in di.GetFiles())
				{
					if (toNOTdelete.Contains(file.Name)) continue;					
					file.Delete();
				}				
			}
			catch (Exception ex)
			{
				// Ignore exceptions
			}			
		}

		public async Task PeriodCleanUp()
		{
			while (true)
			{
				var toNOTdelete = Global.Playlist.Select(x => x.Key + ".mp3")
					.Concat(Global.searchResults.Select(result => result.Id + ".mp3"))
					.ToList();
				System.IO.DirectoryInfo di = new DirectoryInfo(Global.Manager.outputfolder);
				foreach (FileInfo file in di.GetFiles())
				{
					if (toNOTdelete.Contains(file.Name)) continue;
					try
					{
						file.Delete();
					}
					catch 
					{
						// Ignore exceptions
					}
				}
				await Task.Delay(TimeSpan.FromSeconds(300));
			}
		}
	}
}
