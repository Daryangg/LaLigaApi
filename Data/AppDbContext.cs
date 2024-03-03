using LaligaInformationApi.Models;
using LaLigaInformationApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaligaInformationApi.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options) { }
        public DbSet<Team> Teams {  get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
