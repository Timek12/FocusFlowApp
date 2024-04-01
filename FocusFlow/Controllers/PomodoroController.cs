using FocusFlow.Models;
using FocusFlow.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FocusFlow.Controllers
{
    [Authorize]
    public class PomodoroController : Controller
    {
        private readonly IPomodoroService _pomodoroService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PomodoroSession PomodoroSession { get; private set; }
        public PomodoroController(IPomodoroService pomodoroService, UserManager<ApplicationUser> userManager)
        {
            _pomodoroService = pomodoroService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if (PomodoroSession is null || PomodoroSession.isCompleted)
            {
                PomodoroSession = _pomodoroService.CreateSession(userId, new TimeSpan(0, 1, 0));
            }

            return View(PomodoroSession);
        }

        [HttpPost]
        public IActionResult StartTimer([FromBody] string startTime)
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.StartTime = DateTime.Parse(startTime);
            _pomodoroService.UpdateSession(PomodoroSession);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult StopTimer([FromBody] string stopTime)
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.EndTime = DateTime.Parse(stopTime);
            _pomodoroService.UpdateSession(PomodoroSession);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult FinalizeSession()
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.isCompleted = true;
            _pomodoroService.UpdateSession(PomodoroSession);

            return Json(new { success = true });
        }
    }
}
