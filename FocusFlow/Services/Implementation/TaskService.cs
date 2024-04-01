using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Services.Interface;

namespace FocusFlow.Services.Implementation
{
    public class TaskService : ITaskService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTask(UserTask task)
        {
            _unitOfWork.Task.Add(task);
            _unitOfWork.Save();
        }

        public IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin)
        {
            return isAdmin ? _unitOfWork.Task.GetAll() : _unitOfWork.Task.GetAll(u => u.UserId == userId);
        }

        public UserTask? GetTaskById(int taskId)
        {
            return _unitOfWork.Task.Get(u => u.TaskId == taskId, tracked: true);
        }

        public IQueryable<UserTask> GetUserTasksQuery()
        {
            return _unitOfWork.Task.GetQuery();
        }

        public void RemoveTask(UserTask task)
        {
            _unitOfWork.Task.Remove(task);
            _unitOfWork.Save();
        }

        public void UpdateTask(UserTask task)
        {
            _unitOfWork.Task.Update(task);
            _unitOfWork.Save();
        }
    }
}
