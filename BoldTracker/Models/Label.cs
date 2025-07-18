namespace BoldTracker.Models
{
    public class Label
    {
        public int LabelId { get; set; }
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
    }
}
