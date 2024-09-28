using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PRN_Final.Models
{
  public class User : IdentityUser
  {
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string ProfilePicture { get; set; }

    public ICollection<Playlist> Playlists { get; set; }
  }
}