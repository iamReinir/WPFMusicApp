using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRN_Final.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PRN_Final.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly MusicAppDbContext _context;

        public LoginModel(ILogger<LoginModel> logger, MusicAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public LoginViewModel LoginInfo { get; set; }

        public class LoginViewModel
        {
            public string Username { get; set; }
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

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == LoginInfo.Username);

            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, LoginInfo.Password);

                if (result == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, user.UserName),
                        new(ClaimTypes.NameIdentifier, user.Id)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

                    _logger.LogInformation("User {Username} logged in at {Time}.", user.UserName, DateTime.UtcNow);
                    return RedirectToPage("/Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
