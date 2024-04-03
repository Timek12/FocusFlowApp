using FocusFlow.Models;
using FocusFlow.ViewModels;
using FocusFlow.ViewModels.Interface;

namespace FocusFlow.Services.Interface
{
    public interface ITaskService
    {
        IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin);
        UserTask? GetTaskById(int taskId);
        IQueryable<UserTask> GetUserTasksQuery();
        void CreateTask(UserTaskCreateVM userTaskVM, string userId);
        UserTaskCreateVM CreateUserTaskCreateVM();
        UserTaskUpdateVM CreateUserTaskUpdateVM(string userId, int taskId);
        void UpdateUserTaskVM(IUserTaskVM userTaskVM);
        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void RemoveTask(UserTask task);
    }
}
