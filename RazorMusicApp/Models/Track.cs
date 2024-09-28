using System.ComponentModel.DataAnnotations;

namespace PRN_Final.Models
{
  public class Track
  {
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Title { get; set; }
    [Required, StringLength(11)] // YouTube video ID length
    public string YouTubeId { get; set; }
    public int Duration { get; set; } // Duration in seconds
    public string ThumbnailUrl { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;

    public ICollection<PlaylistTrack> PlaylistTracks { get; set; }
  }
}