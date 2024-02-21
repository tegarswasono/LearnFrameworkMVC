using LearnFrameworkMvc.Module.Services.Master;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetAllData()
        {
            try
            {
                string sortColumnDefault = "username";
                string sortColumnDirectionDefault = "Asc";
                int totalRecord = 0;
                int filterRecord = 0;
                var draw = Request.Form["draw"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][username]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
                int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

                totalRecord = await _userService.CountAllData();
                filterRecord = await _userService.CountAllData();
                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                {
                    sortColumnDefault = sortColumn;
                    sortColumnDirectionDefault = sortColumnDirection;
                }
                var tmp = await _userService.AllData(sortColumnDefault, sortColumnDirectionDefault, skip, pageSize);
                var returnObj = new
                {
                    draw,
                    recordsTotal = totalRecord,
                    recordsFiltered = filterRecord,
                    data = tmp
                };
                return Json(returnObj);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
    }
}
