using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace SoundRockWebAPI
{
	public class RockContext : DbContext
	{
		string connectionString;
		public RockContext(IConfiguration config) {
			connectionString = config["ConnectionString"];			
		}
		public DbSet<Song> Songs { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(connectionString);
		}
	}
}
