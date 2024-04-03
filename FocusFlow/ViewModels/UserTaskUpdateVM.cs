using FocusFlow.Models;
using FocusFlow.ViewModels.Interface;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FocusFlow.ViewModels
{
    public class UserTaskUpdateVM : IUserTaskVM
    {
        public UserTask UserTask { get; set; }
        [ValidateNever]
        [DisplayName("Status")]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        [DisplayName("Importance")]
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
