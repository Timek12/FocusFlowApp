using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Services.Interface;

namespace FocusFlow.Services.Implementation
{
    public class PomodoroService : IPomodoroService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PomodoroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

                _unitOfWork.Pomodoro.Add(session);
                _unitOfWork.Save();

                return session;
            }

            return null;
        }

        public PomodoroSession? GetLatestSession(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var query = _unitOfWork.Pomodoro.GetQuery();

                query = query.Where(u => u.UserId == userId && u.isCompleted == false)
                    .OrderBy(u => u.SessionId);

                return query.FirstOrDefault();
            }

            return null;
        }

        public void UpdateSession(PomodoroSession session)
        {
            _unitOfWork.Pomodoro.Update(session);
            _unitOfWork.Save();
        }
    }
}
