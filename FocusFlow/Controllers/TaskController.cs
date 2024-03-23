using FocusFlow.Data;
using FocusFlow.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
