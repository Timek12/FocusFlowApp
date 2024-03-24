using FocusFlow.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FocusFlow.ViewModels
{
    public class UserTaskVM
    {
        public UserTask? UserTask { get; set; }
        [ValidateNever]
        [DisplayName("Status")]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        [DisplayName("Importance")]
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
