using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FocusFlow.Utility.SD;

namespace FocusFlow.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Utility.SD.TaskStatus Status { get; set; }
        public TaskImportance Importance { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
