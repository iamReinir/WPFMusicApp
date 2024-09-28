using Newtonsoft.Json;
using System.Text;

namespace YoutubeRec
{
	public class Convert
	{
		string api_key;
		string url = "https://www.googleapis.com/youtube/v3/search";
		string log_file = "ConvertLog.txt";
		public int videoCount = 25;
		public string output_folder = "mpeg";
		
		public Convert(string api_key)
		{
			this.api_key = api_key;		
			CreateDirectoryIfNotExists(output_folder);
		}
		static void CreateDirectoryIfNotExists(string path)
		{
			try
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);					
				}				
			}
			catch (Exception e)
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}

		public async Task<YouTubeSearchResult?> Search(string query)
		{
			StringBuilder searchUrl = new StringBuilder();
			searchUrl.Append(url);
			searchUrl.Append($"?key={api_key}&part=snippet&maxResults={videoCount}&type=video");
			searchUrl.Append("&q=");
			searchUrl.Append(query);
			var client = new HttpClient();
			var req = await client.GetAsync(searchUrl.ToString());
			YouTubeSearchResult results = new();
			if (req.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var content = await req.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<YouTubeSearchResult>(content);									
			}
			else
			{
				return null;
			}
		}
		public async Task SearchAndDownload(string query)
		{
			StringBuilder searchUrl = new StringBuilder();
			searchUrl.Append(url);
			searchUrl.Append($"?key={api_key}&part=snippet&maxResults={videoCount}");
			searchUrl.Append("&q=");
			searchUrl.Append(Uri.EscapeDataString(query));
			var client = new HttpClient();
			var req = await client.GetAsync(searchUrl.ToString());
			YouTubeSearchResult results = new();
			if(req.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var content = await req.Content.ReadAsStringAsync();				
				results = JsonConvert.DeserializeObject<YouTubeSearchResult>(content) 
					?? new YouTubeSearchResult();
				Task.WaitAll(BatchDownload(results).ToArray());
			}
			else
			{
				Console.WriteLine($"Error when search with query {query}");
			}
		}
		IEnumerable<Task> BatchDownload(YouTubeSearchResult results)
		{
			foreach (var video in results.Items)
				yield return DownloadVideoAsMp3(video.Id.VideoId);
		}
		public async Task DownloadVideoAsMp3(YoutubeRec.Item video)
		{
			await DownloadVideoAsMp3(video.Id.VideoId);			
		}
		public async Task DownloadVideoAsMp3(string id)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = $"/C cd {output_folder} & \"convert.bat\" {id}";
			process.StartInfo = startInfo;
			process.Start();
			await process.WaitForExitAsync();
		}
		public void Delete(string id)
		{
			try
			{
				File.Delete($"{output_folder}/{id}.mp3");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while deleting file : " + ex.ToString());
			}
		}
	}
}
