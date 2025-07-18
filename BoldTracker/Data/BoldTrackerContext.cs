using BoldTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BoldTracker.Data
{
    public class BoldTrackerContext : DbContext
    {
        public BoldTrackerContext(DbContextOptions<BoldTrackerContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Label> Labels => Set<Label>();
        public DbSet<TodoTask> TodoTasks => Set<TodoTask>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
