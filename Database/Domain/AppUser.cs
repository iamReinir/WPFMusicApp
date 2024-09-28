namespace Domain
{
	public class AppUser
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public const int MinPasswordLength = 6;
	}
}
