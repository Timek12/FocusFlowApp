
using FocusFlow.Models;

namespace FocusFlow.Services.Interface
{
    public interface IPomodoroService
    {
        PomodoroSession? CreateSession(string userId, TimeSpan duration);
        PomodoroSession? GetLatestSession(string userId);
        void UpdateSession(PomodoroSession session);
    }
}
