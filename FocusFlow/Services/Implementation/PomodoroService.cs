﻿using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FocusFlow.Services.Implementation
{
    public class PomodoroService : IPomodoroService
    {
        private readonly ApplicationDbContext _db;
        public PomodoroService(ApplicationDbContext db)
        {
            _db = db;
        }

        public PomodoroSession? CreateSession(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                PomodoroSession session = new()
                {
                    UserId = userId,
                    Duration = new TimeSpan(0, 25, 0),
                    isCompleted = false,
                    isRunning = false,
                    isBreak = false,
                };

                _db.PomodoroSessions.Add(session);
                _db.SaveChanges();

                return session;
            }

            return null;
        }

        public PomodoroSession? GetLatestSession(string userId)
        {
            return _db.PomodoroSessions.Where(u => u.UserId == userId)
                    .OrderByDescending(u => u.StartTime).FirstOrDefault();
        }

    }
}