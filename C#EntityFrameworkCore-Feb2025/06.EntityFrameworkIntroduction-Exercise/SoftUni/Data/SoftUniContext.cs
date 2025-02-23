namespace SoftUni.Data
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Models;
  
    public partial class SoftUniContext : DbContext
    {

        // We use this construtor
        public SoftUniContext()
        {

        }

        // for Judge
        public SoftUniContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<EmployeeProject> EmployeesProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=SoftUni; User Id=SA; Password=SoftUni2025; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");


                entity
                    .HasMany(d => d.EmployeesProjects)
                    .WithOne(ep => ep.Employee)
                    .HasForeignKey(ep => ep.EmployeeId);

            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
                entity.Property(e => e.Description).HasColumnType("ntext");
                entity.Property(e => e.EndDate). HasColumnType("smalldatetime");
                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

                entity
                    .HasMany(p => p.EmployeesProjects)
                    .WithOne(ep => ep.Project)
                    .HasForeignKey(ep => ep.ProjectId);
            });

            modelBuilder.Entity<Town>( entity =>
            {
                entity.Property(e => e.TownId).HasColumnName("TownID");

                entity.Property(e => e.Name)
                        .HasMaxLength(50)
                        .IsUnicode(false);
            }
            );


            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity
                    .HasKey(ep => new
                    { ep.EmployeeId, ep.ProjectId });
                entity
                    .Property(ep => ep.EmployeeId)
                    .HasColumnName("EmployeeID");
                entity
                    .Property(ep => ep.ProjectId)
                    .HasColumnName("ProjectID");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
