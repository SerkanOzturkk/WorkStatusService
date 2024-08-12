using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Task = Entities.Concrete.Task;


namespace DataAccess.Concrete.EntityFramework
{
    public class WorkStatusContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<EmployeeClaim> EmployeeClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WorkStatusDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.Entity<TimeLog>().ToTable("TimeLogs");
            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Claim>().ToTable("Claims");
            modelBuilder.Entity<EmployeeClaim>().ToTable("EmployeeClaims");

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Projects)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete yerine Restrict kullan

            modelBuilder.Entity<Task>()
                .HasOne(t => t.AssignedEmployee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete yerine Restrict kullan

            modelBuilder.Entity<TimeLog>()
                .HasOne(tl => tl.Employee)
                .WithMany(e => e.TimeLogs)
                .HasForeignKey(tl => tl.EmployeeId);

            modelBuilder.Entity<TimeLog>()
                .HasOne(tl => tl.Task)
                .WithMany(t => t.TimeLogs)
                .HasForeignKey(tl => tl.TaskId);

            modelBuilder.Entity<EmployeeClaim>()
                .HasOne(ec => ec.Employee)
                .WithMany(e => e.EmployeeClaims)
                .HasForeignKey(ec => ec.EmployeeId);

            modelBuilder.Entity<EmployeeClaim>()
                .HasOne(ec => ec.Claim)
                .WithMany(c => c.EmployeeClaims)
                .HasForeignKey(ec => ec.ClaimId);
        }

    }
}
