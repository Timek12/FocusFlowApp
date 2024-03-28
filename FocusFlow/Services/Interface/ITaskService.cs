using FocusFlow.Models;

namespace FocusFlow.Services.Interface
{
    public interface ITaskService
    {
        IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin);
        Task<UserTask> GetTaskById(int taskId);

        Task AddTask(UserTask task);
        Task UpdateTask(UserTask task);
        Task RemoveTask(UserTask task);
    }
}
