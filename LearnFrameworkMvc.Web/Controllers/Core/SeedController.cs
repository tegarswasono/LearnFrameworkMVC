using Dapper;
using LearnFrameworkMvc.Module;
using LearnFrameworkMvc.Module.Services;
using LearnFrameworkMvc.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Text.Json;

namespace LearnFrameworkMvc.Web.Controllers
{
    public class SeedController : Controller
    {
        private readonly ILogger<SeedController> _logger;
        private readonly IDapperDbConnection _dbConnection;

        public SeedController(ILogger<SeedController> logger, IDapperDbConnection dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        public IActionResult Index()
        {
            try
            {
				string by = "SYSTEM";
				var data = ModuleFunction.GetAll();
				var dataSerialize = JsonSerializer.Serialize(data);
				var param = new { BY = by, DATA = dataSerialize };
				_dbConnection.CreateConnection().Execute("USP_UPD_MODULE_FUNCTION", param, commandType: CommandType.StoredProcedure);
				return Ok("Seed Successfully");
			}catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
