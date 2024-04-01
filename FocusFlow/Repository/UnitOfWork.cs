using FocusFlow.Data;
using FocusFlow.Repository.IRepository;

namespace FocusFlow.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITaskRepository Task { get; private set; }
        public IPomodoroRepository Pomodoro { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Task = new TaskRepository(_db);
            Pomodoro = new PomodoroRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
