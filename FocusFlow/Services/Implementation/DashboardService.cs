using FocusFlow.DTOs;
using FocusFlow.Models;
using FocusFlow.Repository.IRepository;
using FocusFlow.Services.Interface;
using FocusFlow.Utility;
using System.Globalization;

namespace FocusFlow.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PieChartDTO> GetTasksStatusPieChartData(string userId, bool isAdmin)
        {
            var tasks = _unitOfWork.Task.GetQuery();

            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == userId);
            }

            var completedTasks = tasks.Count(u => u.Status == SD.TaskStatus.Completed);
            var incompletedTasks = tasks.Count(u => u.Status == SD.TaskStatus.InProgress);

            PieChartDTO pieChartDTO = new()
            {
                Labels = new string[] { "Completed", "In progress" },
                Series = new int[] { completedTasks, incompletedTasks }
            };

            return pieChartDTO;
        }

        public async Task<PieChartDTO> GetTasksImportancePieChartData(string userId, bool isAdmin)
        {
            var tasks = _unitOfWork.Task.GetQuery();

            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == userId);
            }

            var lowImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.Low);
            var mediumImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.Medium);
            var highImportanceTasksCount = tasks.Count(u => u.Importance == SD.TaskImportance.High);

            PieChartDTO pieChartDTO = new()
            {
                Labels = new string[] { "Low", "Medium", "High" },
                Series = new int[] { lowImportanceTasksCount, mediumImportanceTasksCount, highImportanceTasksCount }
            };

            return pieChartDTO;
        }

        public IQueryable<UserTask> FilterTasksByUserAndDate(IQueryable<UserTask> tasks, string userId, bool isAdmin)
        {
            if (!isAdmin)
            {
                tasks = tasks.Where(u => u.UserId == userId);
            }

            return tasks.Where(u => u.CreatedAt >= DateTime.Now.AddDays(-30) && u.CreatedAt <= DateTime.Now);
        }

        public Dictionary<string, int> GetTaskDataDict(IQueryable<UserTask> tasks)
        {
            return tasks.GroupBy(u => u.CreatedAt.Date)
                .Select(u => new
                {
                    DateTime = u.Key,
                    TaskCount = u.Count()
                })
                .ToDictionary(u => u.DateTime.ToString("dd/MM"), u => u.TaskCount);
        }

        public async Task<LineChartDTO> GetTasksLineChartData(string userId, bool isAdmin)
        {
            var tasks = _unitOfWork.Task.GetQuery();
            tasks = FilterTasksByUserAndDate(tasks, userId, isAdmin);

            var lowImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.Low));
            var mediumImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.Medium));
            var highImportanceTaskDataDict = GetTaskDataDict(tasks.Where(u => u.Importance == SD.TaskImportance.High));

            var allDates = lowImportanceTaskDataDict.Keys
                .Concat(mediumImportanceTaskDataDict.Keys)
                .Concat(highImportanceTaskDataDict.Keys)
                .Distinct()
                .OrderBy(date => DateTime.ParseExact(date, "dd/MM", new CultureInfo("pl-PL")))
                .ToArray();

            var lowImportanceTaskCountSeries = allDates.Select(date => lowImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();
            var mediumImportanceTaskCountSeries = allDates.Select(date => mediumImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();
            var highImportanceTaskCountSeries = allDates.Select(date => highImportanceTaskDataDict
                                                    .TryGetValue(date, out var count) ? count : 0).ToArray();

            LineChartDTO lineChartDTO = new()
            {
                Series =
                [
                    new() { Name = "Low Importance", Data = lowImportanceTaskCountSeries },
                    new() { Name = "Medium Importance", Data = mediumImportanceTaskCountSeries },
                    new() { Name = "High Importance", Data = highImportanceTaskCountSeries }
                ],
                Categories = allDates
            };

            return lineChartDTO;
        }

        public async Task<LineChartDTO> GetSessionsLineChartData(string userId, bool isAdmin)
        {
            var sessionsChartData = _unitOfWork.Pomodoro.GetAll(u =>
                u.StartTime >= DateTime.Now.AddDays(-30) && u.StartTime <= DateTime.Now)
                .GroupBy(u => u.StartTime.Date)
                .Select(u => new
                {
                    DateTime = u.Key,
                    Count = u.Count()
                });

            var sessionChartDataSeries = sessionsChartData.Select(u => u.Count).ToArray();
            var sessionChartDataDates = sessionsChartData.Select(u => u.DateTime.ToString("dd/MM")).ToArray();

            LineChartDTO lineChartDTO = new()
            {
                Series = [new() { Name = "Sessions", Data = sessionChartDataSeries }],
                Categories = sessionChartDataDates
            };

            return lineChartDTO;
        }
    }
}
