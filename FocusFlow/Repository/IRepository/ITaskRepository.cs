using FocusFlow.Models;

namespace FocusFlow.Repository.Interface
{
    public interface ITaskRepository
    {
        IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin);
        Task<UserTask> GetTaskById(int taskId);

        Task AddTask(UserTask task);
        Task UpdateTask(UserTask task);
        Task RemoveTask(UserTask task);
    }
}
