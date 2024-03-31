using FocusFlow.Data;
using FocusFlow.DTOs;
using FocusFlow.Models;
using FocusFlow.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
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

            var tasks = _db.Tasks.AsQueryable();

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

            var tasks = _db.Tasks.AsQueryable();

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
    }
}
