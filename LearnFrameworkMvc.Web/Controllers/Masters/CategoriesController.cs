using LearnFrameworkMvc.Web.ConstantString;
using LearnFrameworkMvc.Web.Models;
using LearnFrameworkMvc.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
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
