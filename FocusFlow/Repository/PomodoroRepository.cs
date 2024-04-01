using FocusFlow.Data;
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

        public PomodoroSession? CreateSession(string userId, TimeSpan duration)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                PomodoroSession session = new()
                {
                    UserId = userId,
                    Duration = duration,
                    isCompleted = false,
                };

                _db.PomodoroSessions.Add(session);

                return session;
            }

            return null;
        }

        public void Update(PomodoroSession session)
        {
            if (!string.IsNullOrEmpty(session.UserId))
            {
                _db.PomodoroSessions.Update(session);
            }
        }

        public PomodoroSession? GetLatestSession(string userId)
        {
            return _db.PomodoroSessions.Where(u => u.UserId == userId && u.isCompleted == false)
                    .OrderBy(u => u.SessionId).FirstOrDefault();
        }
    }
}
