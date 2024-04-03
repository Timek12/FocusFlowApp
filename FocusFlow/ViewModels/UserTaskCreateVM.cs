using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using static FocusFlow.Utility.SD;
using System.ComponentModel.DataAnnotations;
using FocusFlow.ViewModels.Interface;

namespace FocusFlow.ViewModels
{
    public class UserTaskCreateVM : IUserTaskVM
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Utility.SD.TaskStatus Status { get; set; }
        public TaskImportance Importance { get; set; } = 0;
        public DateTime Deadline { get; set; }
        [ValidateNever]
        [DisplayName("Status")]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        [DisplayName("Importance")]
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
