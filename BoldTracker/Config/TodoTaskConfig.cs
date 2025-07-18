using BoldTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoldTracker.Config
{
    public class TodoTaskConfig : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasKey(t => t.TodoTaskId);

            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).IsRequired(false);
            builder.Property(t => t.HumorText).HasMaxLength(300);
            builder.Property(t => t.DueDate).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.Priority).IsRequired();
            builder.Property(t => t.IsProcrastinated).IsRequired();

            builder.HasOne(t => t.User)
                   .WithMany(u => u.TodoTasks)
                   .HasForeignKey(t => t.UserId);

            builder.HasOne(t => t.Label)
                   .WithMany(l => l.TodoTasks)
                   .HasForeignKey(t => t.LabelId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new TodoTask
                {
                    TodoTaskId = 1,
                    Title = "Finish math homework",
                    Description = "Page 42 to 45, calculus",
                    DueDate = new DateTime(2025, 7, 20), 
                    Priority = Priority.HIGH,
                    Status = TodoTaskStatus.TODO,   
                    IsProcrastinated = false,
                    LabelId = 1,
                    UserId = 1
                },
                new TodoTask
                {
                    TodoTaskId = 2,
                    Title = "Buy groceries",
                    Description = "Eggs, milk, bread",
                    DueDate = new DateTime(2025, 7, 19),
                    Priority = Priority.MEDIUM,
                    Status = TodoTaskStatus.PROCRASTINATED,  
                    IsProcrastinated = true,
                    HumorText = "Procrastinated again 😅",
                    LabelId = 2,
                    UserId = 1
                }
            );
        }
    }
}
