using System.ComponentModel.DataAnnotations;

namespace PRN_Final.Models
{
  public class Playlist
  {
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string UserId { get; set; }
    public User User { get; set; }

    public bool IsPublic { get; set; }

    public ICollection<PlaylistTrack> PlaylistTracks { get; set; }

  }
}