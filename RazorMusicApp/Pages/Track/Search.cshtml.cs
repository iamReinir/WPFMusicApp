using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Final.Models;
using PRN_Final.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Newtonsoft.Json;
using PRN_Final.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace PRN_Final.Pages_Track
{    
    public class SearchModel : PageModel
    {
        private readonly YoutubeService _youtubeService;
        private readonly MusicAppDbContext _dbContext;
        private readonly IHubContext<MusicHub> _hubContext;

        public SearchModel(YoutubeService youtubeService, MusicAppDbContext dbContext, IHubContext<MusicHub> hubContext)
        {
            _youtubeService = youtubeService;
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        [BindProperty]
        public string SearchQuery { get; set; }

        public List<PRN_Final.Models.Track> SearchResults
        {
            get
            {
                if (TempData["SearchResults"] is not string serializedSearchResults) return [];
                return JsonConvert.DeserializeObject<List<Models.Track>>(serializedSearchResults);
            }
            set
            {
                TempData["SearchResults"] = JsonConvert.SerializeObject(value);
            }
        }

        public void OnGet()
        {
            // Method intentionally left empty.
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                var youtubeTracks = await _youtubeService.SearchTracksAsync(SearchQuery);

                foreach (var track in youtubeTracks)
                {
                    var existingTrack = await _dbContext.Tracks.FirstOrDefaultAsync(t => t.YouTubeId == track.YouTubeId);

                    if (existingTrack == null)
                    {
                        _dbContext.Tracks.Add(track);
                    }
                }

                await _dbContext.SaveChangesAsync();

                SearchResults = youtubeTracks;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToPlaylistAsync(string youtubeId)
        {
            if (string.IsNullOrEmpty(youtubeId))
            {
                return BadRequest("YouTube ID is required.");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var track = await _dbContext.Tracks.FirstOrDefaultAsync(t => t.YouTubeId == youtubeId);

            if (track == null)
            {
                return NotFound($"Track with YouTubeId '{youtubeId}' not found.");
            }

            var playlist = await _dbContext.Playlists.FirstOrDefaultAsync(p => p.UserId == userId && p.Name == "My New Playlist");

            if (playlist == null)
            {
                playlist = new PRN_Final.Models.Playlist
                {
                    Name = "My New Playlist",
                    CreatedAt = DateTime.Now,
                    UserId = userId
                };

                _dbContext.Playlists.Add(playlist);
                await _dbContext.SaveChangesAsync();
            }

            var existingPlaylistTrack = await _dbContext.PlaylistTracks
                .FirstOrDefaultAsync(pt => pt.PlaylistId == playlist.Id && pt.TrackId == track.Id);

            if (existingPlaylistTrack != null)
            {
                TempData["InfoMessage"] = $"Track '{track.Title}' is already in your playlist.";
            }
            else
            {
                // Nếu chưa có, thêm track vào playlist
                var playlistTrack = new PRN_Final.Models.PlaylistTrack
                {
                    PlaylistId = playlist.Id,
                    TrackId = track.Id,
                    AddedAt = DateTime.Now
                };

                _dbContext.PlaylistTracks.Add(playlistTrack);
                await _dbContext.SaveChangesAsync();

                // Gửi thông báo qua SignalR
                await _hubContext.Clients.All.SendAsync("TrackAdded", playlist.Id, track.Id, track.Title);

                TempData["SuccessMessage"] = $"Track '{track.Title}' has been successfully added to the playlist.";
            }

            return Page();
        }
    }
}
