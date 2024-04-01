using FocusFlow.Models;

namespace FocusFlow.Repository.IRepository
{
    public interface ITaskRepository : IRepository<UserTask>
    {
        void Update(UserTask task);
    }
}
