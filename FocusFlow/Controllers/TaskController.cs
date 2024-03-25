using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using static FocusFlow.Utility.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public TaskController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<UserTask> tasks = _db.Tasks;
            return View(tasks);
        }

        public IActionResult Create()
        {
            UserTaskCreateVM userTaskVM = new()
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

        [HttpPost]
        public async Task<IActionResult> Create(UserTaskCreateVM userTaskVM)
        {
            if (ModelState.IsValid)
            {
                UserTask userTask = new()
                {
                    Name = userTaskVM.Name,
                    Description = userTaskVM.Description,
                    Status = userTaskVM.Status,
                    Importance = userTaskVM.Importance,
                    CreatedAt = DateTime.Now,
                    Deadline = userTaskVM.Deadline,
                    UserId = _userManager.GetUserId(User)
                };

                _db.Tasks.Add(userTask);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            userTaskVM.StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });

            userTaskVM.ImportanceList = Enum.GetValues(typeof(TaskImportance))
            .Cast<TaskImportance>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            });

            return View(userTaskVM);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id < 1)
            {
                RedirectToAction("Error", "Home");
            }

            UserTaskUpdateVM userTaskUpdateVM = new()
            {
                UserTask = await _db.Tasks.FirstOrDefaultAsync(u => u.TaskId == id),
                
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
                })
            };

            userTaskUpdateVM.UserTask.TaskId = id;

            if (userTaskUpdateVM.UserTask is null)
            {
                RedirectToAction("Error", "Home");
            }

            return View(userTaskUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserTaskUpdateVM userTaskUpdateVM)
        {
            if (userTaskUpdateVM is null || userTaskUpdateVM.UserTask is null)
            {
                RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _db.Tasks.Update(userTaskUpdateVM.UserTask);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            userTaskUpdateVM.StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });

            userTaskUpdateVM.ImportanceList = Enum.GetValues(typeof(TaskImportance))
            .Cast<TaskImportance>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            });

            return View(userTaskUpdateVM);
        }
    }
}
