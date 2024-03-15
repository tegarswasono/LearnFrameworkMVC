using Dapper;
using LearnFrameworkMvc.Module.Models.Master.Role;
using LearnFrameworkMvc.Module.Services;
using LearnFrameworkMvc.Module.Services.Master;
using Microsoft.AspNetCore.Mvc;
using LearnFrameworkMvc.Module;
using LearnFrameworkMvc.Module.Models.Core;
using LearnFrameworkMvc.Module.Models.Master.Function;
using Microsoft.AspNetCore.Authorization;

namespace LearnFrameworkMvc.Areas.Configuration.Controllers
{
	[Authorize]
	[Area("Configuration")]
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
			try
			{
				return View();
			}
			catch (Exception)
			{
				return BadRequest();
			}
        }

		[HttpPost]
		public async Task<JsonResult> GetAllData()
		{
			try
			{
				string sortColumnDefault = "Name";
				string sortColumnDirectionDefault = "Asc";
				int totalRecord = 0;
				int filterRecord = 0;
				var draw = Request.Form["draw"].FirstOrDefault();
				var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
				var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
				int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
				int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

				totalRecord = await _roleService.CountAllData();
				filterRecord = await _roleService.CountAllData();
				if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
				{
					sortColumnDefault = sortColumn;
					sortColumnDirectionDefault = sortColumnDirection;
				}
				var tmp = await _roleService.AllData(sortColumnDefault, sortColumnDirectionDefault, skip, pageSize);
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

		public async Task<JsonResult> GetAllModule(Guid? roleId)
		{
			try
			{
				List<FunctionModel> moduleFunctionModels = await _roleService.GetAllModuleFunction(roleId);
				var result = FunctionVM.Dto(moduleFunctionModels);
				return Json(result);
			}catch (Exception) 
			{
				return Json(null);
			}
		}

		public async Task<IActionResult> GetById(Guid id)
        {
			try
			{
				return Ok(await _roleService.ViewById(id));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

		[HttpPost]
        public async Task<IActionResult> CreateOrUpdate(CreateOrUpdateRoleModel model)
        {
            try
            {
				await _roleService.CreateOrUpdate(model);
				return Ok(ConstantString.ProcessSuccessfully);
			}
			catch (Exception ex)
            {
                return BadRequest(ex.Message);
			}
        }

		[HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
			try
			{
				await _roleService.DeleteById(id);
				return Ok(ConstantString.DeleteSuccessfully);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }
    }
}
