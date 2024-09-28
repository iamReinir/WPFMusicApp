namespace PRN_Final.Models
{
  public class PlaylistTrack
  {
    public int Id { get; set; }

    public int PlaylistId { get; set; }
    public Playlist Playlist { get; set; }

    public int TrackId { get; set; }
    public Track Track { get; set; }

    public int Order { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.Now;
  }
}