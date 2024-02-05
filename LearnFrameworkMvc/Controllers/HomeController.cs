using LearnFrameworkMvc.ConstantString;
using LearnFrameworkMvc.Models;
using LearnFrameworkMvc.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tmp = ModuleFunction.CategoryAdd;
            var tmp11 = tmp.Split(".")[0];
            var tmp12 = tmp.Split(".")[1];

            var tmp1 = ModuleFunction.GetAll();

            return View();
        }

        public IActionResult Privacy()
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
