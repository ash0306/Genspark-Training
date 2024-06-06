using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RequestTrackerDALLibrary.Model
{
    public partial class dbRequestTrackerContext : DbContext
    {
        public dbRequestTrackerContext()
        {
        }

        public dbRequestTrackerContext(DbContextOptions<dbRequestTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JHII9TQ\\DEMOINSTANCE;Integrated Security=True;Initial Catalog=dbRequestTracker;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentHead).HasColumnName("Department_Head");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeDepartmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDepartment)
                    .HasConstraintName("FK__Employees__Emplo__403A8C7D");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClosedBy).HasColumnName("Closed_By");

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.RaisedBy).HasColumnName("Raised_By");

                entity.Property(e => e.RaisedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
