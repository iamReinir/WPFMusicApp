using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN_Final.Models;

namespace PRN_Final.Pages_PlaylistTrack
{
    public class CreateModel : PageModel
    {
        private readonly PRN_Final.Models.MusicAppDbContext _context;

        public CreateModel(PRN_Final.Models.MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlaylistId"] = new SelectList(_context.Playlists, "Id", "Name");
        ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public PlaylistTrack PlaylistTrack { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlaylistTracks.Add(PlaylistTrack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
