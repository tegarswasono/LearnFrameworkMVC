using LearnFrameworkMvc.Web.ConstantString;
using LearnFrameworkMvc.Web.Models;
using LearnFrameworkMvc.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly ILogger<MyProfileController> _logger;

        public MyProfileController(ILogger<MyProfileController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}