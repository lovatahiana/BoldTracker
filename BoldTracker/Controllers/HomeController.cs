using System.Diagnostics;
using System.Threading.Tasks;
using BoldTracker.Data;
using BoldTracker.Models;
using BoldTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoldTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoldTrackerContext _context;

        public HomeController(BoldTrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.TodoTasks
                .Include(t => t.Label)
                .ToListAsync();

            var labels = await _context.Labels.ToListAsync();

            var viewModel = new HomeViewModel
            {
                TodoTasks = tasks,
                Labels = labels
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTodoTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (Request.Headers["Accept"].ToString().Contains("application/json"))
                    return BadRequest(ModelState);

                // fallback in case JS is disabled
                return RedirectToAction("Index");
            }

            var newTask = new TodoTask
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Priority = model.Priority,
                Status = TodoTaskStatus.TODO,
                LabelId = model.LabelId,
                IsProcrastinated = false,
                HumorText = "",

                // hardcoded user for now (change later)
                UserId = 1
            };

            _context.TodoTasks.Add(newTask);
            await _context.SaveChangesAsync();

            if (Request.Headers["Accept"].ToString().Contains("application/json"))
                return Ok(new { message = "Created" });

            return RedirectToAction("Index");
        }






        [HttpGet]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task == null) return NotFound();

            return Json(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] CreateTodoTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _context.TodoTasks.FindAsync(model.TodoTaskId);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.LabelId = model.LabelId;
            task.Priority = model.Priority;
            task.DueDate = model.DueDate;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Task updated successfully" });
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.TodoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            _context.TodoTasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Task deleted successfully" });
        }







    }
}
