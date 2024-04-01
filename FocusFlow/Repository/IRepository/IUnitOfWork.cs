namespace FocusFlow.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
        IPomodoroRepository Pomodoro { get; }
        void Save();
    }
}
