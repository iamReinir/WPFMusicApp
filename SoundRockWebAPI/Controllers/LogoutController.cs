using Microsoft.AspNetCore.Mvc;

namespace SoundRockWebAPI.Controllers
{
	public class LogoutController : Controller
	{
		[HttpPost]
		public void Index()
		{
			HttpContext.Session.Clear();
		}
	}
}
