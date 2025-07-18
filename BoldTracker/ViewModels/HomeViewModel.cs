using BoldTracker.Models;

namespace BoldTracker.ViewModels
{
    public class HomeViewModel
    {
        public List<TodoTask> TodoTasks { get; set; } = new();
        public List<Label> Labels { get; set; } = new();
        public TodoTask? NewTask { get; set; }

    }
}
