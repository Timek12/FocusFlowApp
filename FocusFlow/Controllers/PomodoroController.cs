﻿using FocusFlow.Data;
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
            _userManager = userManager;
            _pomodoroService = pomodoroService;
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if (PomodoroSession is null || PomodoroSession.isCompleted)
            {
                PomodoroSession = _pomodoroService.CreateSession(userId);
            }

            return View(PomodoroSession);
        }

        [HttpPost]
        public IActionResult StartTimer([FromBody] string startTime)
        {
            string userId = _userManager.GetUserId(User);
            PomodoroSession = _pomodoroService.GetLatestSession(userId);
            if(PomodoroSession is null)
            {
                return Json(new { success = false});
            }

            if (!PomodoroSession.isRunning) 
            {
                // concurrency conflict
                PomodoroSession.StartTime = DateTime.Parse(startTime);
                PomodoroSession.isRunning = true;
                _pomodoroService.UpdateSession(PomodoroSession);
            }

            return Json(new { success = true });
        }

    }
}
