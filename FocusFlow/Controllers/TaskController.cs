using FocusFlow.Models;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static FocusFlow.Utility.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FocusFlow.Services.Interface;
using FocusFlow.DTOs;
using Newtonsoft.Json;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController(ITaskRepository taskRepository, UserManager<ApplicationUser> userManager)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, Role_Admin);

            IEnumerable<UserTask> tasks = _taskRepository.GetAllTasks(currentUser.Id, isAdmin);

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

                await _taskRepository.AddTask(userTask);

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
                return RedirectToAction("Error", "Home");
            }

            UserTaskUpdateVM userTaskUpdateVM = new()
            {
                UserTask = await _taskRepository.GetTaskById(id),
                
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
                return RedirectToAction("Error", "Home");
            }

            return View(userTaskUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserTaskUpdateVM userTaskUpdateVM)
        {
            if (userTaskUpdateVM is null || userTaskUpdateVM.UserTask is null)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                await _taskRepository.UpdateTask(userTaskUpdateVM.UserTask);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", "Home");
            }


            var userTaskFromDb = await _taskRepository.GetTaskById(id);
            if (userTaskFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            await _taskRepository.RemoveTask(userTaskFromDb);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            IEnumerable<UserTask> tasks = _taskRepository.GetAllTasks(currentUser.Id, false);
            IEnumerable<TaskDTO> tasksDTO = tasks.Select(u => new TaskDTO()
            {
                Name = u.Name,
                Description = u.Description,
                StartDate = u.CreatedAt.ToString("yyyy-MM-dd"),
                EndDate = u.Deadline.ToString("yyyy-MM-dd")
            });

            string json = JsonConvert.SerializeObject(tasksDTO);

            return Content(json, "application/json");
        }
    }
}
