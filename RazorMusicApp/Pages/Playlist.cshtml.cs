using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN_Final.Models;
using System.Runtime.CompilerServices;

namespace PRN_Final.Pages
{
    public class PlaylistModel : PageModel
    {
        MusicAppDbContext dbContext;      
        public PlaylistModel(MusicAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<PRN_Final.Models.Track> SearchResults { get; set; }
        public void OnGet()
        {
            SearchResults = dbContext.Song.Select(s => new Models.Track
            {
                ThumbnailUrl = s.Thumbnail_high_Url,
                YouTubeId = s.Id,
                Title = s.Title
            }).ToList();            
        }
    }    
}
