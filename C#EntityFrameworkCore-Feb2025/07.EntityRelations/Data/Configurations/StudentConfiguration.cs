using _07.EntityRelations.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace _07.EntityRelations.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .ToTable("Students", "uni")
                .HasComment("University students");

            builder
                .HasKey(p => p.StudentPk);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasComment("Student's name");

            builder
                .Property(p => p.FacultyNumber)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}

