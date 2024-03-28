using FocusFlow.Models;

namespace FocusFlow.Services.Interface
{
    public interface ITaskService
    {
        IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin);
        UserTask GetTaskById(int taskId);

        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void RemoveTask(UserTask task);
    }
}
