using LearnFrameworkMvc.Module;
using LearnFrameworkMvc.Web;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Areas.Configuration.Controllers
{
	[Authorize]
	[Area("Configuration")]
    [AppAuthorize(ModuleFunction.SystemConfigurationView)]
    public class SystemConfigurationController : Controller
    {
        private readonly ILogger<SystemConfigurationController> _logger;

        public SystemConfigurationController(ILogger<SystemConfigurationController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
