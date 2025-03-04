using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Configuration;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    using static EntityValidationConstants.Perfomer;

    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            //Define the primary key in Fluent API <=> [Key]
            entity.HasKey(p => p.Id);

            entity
                .Property(p => p.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(PerformerFirstNameMaxLength);

            entity
                .Property(p => p.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(PerformerLastNameMaxLength);

            entity
                .Property(p => p.Age)
                .IsRequired();

            entity
                .Property(p => p.NetWorth)
                .IsRequired();

        }
    }
}

