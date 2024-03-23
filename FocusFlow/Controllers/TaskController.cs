using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static FocusFlow.Utility.SD;

namespace FocusFlow.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TaskController(ApplicationDbContext db)
        {
            _db = db;            
        }

        public IActionResult Index()
        {
            IEnumerable<UserTask> tasks = _db.Tasks;
            return View(tasks);
        }

        public IActionResult Create()
        {
            UserTaskVM userTaskVM = new()
            {
                StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                 {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                 }),
                ImportanceList = Enum.GetValues(typeof(TaskImportance))
                .Cast<TaskImportance>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }),
            };

            return View(userTaskVM);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if(id < 1)
            {
                RedirectToAction("Error", "Home");
            }

            UserTask? taskFromDb = await _db.Tasks.FirstOrDefaultAsync(u => u.TaskId == id);
            if (taskFromDb == null)
            {
                RedirectToAction("Error", "Home");
            }

            return View(taskFromDb);
        }
    }
}
