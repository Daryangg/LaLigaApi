using LaligaInformationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaligaInformationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Team> Teams {  get; set; }
        public DbSet<Team> Players { get; set; }
    }
}
