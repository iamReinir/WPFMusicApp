using Microsoft.AspNetCore.Mvc;

namespace SoundRockWebAPI.Controllers
{
	[ApiController]
	[Route("/song")]
	public class SongController : Controller
	{
		public SongController(RockContext rockContext)
		{

		}
		[HttpGet]
		public IActionResult Index([FromRoute]string name, [FromRoute]string genre)
		{
			var normalizeGenre = genre.Trim().ToUpper();
			if (!string.IsNullOrEmpty(normalizeGenre))

			return View();
		}
	}
}
