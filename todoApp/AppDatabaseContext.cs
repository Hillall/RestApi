using Microsoft.EntityFrameworkCore;
using todoApp.Models;

namespace todoApp
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>()
               .Property(a => a.Timestamp).IsRowVersion();
        }
    }
}
