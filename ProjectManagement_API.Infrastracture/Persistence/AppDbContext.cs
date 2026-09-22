using Microsoft.EntityFrameworkCore;
using ProjectManagement_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Infrastracture.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectTasks> ProjectTasks { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Status> Status {  get; set; }
        public DbSet<TaskComments> TaskComments { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasOne(x => x.Manager).//project has one manager
                WithMany()//manager of many Projects.
                .HasForeignKey(x => x.ManagerId);
            });

            modelBuilder.Entity<ProjectTasks>(entity => 
            {
                entity.HasOne(x => x.Employee).
                WithMany()
                .HasForeignKey(x => x.AssignedTo);
            });

            modelBuilder.Entity<TaskComments>(entity =>
            {
                entity.HasOne(x => x.ProjectTasks).//one comment belongs to one task
                WithMany()// one task can have multiple comments
                .HasForeignKey(x => x.ProjectTaskId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
