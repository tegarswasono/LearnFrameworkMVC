using Dapper;
using LearnFrameworkMvc.Module.Models;
using LearnFrameworkMvc.Module.Models.Core;
using LearnFrameworkMvc.Module.Models.Master.Function;
using LearnFrameworkMvc.Module.Models.Master.Role;
using LearnFrameworkMvc.Module.Models.Master.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnFrameworkMvc.Module.Helpers;

namespace LearnFrameworkMvc.Module.Services.Master
{
	public interface IUserService
	{
		Task<List<UserModel>> AllData(string sortColumn, string sortColumnDirection, int skip, int pageSize);
		Task<int> CountAllData();
		Task<List<GeneralDatasourceModel>> GetRoles(Guid? userId);
        Task<UserModel?> ViewById(Guid id);
		Task CreateOrUpdate(CreateOrUpdateUserModel model);
		Task DeleteById(Guid id);
	}
	public class UserService : IUserService
	{
		private readonly IDapperDbConnection _dbConnection;
		public UserService(IDapperDbConnection dbConnection) 
		{ 
			_dbConnection = dbConnection;
		}

		public async Task<List<UserModel>> AllData(string sortColumn, string sortColumnDirection, int skip, int pageSize)
		{
			try
			{
				var param = new { skip, pageSize };
				string query = $"SELECT ID, USERNAME, EMAIL, FULLNAME, TELP1, DESCRIPTION, IS_ACTIVE, " +
					$"(select string_agg(name, ',') from TB_M_USER_ROLE a inner join TB_M_ROLE b on a.ROLE_ID = b.ID where a.USER_ID = a1.ID) as Roles " +
					$"FROM TB_M_USER a1 ORDER BY {sortColumn} {sortColumnDirection} OFFSET @skip ROWS FETCH NEXT @pageSize ROWS ONLY;";
                var result = await _dbConnection.CreateConnection().QueryAsync<UserModel>(query, param);
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
				var result = await _dbConnection.CreateConnection().QueryAsync<int>("SELECT COUNT(1) FROM TB_M_USER");
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task<List<GeneralDatasourceModel>> GetRoles(Guid? userId)
		{
			try
			{
                var param = new { userId };
                string query = @"select Id as Value, Name as Text from TB_M_ROLE order by Name;";
				if (userId != null && userId != Guid.Empty)
				{
					query = @"select 
								a.Id as Value, a.Name as Text,
								case when exists(select top 1 1 from tb_m_user_role where user_id = @userId and role_id = a.Id)
								then 1 else 0 end
								as Selected
							from TB_M_ROLE a order by a.Name;";
				}
				var result = await _dbConnection.CreateConnection().QueryAsync<GeneralDatasourceModel>(query, param);
				return result.ToList();
			}catch(Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task<UserModel?> ViewById(Guid id)
		{
			try
			{
				var param = new { Id = id };
				string query = "SELECT TOP 1 * FROM TB_M_USER WHERE ID = @Id";
				var result = await _dbConnection.CreateConnection().QueryAsync<UserModel>(query, param);
				return result.FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
		}
		public async Task CreateOrUpdate(CreateOrUpdateUserModel model)
		{
			try
			{
                bool isValid = true;
				string msgError = string.Empty;
				var param = new DynamicParameters();
				param.Add("Id", model.Id);
				param.Add("Fullname", model.Fullname);
				param.Add("Username", model.Username);
				param.Add("Email", model.Email);
				param.Add("Telp1", model.Telp1);
				param.Add("Description", model.Description);
				param.Add("Roles", model.Roles.ConvertListStringToString());
                param.Add("Is_Active", model.IsActive);
				param.Add("CreatedBy", "");
				param.Add("IsValid", isValid, System.Data.DbType.Boolean, System.Data.ParameterDirection.Output);
				param.Add("MsgError", msgError, System.Data.DbType.String, System.Data.ParameterDirection.Output);

				await _dbConnection.CreateConnection().QueryAsync("USP_USER_CREATE_OR_UPDATE", param, commandType: System.Data.CommandType.StoredProcedure);
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
				string query = "DELETE TB_M_USER_ROLE WHERE USER_ID = @id;DELETE TB_M_USER WHERE ID = @id";
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
