using BoldTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoldTracker.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
            builder.Property(u => u.PasswordHash).IsRequired();

            builder.HasMany(u => u.Labels)
                   .WithOne(l => l.User)
                   .HasForeignKey(l => l.UserId);

            builder.HasMany(u => u.TodoTasks)
                   .WithOne(t => t.User)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasData(new User
            {
                UserId = 1,
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "hashed123"
            });
        }
    }
}
