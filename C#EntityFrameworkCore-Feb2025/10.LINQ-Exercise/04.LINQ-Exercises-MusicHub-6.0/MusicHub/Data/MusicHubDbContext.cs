namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Configuration;
    using MusicHub.Data.Models;

    //class using add
    using static Configuration.ConectionConfiguration;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Performer> Performers { get; set; }

        public virtual DbSet<Producer> Producers { get; set; }

        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<SongPerformer> SongPerformers { get; set; }

        public virtual DbSet<Writer> Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
        }

        // TODO: Describe relations using Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //var 1
            //builder.ApplyConfiguration(new SongEntityConfiguration());
            //builder.ApplyConfiguration(new AlbumEntityConfiguration());

            //var 2 - зарежда всички от папката където се намира тоя клас
            builder
                .ApplyConfigurationsFromAssembly(typeof(SongEntityConfiguration).Assembly);
        }
    }
}
