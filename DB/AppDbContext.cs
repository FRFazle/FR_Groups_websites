using FR_Groups_websites.Models;
using Microsoft.EntityFrameworkCore;

namespace FR_Groups_websites.DB
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }


        public DbSet<LogoImage> logoImages { get; set; } = null!;




    }
}
