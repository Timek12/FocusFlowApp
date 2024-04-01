﻿using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FocusFlow.Repository
{
    public class PomodoroRepository : Repository<PomodoroSession>, IPomodoroRepository
    {
        private readonly ApplicationDbContext _db;
        public PomodoroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PomodoroSession session)
        {
            _db.PomodoroSessions.Update(session);
        }
    }
}
