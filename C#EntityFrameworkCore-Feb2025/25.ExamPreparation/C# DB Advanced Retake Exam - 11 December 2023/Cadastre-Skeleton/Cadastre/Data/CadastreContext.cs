namespace Cadastre.Data
{
    using Cadastre.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class CadastreContext : DbContext
    {
        public CadastreContext()
        {
            
        }

        public CadastreContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<PropertyCitizen> PropertiesCitizens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primary key for PropertyCitizen
            modelBuilder.Entity<PropertyCitizen>()
                .HasKey(pc => new { pc.PropertyId, pc.CitizenId });

            //relationships
            modelBuilder.Entity<Property>()
                .HasOne(p => p.District)
                .WithMany(d => d.Properties)
                .HasForeignKey(p => p.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PropertyCitizen>()
                .HasOne(pc => pc.Property)
                .WithMany(p => p.PropertiesCitizens)
                .HasForeignKey(pc => pc.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyCitizen>()
                .HasOne(pc => pc.Citizen)
                .WithMany(c => c.PropertiesCitizens)
                .HasForeignKey(pc => pc.CitizenId)
                .OnDelete(DeleteBehavior.Cascade);

            // Additional configurations
            modelBuilder.Entity<District>()
                .HasIndex(d => d.PostalCode)
                .IsUnique();

            modelBuilder.Entity<Property>()
                .HasIndex(p => p.PropertyIdentifier)
                .IsUnique();

        }
    }
}
