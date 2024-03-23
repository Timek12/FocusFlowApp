using FocusFlow.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FocusFlow.ViewModels
{
    public class UserTaskVM
    {
        public UserTask? UserTask { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
