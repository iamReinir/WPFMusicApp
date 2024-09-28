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
    public class DeleteModel : PageModel
    {
        private readonly PRN_Final.Models.MusicAppDbContext _context;

        public DeleteModel(PRN_Final.Models.MusicAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist != null)
            {
                Playlist = playlist;
                _context.Playlists.Remove(Playlist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
