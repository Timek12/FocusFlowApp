using FocusFlow.Models;
using System.Linq.Expressions;

namespace FocusFlow.Repository.IRepository
{
    public interface IPomodoroRepository : IRepository<PomodoroSession>
    {
        PomodoroSession? CreateSession(string userId, TimeSpan duration);
        PomodoroSession? GetLatestSession(string userId);
        void Update(PomodoroSession session);
    }
}
