using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN_Final.Models;
using Microsoft.AspNetCore.Identity;

namespace PRN_Final.Pages_Playlist
{
    public class CreateModel : PageModel
    {
        private readonly MusicAppDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public CreateModel(MusicAppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [BindProperty]
        public Playlist Playlist { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound("User not found."); // Handle case where user is not found
            }

            // Set user ID for the playlist
            Playlist.UserId = currentUser.Id;
            _dbContext.Playlists.Add(Playlist);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
