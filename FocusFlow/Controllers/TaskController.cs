using FocusFlow.Models;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static FocusFlow.Utility.SD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FocusFlow.DTOs;
using Newtonsoft.Json;
using FocusFlow.Services.Interface;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController(ITaskService taskService, UserManager<ApplicationUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, Role_Admin);

            IEnumerable<UserTask> tasks = _taskService.GetAllTasks(currentUser.Id, isAdmin);

            return View(tasks);
        }

        public IActionResult Create()
        {
            UserTaskCreateVM userTaskVM = _taskService.CreateUserTaskCreateVM();
            return View(userTaskVM);
        }

        [HttpPost]
        public IActionResult Create(UserTaskCreateVM userTaskVM)
        {
            if (ModelState.IsValid)
            {
                _taskService.CreateTask(userTaskVM, _userManager.GetUserId(User));
                return RedirectToAction(nameof(Index));
            }

            _taskService.UpdateUserTaskVM(userTaskVM);
            return View(userTaskVM);
        }

        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", "Home");
            }

            UserTaskUpdateVM userTaskUpdateVM = _taskService.CreateUserTaskUpdateVM(_userManager.GetUserId(User), id);

            if (userTaskUpdateVM.UserTask is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(userTaskUpdateVM);
        }

        [HttpPost]
        public IActionResult Update(UserTaskUpdateVM userTaskUpdateVM)
        {
            if (userTaskUpdateVM is null || userTaskUpdateVM.UserTask is null)
            {
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(userTaskUpdateVM.UserTask);
                return RedirectToAction(nameof(Index));
            }

            _taskService.UpdateUserTaskVM(userTaskUpdateVM);

            return View(userTaskUpdateVM);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return RedirectToAction("Error", "Home");
            }

            var userTaskFromDb = _taskService.GetTaskById(id);
            if (userTaskFromDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            _taskService.RemoveTask(userTaskFromDb);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetAllTasks()
        {
            IEnumerable<TaskDTO> tasksDTO = _taskService.GetAllTasksDTO(_userManager.GetUserId(User));

            string json = JsonConvert.SerializeObject(tasksDTO);
            return Content(json, "application/json");
        }
    }
}
