using LearnFrameworkMvc.Web.ConstantString;
using LearnFrameworkMvc.Web.Models;
using LearnFrameworkMvc.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
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
