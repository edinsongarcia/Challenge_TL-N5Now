using ChallengeN5Now.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5Now.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasOne(ep => ep.Employee)
                .WithMany()
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<Permission>()
                .HasOne(ep => ep.PermissionType)
                .WithMany()
                .HasForeignKey(ep => ep.PermissionTypeId);

            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType
                {
                    Id = 1,
                    Name = "users.edit",
                    Description = "Puede editar la información de los usuarios",
                    CreatedDate = DateTime.Now
                },
                new PermissionType
                {
                    Id = 2,
                    Name = "users.create",
                    Description = "Puede crear usuarios",
                    CreatedDate = DateTime.Now
                },
                new PermissionType
                {
                    Id = 3,
                    Name = "services.edit",
                    Description = "Puede leer los servicios ofertados",
                    CreatedDate = DateTime.Now
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Edisson",
                    LastName = "Garcia",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    Name = "Maria",
                    LastName = "Fernandez",
                    CreatedDate = DateTime.Now
                },
                new Employee
                {
                    Id = 3,
                    Name = "Marcela",
                    LastName = "Velasco",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}