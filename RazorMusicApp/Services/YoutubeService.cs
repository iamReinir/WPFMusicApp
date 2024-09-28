using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PRN_Final.Models;

namespace PRN_Final.Services
{
    public class YoutubeService
    {
        private readonly HttpClient _httpClient;
        private const string YoutubeApiBaseUrl = "https://www.googleapis.com/youtube/v3/";
        private readonly string _apiKey;

        public YoutubeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["AppSettings:YouTubeApiKey"];
        }

        public async Task<List<Track>> SearchTracksAsync(string query)
        {
            try
            {
                string requestUrl = $"{YoutubeApiBaseUrl}search?part=snippet&q={Uri.EscapeDataString(query)}&type=video&maxResults=5&key={_apiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var youtubeResponse = JsonConvert.DeserializeObject<YoutubeSearchResponse>(content);

                    List<Track> tracks = new List<Track>();
                    foreach (var item in youtubeResponse.Items)
                    {
                        Track track = new Track
                        {
                            Title = item.Snippet.Title,
                            YouTubeId = item.Id.VideoId,
                            Duration = 0, 
                            ThumbnailUrl = item.Snippet.Thumbnails.Default.Url,
                            AddedAt = DateTime.Now 
                        };

                        tracks.Add(track);
                    }

                    return tracks;
                }
                else
                {
                    throw new HttpRequestException($"Failed to retrieve data from YouTube API. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while calling YouTube API: {ex.Message}");
            }
        }

        private class YoutubeSearchResponse
        {
            public List<YoutubeSearchItem> Items { get; set; }
        }

        private class YoutubeSearchItem
        {
            public string Kind { get; set; }
            public string Etag { get; set; }
            public YoutubeVideoSnippet Snippet { get; set; }
            public YoutubeVideoId Id { get; set; }
        }

        private class YoutubeVideoSnippet
        {
            public string PublishedAt { get; set; }
            public string ChannelId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public YoutubeThumbnail Thumbnails { get; set; }
            public string ChannelTitle { get; set; }
        }

        private class YoutubeThumbnail
        {
            public YoutubeThumbnailDetails Default { get; set; }
        }

        private class YoutubeThumbnailDetails
        {
            public string Url { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private class YoutubeVideoId
        {
            public string Kind { get; set; }
            public string VideoId { get; set; }
        }
    }
}
