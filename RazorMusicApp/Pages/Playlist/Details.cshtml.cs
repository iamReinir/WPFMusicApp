using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN_Final.Models;

namespace PRN_Final.Pages_Playlist
{
    public class DetailsModel : PageModel
    {
        private readonly PRN_Final.Models.MusicAppDbContext _context;

        public DetailsModel(PRN_Final.Models.MusicAppDbContext context)
        {
            _context = context;
        }

        public Playlist Playlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists.FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }
            else
            {
                Playlist = playlist;
            }
            return Page();
        }
    }
}
