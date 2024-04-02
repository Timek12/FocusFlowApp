using FocusFlow.DTOs;
using FocusFlow.Models;

namespace FocusFlow.Services.Interface
{
    public interface IDashboardService
    {
        Task<PieChartDTO> GetTasksStatusPieChartData(string userId, bool isAdmin);
        Task<PieChartDTO> GetTasksImportancePieChartData(string userId, bool isAdmin);
        Task<LineChartDTO> GetTasksLineChartData(string userId, bool isAdmin);
        Task<LineChartDTO> GetSessionsLineChartData(string userId, bool isAdmin);
        IQueryable<UserTask> FilterTasksByUserAndDate(IQueryable<UserTask> tasks, string userId, bool isAdmin);
        Dictionary<string, int> GetTaskDataDict(IQueryable<UserTask> tasks);
    }
}
