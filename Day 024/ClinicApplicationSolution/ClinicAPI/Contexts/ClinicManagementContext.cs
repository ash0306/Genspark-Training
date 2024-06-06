using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class ClinicManagementContext : DbContext
    {
        public ClinicManagementContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Neil", Experience = 13, Speciality = "Cardio", Age = 30, Phone = "1234556789"},
                new Doctor() { Id = 102, Name = "Andrew", Experience = 6, Speciality = "Ortho", Age = 28, Phone = "9988334455" }
                );
        }
    }
}
