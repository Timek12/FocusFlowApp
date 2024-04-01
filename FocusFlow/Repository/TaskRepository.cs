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

        public void Update(UserTask task)
        {
            _db.Tasks.Update(task);
        }
    }
}
