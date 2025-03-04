using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    //using static EntityValidationConstants.Producer;


    public class SongPerformerEntityConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> entity)
        {

            // Composite PK in EF Core is always represented as an Object
            entity
                .HasKey(sp => new {sp.SongId, sp.PerformerId });

            entity
                .Property(sp => sp.SongId)
                .IsRequired();

            entity
                .Property(sp => sp.PerformerId)
                .IsRequired();

            //relations
            //2 x one to many <=> Many to Many
            entity
               .HasOne(sp => sp.Song)
               .WithMany(s => s.SongPerformers)
               .HasForeignKey(sp => sp.SongId);

            entity
              .HasOne(sp => sp.Performer)
              .WithMany(p => p.PerformerSongs)
              .HasForeignKey(sp => sp.PerformerId);
        }
    }
}

