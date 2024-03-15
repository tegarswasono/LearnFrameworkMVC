using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Areas.Configuration.Controllers
{
    [Authorize]
    [Area("Configuration")]
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
