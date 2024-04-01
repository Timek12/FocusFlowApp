using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FocusFlow.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddTask(UserTask task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<UserTask> GetAllTasks(string userId, bool isAdmin)
        {
            return isAdmin ? _db.Tasks : _db.Tasks.Where(u => u.UserId == userId);
        }

        public async Task<UserTask> GetTaskById(int taskId)
        {
            return await _db.Tasks.FirstOrDefaultAsync(u => u.TaskId == taskId);
        }

        public IQueryable<UserTask> GetUserTasksQuery()
        {
            return _db.Tasks.AsQueryable();
        }

        public async Task RemoveTask(UserTask task)
        {
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTask(UserTask task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
