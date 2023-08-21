using Microsoft.EntityFrameworkCore;
using SkillServices.Data.DbModels;

namespace SkillServices.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillSubCategory> SkillSubCategories { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}