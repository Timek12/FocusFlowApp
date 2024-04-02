using FocusFlow.Models;
using FocusFlow.Services.Interface;
using FocusFlow.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IDashboardService dashboardService, UserManager<ApplicationUser> userManager)
        {
            _dashboardService = dashboardService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<string> GetUserId()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            return currentUser.Id;
        }

        private async Task<bool> IsAdmin()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            return await _userManager.IsInRoleAsync(currentUser, SD.Role_Admin);
        }

        public async Task<IActionResult> GetTasksStatusPieChartData()
        {
            var userId = await GetUserId();
            var isAdmin = await IsAdmin();

            return Json(await _dashboardService.GetTasksStatusPieChartData(userId, isAdmin));
        }

        public async Task<IActionResult> GetTasksImportancePieChartData()
        {
            var userId = await GetUserId();
            var isAdmin = await IsAdmin();

            return Json(await _dashboardService.GetTasksImportancePieChartData(userId, isAdmin));
        }

        public async Task<IActionResult> GetTasksLineChartData()
        {
            var userId = await GetUserId();
            var isAdmin = await IsAdmin();

            return Json(await _dashboardService.GetTasksLineChartData(userId, isAdmin));
        }

        public async Task<IActionResult> GetSessionsLineChartData()
        {
            var userId = await GetUserId();
            var isAdmin = await IsAdmin();

            return Json(await _dashboardService.GetSessionsLineChartData(userId, isAdmin));
        }
    }
}
