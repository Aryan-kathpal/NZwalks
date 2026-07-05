using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models;

namespace NZwalks.API.Data
{
    public class WalksDbContext : DbContext
    {
        public WalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dificultiesData = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("7FFF13B2-E8D9-4ADE-A749-17C7A473D78F"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("8FFF13B2-E8D9-4ADE-A749-17C7A473D78F"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("9FFF13B2-E8D9-4ADE-A749-17C7A473D78F"),
                    Name = "Difficult"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(dificultiesData);

        }
    }
}
