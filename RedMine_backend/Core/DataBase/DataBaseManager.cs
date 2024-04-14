using Microsoft.EntityFrameworkCore;
using RedMine_backend.Core.Entities;
using System.Linq;

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
                     .HasOne(t => t.Managers)
                     .WithMany(m => m.Tasks)
                     .HasForeignKey(t => t.UserID)
                     .IsRequired(false);


                modelBuilder.Entity<Tasks>()
                    .HasOne(t => t.Projects)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(t => t.ProjectID)
                    .IsRequired(false);

                
                modelBuilder.Entity<ProjectDevelopers>()
                    .HasOne(t => t.Projects)
                    .WithOne(p => p.ProjectDevelopers)
                    .HasForeignKey<ProjectDevelopers>(pd => pd.ProjectID)
                    .IsRequired(false);
                

                modelBuilder.Entity<Projects>()
                    .HasOne(t => t.ProjectTypes)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(pd => pd.TypeID)
                    .IsRequired(false);
            }
            
        }
    }
}