using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Areas.Configuration.Controllers
{
	[Authorize]
	[Area("Configuration")]
	public class SMTPSettingController : Controller
    {
        public SMTPSettingController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
