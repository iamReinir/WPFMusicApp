using Microsoft.EntityFrameworkCore;

namespace Model
{
	[PrimaryKey(nameof(Id))]
	public class Song
	{
		public string Path { get; init; }
		public string Id { get; init; }
		public DateTime PublishedAt { get; set; }
		public string ChannelId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Thumbnail_default_Url { get; set; }
		public int Thumbnail_default_Width { get; set; }
		public int Thumbnail_default_Height { get; set; }
		public string Thumbnail_medium_Url { get; set; }
		public int Thumbnail_medium_Width { get; set; }
		public int Thumbnail_medium_Height { get; set; }
		public string Thumbnail_high_Url { get; set; }
		public int Thumbnail_high_Width { get; set; }
		public int Thumbnail_high_Height { get; set; }
		public string ChannelTitle { get; set; }
		public string LiveBroadcastContent { get; set; }
		public DateTime PublishTime { get; set; }
		public int CurrentState { get; set; }
	}
}
