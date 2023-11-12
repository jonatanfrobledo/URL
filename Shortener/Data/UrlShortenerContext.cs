using Microsoft.EntityFrameworkCore;
using UrlShortener.Entities;
namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<URL> Urls { get; set; }

    }
}
