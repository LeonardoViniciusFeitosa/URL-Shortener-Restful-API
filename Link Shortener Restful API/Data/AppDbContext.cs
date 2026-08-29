using Link_Shortener_Restful_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Shortener_Restful_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
