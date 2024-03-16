using LearnFrameworkMvc.Module;
using LearnFrameworkMvc.Web;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Areas.Transaction.Controllers
{
    [Authorize]
    [Area("Transaction")]
    [AppAuthorize(ModuleFunction.BookingsView)]
    public class BookingsController : Controller
    {
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ILogger<BookingsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
