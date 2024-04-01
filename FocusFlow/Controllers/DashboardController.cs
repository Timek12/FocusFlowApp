using FocusFlow.Data;
using FocusFlow.DTOs;
using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Globalization;
using System.Threading.Tasks;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPomodoroRepository _pomodoroRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ITaskRepository taskRepository, IPomodoroRepository pomodoroRepository, UserManager<ApplicationUser> userManager)
        {
            _taskRepository = taskRepository;
            _pomodoroRepository = pomodoroRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PieChartDTO> GetTasksStatusPieChartData()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, SD.Role_Admin);

            var tasks = _taskRepository.GetUserTasksQuery();

            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == user.Id);
            }


            var completedTasks = tasks.Count(u => u.Status == SD.TaskStatus.Completed);
            var incompletedTasks = tasks.Count(u => u.Status == SD.TaskStatus.InProgress);

            PieChartDTO pieChartDTO = new()
            {
                Labels = new string[] { "Completed", "In progress" },
                Series = new int[] { completedTasks, incompletedTasks }
            };

            return pieChartDTO;
        }

        public async Task<PieChartDTO> GetTasksImportancePieChartData()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, SD.Role_Admin);

            var tasks = _taskRepository.GetUserTasksQuery();

            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == user.Id);
            }

            var lowImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.Low);
            var mediumImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.Medium);
            var highImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.High);

            PieChartDTO pieChartDTO = new()
            {
                Labels = new string[] { "Low", "Medium", "High" },
                Series = new int[] { lowImportanceTasksCount, mediumImportanceTasksCount, highImportanceTasksCount }
            };

            return pieChartDTO;
        }

        private IQueryable<UserTask> FilterTasksByUserAndDate(IQueryable<UserTask> tasks, string userId, bool isAdmin)
        {
            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == userId);
            }

            return tasks.Where(u => u.CreatedAt >= DateTime.Now.AddDays(-30) && u.CreatedAt <= DateTime.Now);
        }

        private Dictionary<string, int> GetTaskDataDict(IQueryable<UserTask> tasks)
        {
            return tasks.GroupBy(u => u.CreatedAt.Date)
                .Select(u => new
                {
                    DateTime = u.Key,
                    TaskCount = u.Count()
                })
                .ToDictionary(u => u.DateTime.ToString("dd/MM"), u => u.TaskCount);
        }

        public async Task<LineChartDTO> GetTasksLineChartData()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, SD.Role_Admin);

            var tasks = _taskRepository.GetUserTasksQuery();
            tasks = FilterTasksByUserAndDate(tasks, user.Id, isAdmin);

            var lowImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.Low));
            var mediumImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.Medium));
            var highImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.High));

            var allDates = lowImportanceTaskDataDict.Keys
                .Concat(mediumImportanceTaskDataDict.Keys)
                .Concat(highImportanceTaskDataDict.Keys)
                .Distinct()
                .OrderBy(date => date)
                .ToArray();

            var lowImportanceTaskCountSeries = allDates.Select(date => lowImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();
            var mediumImportanceTaskCountSeries = allDates.Select(date => mediumImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();
            var highImportanceTaskCountSeries = allDates.Select(date => highImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();

            LineChartDTO lineChartDTO = new()
            {
                Series =
                [
                    new() { Name = "Low Importance", Data = lowImportanceTaskCountSeries },
                    new() { Name = "Medium Importance", Data = mediumImportanceTaskCountSeries },
                    new() { Name = "High Importance", Data = highImportanceTaskCountSeries }
                ],
                Categories = allDates
            };

            return lineChartDTO;
        }

        public async Task<LineChartDTO> GetSessionsLineChartData()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isAdmin = await _userManager.IsInRoleAsync(user, SD.Role_Admin);

            var sessionsChartData = _pomodoroRepository.GetAll(u => u.isCompleted &&
                u.StartTime >= DateTime.Now.AddDays(-30) && u.StartTime <= DateTime.Now)
                .GroupBy(u => u.StartTime.Date)
                .Select(u => new
                {
                    DateTime = u.Key,
                    Count = u.Count()
                });

            var sessionChartDataSeries = sessionsChartData.Select(u => u.Count).ToArray();
            var sessionChartDataDates = sessionsChartData.Select(u => u.DateTime.ToString("dd/MM")).ToArray();

            LineChartDTO lineChartDTO = new()
            {
                Series = [new() { Name = "Sessions", Data = sessionChartDataSeries }],
                Categories = sessionChartDataDates
            };

            return lineChartDTO;
        }
    }
}
