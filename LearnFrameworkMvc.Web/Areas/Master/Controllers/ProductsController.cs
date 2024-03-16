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
    [AppAuthorize(ModuleFunction.ProductView)]
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
