using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.Services.Interface;

namespace FocusFlow.Repository
{
    public class PomodoroRepository : IPomodoroRepository
    {
        private readonly ApplicationDbContext _db;
        public PomodoroRepository(ApplicationDbContext db)
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
                    Duration = new TimeSpan(0, 1, 0),
                    isCompleted = false,
                };

                _db.PomodoroSessions.Add(session);
                _db.SaveChanges();

                return session;
            }

            return null;
        }

        public void UpdateSession(PomodoroSession session)
        {
            if (!string.IsNullOrEmpty(session.UserId))
            {
                _db.PomodoroSessions.Update(session);
                _db.SaveChanges();
            }
        }

        public PomodoroSession? GetLatestSession(string userId)
        {
            return _db.PomodoroSessions.Where(u => u.UserId == userId && u.isCompleted == false)
                    .OrderBy(u => u.SessionId).FirstOrDefault();
        }
    }
}
