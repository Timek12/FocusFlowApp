using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FocusFlow.Models
{
    public class PomodoroSession
    {
        [Key]
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public bool isRunning { get; set; }
        public bool isBreak {  get; set; }
        public List<UserTask>? Tasks { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
