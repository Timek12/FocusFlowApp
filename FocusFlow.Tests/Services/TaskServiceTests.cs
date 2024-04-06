using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Services.Implementation;
using Moq;

namespace FocusFlow.Tests.Services
{
    public class TaskServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private TaskService _taskService;

        public TaskServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _taskService = new TaskService(_unitOfWorkMock.Object);
        }

        [Fact]
        public void AddTask_CallsAddAndSaveOnUnitOfWork()
        {
            // Arrange
            var task = new UserTask();

            // Act
            _taskService.AddTask(task);

            // Assert
            _unitOfWorkMock.Verify(m => m.Task.Add(task), Times.Once);
            _unitOfWorkMock.Verify(m => m.Save(), Times.Once);
        }

    }
}
