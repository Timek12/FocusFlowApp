using FocusFlow.Data;
using FocusFlow.Models;
using FocusFlow.Repository.IRepository;

namespace FocusFlow.Repository
{
    public class TaskRepository : Repository<UserTask>, ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(UserTask task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }
    }
}
