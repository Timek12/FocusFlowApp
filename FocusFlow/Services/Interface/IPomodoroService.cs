using FocusFlow.Models;

namespace FocusFlow.Services.Interface
{
    public interface IPomodoroService
    {
        public PomodoroSession? CreateSession(string userId);
        public PomodoroSession? GetLatestSession(string userId);
        public void UpdateSession(PomodoroSession session);
    }
}
