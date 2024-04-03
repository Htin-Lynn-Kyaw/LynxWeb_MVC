using LynxWebRazor.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LynxWebRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { ID = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { ID = 3, Name = "Horror", DisplayOrder = 3 }
                );
        }
    }
}
