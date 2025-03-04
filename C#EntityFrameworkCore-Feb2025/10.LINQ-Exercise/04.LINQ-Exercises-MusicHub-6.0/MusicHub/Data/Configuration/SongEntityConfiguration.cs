using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configuration
{
    using static EntityValidationConstants.Song;

    
    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            //Define the primary key in Fluent API <=> [Key]
            builder.HasKey(s => s.Id);

            // Define constraints about property in Fluent API <=> [Required] [MaxLength()]
            builder
                .Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(SongNameMaxLength);

            // Optional just for description
            builder
                .Property(s => s.Duration)
                .IsRequired();

            builder
                .Property(s => s.CreatedOn)
                .IsRequired();

            builder
                .Property(s => s.Genre)
                .IsRequired();

            builder
                .Property(s => s.AlbumId)
                .IsRequired(false);

            builder
                .Property(s => s.Price)
                .IsRequired();

            builder
                .Property(s => s.WriterId)
                .IsRequired();

            //Relations are descrybed only from one side
            //usually "one" side to many
            //One to many relation -> HasOne(1..) -> WithMany(2..) -> HasForeignKey(1..Id)
            builder
               .HasOne(s => s.Album)
               .WithMany(a => a.Songs)
               .HasForeignKey(s => s.AlbumId);

            builder
               .HasOne(s => s.Writer)
               .WithMany(w => w.Songs)
               .HasForeignKey(s => s.WriterId);
        }
    }
}

