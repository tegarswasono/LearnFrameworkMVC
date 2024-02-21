using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class SystemConfigurationController : Controller
    {
        private readonly ILogger<MyProfileController> _logger;

        public SystemConfigurationController(ILogger<MyProfileController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
