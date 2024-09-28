using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace SoundRockWebAPI.Controllers
{
	[ApiController]
	[Route("/login")]
	public class LoginController : Controller
	{
		RockContext context;
		public LoginController(RockContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Content("hello there");
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] AppUser login)
		{			
			var curUser = await context.Users
				.FirstOrDefaultAsync(user => user.Username.Equals(login.Username) && user.Password.Equals(login.Password));
			var result = new LoginResult
			{
				Success = curUser != null,
				Username = curUser?.Username,
				Msg = curUser != null ? "Login Success" : "Username or Password is wrong."
			};
			if (result.Success)
			{
				HttpContext.Session.SetString(Session.Username, login.Username);
			}
			return Json(result);
		}
	}
}
