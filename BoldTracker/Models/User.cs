namespace BoldTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
        public ICollection<Label> Labels { get; set; } = new List<Label>();
    }
}
