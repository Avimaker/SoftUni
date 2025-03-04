using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{

    using static EntityValidationConstants.Album;


    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            //Define the primary key in Fluent API <=> [Key]
            entity.HasKey(a => a.Id);

            // Define constraints about property in Fluent API <=> [Required] [MaxLength()]
            entity
                .Property(a => a.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(AlbumNameMaxLength);

            entity
                .Property(a => a.ReleaseDate)
                .IsRequired();

            entity
                .Property(a => a.ProducerId)
                .IsRequired(false);

            //relations
            entity
               .HasOne(a => a.Producer)
               .WithMany(p => p.Albums)
               .HasForeignKey(a => a.ProducerId);

        }
    }
}

