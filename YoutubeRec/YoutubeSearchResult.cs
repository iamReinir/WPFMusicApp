namespace YoutubeRec
{
	public class YouTubeSearchResult
	{
		public string Kind { get; set; }
		public string Etag { get; set; }
		public string NextPageToken { get; set; }
		public string RegionCode { get; set; }
		public PageInfo PageInfo { get; set; }
		public List<Item> Items { get; set; }
	}

	public class PageInfo
	{
		public int TotalResults { get; set; }
		public int ResultsPerPage { get; set; }
	}

	public class Item
	{
		public string Kind { get; set; }
		public string Etag { get; set; }
		public Id Id { get; set; }
		public Snippet Snippet { get; set; }
	}

	public class Id
	{
		public string Kind { get; set; }
		public string VideoId { get; set; }
	}

	public class Snippet
	{
		public DateTime PublishedAt { get; set; }
		public string ChannelId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Thumbnails Thumbnails { get; set; }
		public string ChannelTitle { get; set; }
		public string LiveBroadcastContent { get; set; }
		public DateTime PublishTime { get; set; }
	}

	public class Thumbnails
	{
		public Thumbnail Default { get; set; }
		public Thumbnail Medium { get; set; }
		public Thumbnail High { get; set; }
	}

	public class Thumbnail
	{
		public string Url { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

}

/* 
 * 
 * {
      "kind": "youtube#searchResult",
      "etag": "P6VBNOCu0FT2CRsyZlJ7aVYVfic",
      "id": {
        "kind": "youtube#video",
        "videoId": "UnIhRpIT7nc"
      },
      "snippet": {
        "publishedAt": "2020-07-16T11:00:13Z",
        "channelId": "UCNElM45JypxqAR73RoUQ10g",
        "title": "稲葉曇『ラグトレイン』Vo. 歌愛ユキ",
        "description": "inabakumori - Lagtrain (Vo. Kaai Yuki) 稲葉曇です。 Playlist http://bit.ly/2D37VHA Spotify https://spoti.fi/3uInIo1 Apple Music ...",
        "thumbnails": {
          "default": {
            "url": "https://i.ytimg.com/vi/UnIhRpIT7nc/default.jpg",
            "width": 120,
            "height": 90
          },
          "medium": {
            "url": "https://i.ytimg.com/vi/UnIhRpIT7nc/mqdefault.jpg",
            "width": 320,
            "height": 180
          },
          "high": {
            "url": "https://i.ytimg.com/vi/UnIhRpIT7nc/hqdefault.jpg",
            "width": 480,
            "height": 360
          }
        },
        "channelTitle": "稲葉曇",
        "liveBroadcastContent": "none",
        "publishTime": "2020-07-16T11:00:13Z"
      }

*/