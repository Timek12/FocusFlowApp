using FocusFlow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static FocusFlow.Utility.SD;

namespace FocusFlow.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTask>().HasData(
                new UserTask { TaskId = 1, Name = "Design Homepage", Description = "Create a responsive design for the homepage", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.Medium, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(7), UserId = "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                new UserTask { TaskId = 2, Name = "Database Migration", Description = "Migrate the existing database to the new server", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.High, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(3), UserId = "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                new UserTask { TaskId = 3, Name = "Bug Fixing", Description = "Fix the reported bugs in the user management module", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.Low, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(12), UserId = "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                new UserTask { TaskId = 4, Name = "API Integration", Description = "Integrate the payment gateway API", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.Low, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(10), UserId = "2691dfbb-9544-4aed-8893-b3b19f6d2af1" },
                new UserTask { TaskId = 5, Name = "Performance Testing", Description = "Conduct performance testing on the new release", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.Medium, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(1), UserId = "2691dfbb-9544-4aed-8893-b3b19f6d2af1" },
                new UserTask { TaskId = 6, Name = "Code Review", Description = "Review the code of the new features", Status = Utility.SD.TaskStatus.InProgress, Importance = TaskImportance.High, CreatedAt = DateTime.Now, Deadline = DateTime.Now.AddDays(14), UserId = "2691dfbb-9544-4aed-8893-b3b19f6d2af1" }
            );
        }
    }
}
