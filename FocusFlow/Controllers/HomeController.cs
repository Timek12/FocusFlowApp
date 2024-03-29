using FocusFlow.DTOs;
using FocusFlow.Models;
using FocusFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace FocusFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new();

            using HttpClient client = new();
            try
            {
                string response = await client.GetStringAsync("https://zenquotes.io/api/quotes/");
                var quoteList = JsonConvert.DeserializeObject<List<ZenQuoteDTO>>(response);
                homeVM.Quotes = quoteList.Take(5);
            }
            catch (HttpRequestException ex)
            {
                return View();
            }

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Attributions()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
