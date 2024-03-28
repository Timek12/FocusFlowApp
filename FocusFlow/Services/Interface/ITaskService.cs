namespace FocusFlow.Services.Interface
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAllTasks(string userId);
        Task GetTaskById(int taskId);

        void AddTask(Task task);
        void UpdateTask(Task task);
        void RemoveTask(Task task);
    }
}
