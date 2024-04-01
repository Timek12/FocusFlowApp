using FocusFlow.Models;

namespace FocusFlow.Repository.IRepository
{
    public interface ITaskRepository : IRepository<UserTask>
    {
        Task Update(UserTask task);
    }
}
