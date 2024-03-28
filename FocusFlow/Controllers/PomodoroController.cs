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
        private readonly IPomodoroRepository _pomodoroRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public PomodoroSession PomodoroSession { get; private set; }
        public PomodoroController(IPomodoroRepository pomodoroRepository, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _pomodoroRepository = pomodoroRepository;
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroRepository.GetLatestSession(userId);
            if (PomodoroSession is null || PomodoroSession.isCompleted)
            {
                PomodoroSession = _pomodoroRepository.CreateSession(userId);
            }

            return View(PomodoroSession);
        }

        [HttpPost]
        public IActionResult StartTimer([FromBody] string startTime)
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroRepository.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.StartTime = DateTime.Parse(startTime);
            _pomodoroRepository.UpdateSession(PomodoroSession);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult StopTimer([FromBody] string stopTime)
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroRepository.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.EndTime = DateTime.Parse(stopTime);
            _pomodoroRepository.UpdateSession(PomodoroSession);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult FinalizeSession()
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroRepository.GetLatestSession(userId);
            if (PomodoroSession is null)
            {
                return Json(new { success = false });
            }

            PomodoroSession.isCompleted = true;
            _pomodoroRepository.UpdateSession(PomodoroSession);

            return RedirectToAction(nameof(Index));
        }
    }
}
