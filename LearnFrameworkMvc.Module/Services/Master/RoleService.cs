using Dapper;
using LearnFrameworkMvc.Module.Models;
using LearnFrameworkMvc.Module.Models.Master.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Services.Master
{
	public interface IRoleService
	{
		List<RoleModel> GetAllData();
		Task CreateOrUpdate(CreateOrUpdateRoleModel model);
	}
	public class RoleService : IRoleService
	{
		private readonly IDapperDbConnection _dbConnection;
		public RoleService(IDapperDbConnection dbConnection) 
		{ 
			_dbConnection = dbConnection;
		}

		public List<RoleModel> GetAllData()
		{
			var result = _dbConnection.CreateConnection().Query<RoleModel>("SELECT * FROM TB_M_ROLE").ToList();
			return result;
		}
		public async Task CreateOrUpdate(CreateOrUpdateRoleModel model)
		{
			bool isValid = true;
			string msgError = string.Empty;
			var param = new DynamicParameters();
			param.Add("Id", model.ID);
			param.Add("Name", model.NAME);
			param.Add("Description", model.DESCRIPTION);
			param.Add("CreatedBy", "");
			param.Add("IsValid", isValid, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
			param.Add("MsgError", msgError, System.Data.DbType.String, System.Data.ParameterDirection.Output);

			await _dbConnection.CreateConnection().QueryAsync("USP_ROLE_CREATE_OR_UPDATE", param, commandType: System.Data.CommandType.StoredProcedure);
			isValid = param.Get<bool>("IsValid");
			msgError = param.Get<string>("MsgError");

			if (!isValid)
			{
				throw new InvalidOperationException(msgError);
			}
		}
	}
}
