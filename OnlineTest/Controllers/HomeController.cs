using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;
using System.Diagnostics;

namespace OnlineTest.Controllers
{
    public class XtraSimpleContent
    {
        public string UserName { get; set; }
        public string References { get; set; }
        public string CreatedTime { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UserInteraction()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
        public IActionResult ExamInstruction()
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
