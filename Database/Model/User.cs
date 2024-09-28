using Microsoft.EntityFrameworkCore;

namespace Database.Model
{
	[PrimaryKey(nameof(User.Username))]
	public class User
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
