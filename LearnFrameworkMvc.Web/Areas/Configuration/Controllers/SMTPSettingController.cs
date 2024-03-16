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
    [AppAuthorize(ModuleFunction.SMTPSettingView)]
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
