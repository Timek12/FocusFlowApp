using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace FocusFlow.ViewModels.Interface
{
    public interface IUserTaskVM
    {
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> ImportanceList { get; set; }
    }
}
