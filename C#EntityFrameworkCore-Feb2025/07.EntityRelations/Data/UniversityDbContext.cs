using System;
using _07.EntityRelations.Data.Configurations;
using _07.EntityRelations.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _07.EntityRelations.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
        {
        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
        optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students { get; set; }
    }

}

