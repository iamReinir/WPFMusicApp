using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN_Final.Models;
using Microsoft.AspNetCore.Identity;

namespace PRN_Final.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly MusicAppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public RegisterModel(MusicAppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [BindProperty]
        public RegisterViewModel RegisterInfo { get; set; }

        public class RegisterViewModel
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Method intentionally left empty.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                UserName = RegisterInfo.UserName,
                Email = RegisterInfo.Email
            };

            // Hash the password
            user.PasswordHash = _passwordHasher.HashPassword(user, RegisterInfo.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Auth/Login");
        }
    }
}
