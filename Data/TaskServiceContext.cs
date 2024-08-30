using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;
using Task = TaskManagementSystem.Models.Task;

namespace TaskManagementSystem.Data
{
    public class TaskServiceContext : IdentityDbContext
    {
        public TaskServiceContext(DbContextOptions<TaskServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tbl_Tasks { get; set; }
    }
}
