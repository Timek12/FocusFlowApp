using Microsoft.AspNetCore.Mvc;

namespace FocusFlow.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
