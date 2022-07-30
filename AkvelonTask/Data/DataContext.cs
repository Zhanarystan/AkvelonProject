using AkvelonTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppTask>()
                .HasOne(t => t.Project);
        }
    }
}