using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Services.Interface;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using static FocusFlow.Utility.SD;

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

        public void CreateTask(UserTaskCreateVM userTaskVM, string userId)
        {
            if(userTaskVM is not null)
            {
                UserTask userTask = new()
                {
                    Name = userTaskVM.Name,
                    Description = userTaskVM.Description,
                    Status = userTaskVM.Status,
                    Importance = userTaskVM.Importance,
                    CreatedAt = DateTime.Now,
                    Deadline = userTaskVM.Deadline,
                    UserId = userId
                };

                _unitOfWork.Task.Add(userTask);
                _unitOfWork.Save();
            }
        }

        public UserTaskCreateVM CreateUserTaskCreateVM()
        {
            return new UserTaskCreateVM()
            {
                StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }),
                ImportanceList = Enum.GetValues(typeof(TaskImportance))
                .Cast<TaskImportance>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }),
            };
        }

        public UserTaskUpdateVM CreateUserTaskUpdateVM(string userId, int taskId)
        {
            UserTaskUpdateVM userTaskUpdateVM = new()
            {
                UserTask = _unitOfWork.Task.Get(u => u.UserId == userId, tracked: true),

                StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                }),

                ImportanceList = Enum.GetValues(typeof(TaskImportance))
                .Cast<TaskImportance>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                })
            };

            userTaskUpdateVM.UserTask.TaskId = taskId;
            return userTaskUpdateVM;
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

        public void UpdateUserTaskCreateVM(UserTaskCreateVM userTaskVM)
        {
            if(userTaskVM is not null)
            {
                userTaskVM.StatusList = Enum.GetValues(typeof(Utility.SD.TaskStatus))
                .Cast<Utility.SD.TaskStatus>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });

                userTaskVM.ImportanceList = Enum.GetValues(typeof(TaskImportance))
                .Cast<TaskImportance>().Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });
            }
        }
    }
}
