using Dapper;
using LearnFrameworkMvc.Module.Models;
using LearnFrameworkMvc.Module.Models.Core;
using LearnFrameworkMvc.Module.Models.Master.Function;
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
		Task<List<RoleModel>> AllData(string sortColumn, string sortColumnDirection, int skip, int pageSize);
		Task<int> CountAllData();
		Task<RoleModel?> ViewById(Guid id);
		Task<List<FunctionModel>> GetAllModuleFunction(Guid? roleId);
		Task CreateOrUpdate(CreateOrUpdateRoleModel model);
		Task DeleteById(Guid id);
	}
	public class RoleService : IRoleService
	{
		private readonly IDapperDbConnection _dbConnection;
		public RoleService(IDapperDbConnection dbConnection) 
		{ 
			_dbConnection = dbConnection;
		}

		public async Task<List<RoleModel>> AllData(string sortColumn, string sortColumnDirection, int skip, int pageSize)
		{
			try
			{
				var param = new { skip, pageSize };
				string query = $"SELECT * FROM TB_M_ROLE ORDER BY {sortColumn} {sortColumnDirection} OFFSET @skip ROWS FETCH NEXT @pageSize ROWS ONLY;";
				var result = await _dbConnection.CreateConnection().QueryAsync<RoleModel>(query, param);
				return result.ToList();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task<int> CountAllData()
		{
			try
			{
				var result = await _dbConnection.CreateConnection().QueryAsync<int>("SELECT COUNT(1) FROM TB_M_ROLE");
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task<RoleModel?> ViewById(Guid id)
		{
			try
			{
				var param = new { Id = id };
				string query = "SELECT TOP 1 * FROM TB_M_ROLE WHERE ID = @Id";
				var result = await _dbConnection.CreateConnection().QueryAsync<RoleModel>(query, param);
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}

		public async Task<List<FunctionModel>> GetAllModuleFunction(Guid? roleId)
		{
			try
			{
				var param = new { roleId };
				string query = "SELECT * FROM TB_M_FUNCTION;";
				var result = await _dbConnection.CreateConnection().QueryAsync<FunctionModel>(query, param);
				return result.ToList();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task CreateOrUpdate(CreateOrUpdateRoleModel model)
		{
			try
			{
				bool isValid = true;
				string msgError = string.Empty;
				var param = new DynamicParameters();
				param.Add("Id", model.Id);
				param.Add("Name", model.Name);
				param.Add("Description", model.Description);
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
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task DeleteById(Guid id)
		{
			try
			{
				var param = new { id };
				string query = "DELETE TB_M_ROLE WHERE ID = @id";
				var result = await _dbConnection.CreateConnection().ExecuteAsync(query, param);
				if (result == 0)
				{
					throw new InvalidOperationException(ConstantString.DeleteFailed);
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
	}
}
