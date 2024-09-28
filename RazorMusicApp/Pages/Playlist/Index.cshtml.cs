using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN_Final.Models;
using Microsoft.AspNetCore.Identity;

namespace PRN_Final.Pages_Playlist
{
    public class IndexModel : PageModel
    {
        private readonly MusicAppDbContext _dbContext;

        private readonly UserManager<User> _userManager;

        public IndexModel(MusicAppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;

        }

        public List<Playlist> Playlists { get; set; }
        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                // Load playlists for the current user
                Playlists = await _dbContext.Playlists
                    .Include(p => p.User)
                    .Where(p => p.UserId == currentUser.Id)
                    .ToListAsync();
            }
            else
            {
                // Handle case where user is not found
                // You can redirect or display an error message
                // For example:
                // return NotFound();
            }
        }
    }
}
