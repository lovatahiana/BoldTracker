using BoldTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoldTracker.Config
{
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.HasKey(l => l.LabelId);
            builder.Property(l => l.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(l => l.TodoTasks)
                   .WithOne(t => t.Label)
                   .HasForeignKey(t => t.LabelId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new Label { LabelId = 1, Name = "School", UserId = 1 },
                new Label { LabelId = 2, Name = "Personal", UserId = 1 }
            );
        }
    }
}
