using BoldTracker.Models;

namespace BoldTracker.ViewModels
{
    public class CreateTodoTaskViewModel
    {
        public int TodoTaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public int? LabelId { get; set; }

        public List<Label> Labels { get; set; } = new();
    }
}
