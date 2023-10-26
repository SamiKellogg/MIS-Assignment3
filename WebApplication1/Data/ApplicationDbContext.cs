using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Movie>? Movie { get; set; }
        public DbSet<WebApplication1.Models.actors>? actors { get; set; }
        public DbSet<WebApplication1.Models.ActorMovie>? ActorMovie { get; set; }
    }
}