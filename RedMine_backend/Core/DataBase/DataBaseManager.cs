using Microsoft.EntityFrameworkCore;
using RedMine_backend.Core.Entities;

namespace DataBaseManager
{
    namespace DataBaseManager
    {
        public class RedmineContext : DbContext
        {
            
            public DbSet<Managers> Managers { get; set; }
            public DbSet<Developers> Developers { get; set; }
            public DbSet<Tasks> Tasks { get; set; }
            public DbSet<ProjectDevelopers> ProjectDevelopers { get; set; }
            public DbSet<Projects> Projects { get; set; }
            public DbSet<ProjectTypes> ProjectTypes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=Redmine.db");

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Tasks>()
                    .HasOne(b => b.Managers)
                    .WithOne(a => a.Tasks) 
                    .HasForeignKey<Tasks>(b => b.UserID); 

                 modelBuilder.Entity<Tasks>()
                    .HasOne(b => b.Projects)
                    .WithOne(a => a.Tasks) 
                    .HasForeignKey<Tasks>(b => b.ProjectID);

                modelBuilder.Entity<ProjectDevelopers>()
                    .HasOne(b => b.Developers)
                    .WithOne(a => a.ProjectDevelopers)
                    .HasForeignKey<ProjectDevelopers>(b => b.DeveloperID);
            }
        }
    }
}