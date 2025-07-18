namespace BoldTracker.Models
{
    public class TodoTask
    {
        public int TodoTaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public TodoTaskStatus Status { get; set; }
        public bool IsProcrastinated { get; set; }
        public string? HumorText { get; set; }

        public int? LabelId { get; set; }
        public Label? Label { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
