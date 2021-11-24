using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCA_Code_Assessment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassAssignment> ClassAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(o => o.StudentId);
            modelBuilder.Entity<Teacher>().HasKey(o => o.TeacherId);
            modelBuilder.Entity<Class>().HasKey(o => o.ClassId);
            modelBuilder.Entity<ClassAssignment>().HasKey(o => new { o.StudentId, o.ClassId });
        }
    }
}
