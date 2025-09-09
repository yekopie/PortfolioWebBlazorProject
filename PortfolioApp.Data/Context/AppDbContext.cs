using Microsoft.EntityFrameworkCore;
using PortfolioApp.Data.Entities;

namespace PortfolioApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
 
    }
}