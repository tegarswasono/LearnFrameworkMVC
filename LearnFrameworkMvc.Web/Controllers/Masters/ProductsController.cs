using LearnFrameworkMvc.Web.ConstantString;
using LearnFrameworkMvc.Web.Models;
using LearnFrameworkMvc.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
