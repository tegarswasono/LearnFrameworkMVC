using Dapper;
using LearnFrameworkMvc.Module.Models.Master.Role;
using LearnFrameworkMvc.Module.Services;
using LearnFrameworkMvc.Module.Services.Master;
using LearnFrameworkMvc.Web.ConstantString;
using LearnFrameworkMvc.Web.Models;
using LearnFrameworkMvc.Web.Models.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IDapperDbConnection _dbConnection;
        private readonly IRoleService _roleService;

		public RolesController(ILogger<RolesController> logger, IDapperDbConnection dbConnection, IRoleService roleService)
        {
            _logger = logger;
            _dbConnection = dbConnection;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var result = new RoleIndexVM()
            {
                Data = _roleService.GetAllData()
            };
            return View(result);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _roleService.ViewById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CreateOrUpdateRoleModel model)
        {
            try
            {
				await _roleService.CreateOrUpdate(model);
				return Ok("Success");
			}
			catch (Exception ex)
            {
                return BadRequest(ex.Message);
			}
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
