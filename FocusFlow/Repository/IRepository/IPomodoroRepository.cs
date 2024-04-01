using FocusFlow.Models;
using System.Linq.Expressions;

namespace FocusFlow.Repository.IRepository
{
    public interface IPomodoroRepository
    {
        IEnumerable<PomodoroSession> GetAll(Expression<Func<PomodoroSession, bool>>? filter = null, bool tracked = false);
        PomodoroSession? CreateSession(string userId);
        PomodoroSession? GetLatestSession(string userId);
        void UpdateSession(PomodoroSession session);
    }
}
