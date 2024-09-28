using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace SoundRockWebAPI.Controllers
{
	[ApiController]
	[Route("/register")]
	public class RegisterController : Controller
	{
		RockContext context;
		public RegisterController(RockContext context) {
			this.context = context;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]AppUser newUser)
		{
			var message = new StringBuilder();
			var result = new LoginResult
			{
				Success = false,
				Username = newUser.Username,
				Msg = string.Empty,
			};
			if(await context.Users.FirstOrDefaultAsync(user => user.Username.Equals(newUser.Username)) != null)
			{
				message.Append("This username is used by another user. Please choose another.");
			}
			var pwLen = AppUser.MinPasswordLength;
			if(newUser.Password.Length < pwLen)
			{
				message.Append($"The password you choose is too short." +
					$" Please make it at least {pwLen} characters long.");
			}
			if(message.Length <= 0)
			{
				message.Append("Register successfully");
				result.Success = true;
			}
			result.Msg = message.ToString();
			return Json(result);
		}
	}


}
