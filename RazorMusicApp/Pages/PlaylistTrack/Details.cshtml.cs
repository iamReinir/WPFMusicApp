using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN_Final.Models;

namespace PRN_Final.Pages_PlaylistTrack
{
    public class DetailsModel : PageModel
    {
        private readonly PRN_Final.Models.MusicAppDbContext _context;

        public DetailsModel(PRN_Final.Models.MusicAppDbContext context)
        {
            _context = context;
        }

        public PlaylistTrack PlaylistTrack { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlisttrack = await _context.PlaylistTracks.FirstOrDefaultAsync(m => m.Id == id);
            if (playlisttrack == null)
            {
                return NotFound();
            }
            else
            {
                PlaylistTrack = playlisttrack;
            }
            return Page();
        }
    }
}
