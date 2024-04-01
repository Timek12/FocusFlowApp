using FocusFlow.Models;

namespace FocusFlow.Repository.IRepository
{
    public interface ITaskRepository
    {
        IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin);
        Task<UserTask> GetTaskById(int taskId);
        IQueryable<UserTask> GetUserTasksQuery();
        Task AddTask(UserTask task);
        Task UpdateTask(UserTask task);
        Task RemoveTask(UserTask task);
    }
}
