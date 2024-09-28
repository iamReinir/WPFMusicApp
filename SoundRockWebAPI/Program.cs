using Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<RockContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSession();
app.Run();
