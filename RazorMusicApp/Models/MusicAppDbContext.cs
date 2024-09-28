using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace PRN_Final.Models
{
  public class MusicAppDbContext : IdentityDbContext<User>
  {
    public MusicAppDbContext(DbContextOptions<MusicAppDbContext> options) : base(options) { }

    public DbSet<Track> Tracks { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<PlaylistTrack> PlaylistTracks { get; set; }
    public DbSet<Song> Song { get; set; }
  }
}