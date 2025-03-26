namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options) 
        { 
        }

        public DbSet<Truck> Trucks { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Despatcher> Despatchers { get; set; } = null!;

        public DbSet<ClientTruck> ClientsTrucks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the composite primary key for ClientTruck
            modelBuilder
                .Entity<ClientTruck>()
                .HasKey(ct => new { ct.ClientId, ct.TruckId });

            // Configure relationships
            modelBuilder
                .Entity<Truck>()
                .HasOne(t => t.Despatcher)
                .WithMany(d => d.Trucks)
                .HasForeignKey(t => t.DespatcherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ClientTruck>()
                .HasOne(ct => ct.Client)
                .WithMany(c => c.ClientsTrucks)
                .HasForeignKey(ct => ct.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<ClientTruck>()
                .HasOne(ct => ct.Truck)
                .WithMany(t => t.ClientsTrucks)
                .HasForeignKey(ct => ct.TruckId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
