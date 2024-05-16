using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
