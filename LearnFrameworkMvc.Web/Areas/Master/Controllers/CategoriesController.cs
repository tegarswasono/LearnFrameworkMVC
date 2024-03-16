using LearnFrameworkMvc.Module;
using LearnFrameworkMvc.Web;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Areas.Master.Controllers
{
    [Authorize]
    [Area("Master")]
    [AppAuthorize(ModuleFunction.CategoryView)]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
