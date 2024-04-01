using FocusFlow.Models;
using System.Linq.Expressions;

namespace FocusFlow.Repository.IRepository
{
    public interface IPomodoroRepository : IRepository<PomodoroSession>
    {
        void Update(PomodoroSession session);
    }
}
