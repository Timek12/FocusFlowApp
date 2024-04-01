using FocusFlow.Models;

namespace FocusFlow.Repository.Interface
{
    public interface IPomodoroRepository
    {
        public PomodoroSession? CreateSession(string userId);
        public PomodoroSession? GetLatestSession(string userId);
        public void UpdateSession(PomodoroSession session);
    }
}
