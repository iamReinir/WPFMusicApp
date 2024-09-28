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
    public class IndexModel : PageModel
    {
        private readonly PRN_Final.Models.MusicAppDbContext _context;

        public IndexModel(PRN_Final.Models.MusicAppDbContext context)
        {
            _context = context;
        }

        public IList<PlaylistTrack> PlaylistTrack { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PlaylistTrack = await _context.PlaylistTracks
                .Include(p => p.Playlist)
                .Include(p => p.Track).ToListAsync();
        }
    }
}
