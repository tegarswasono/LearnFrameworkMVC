using Dapper;
using LearnFrameworkMvc.Module.Helpers;
using LearnFrameworkMvc.Module.Models.Login;
using LearnFrameworkMvc.Module.Models.Master.User;
using LearnFrameworkMvc.Module.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Services
{
    public interface IPermissionService
    {
        Task<UserModel?> IsAuthenticate(LoginModel model);
        Task<List<TbmMenuModel>> GetMenu(string userId);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IDapperDbConnection _dbConnection;
        public PermissionService(IDapperDbConnection dapperDbConnection) 
        { 
            _dbConnection = dapperDbConnection;
        }

        public async Task<UserModel?> IsAuthenticate(LoginModel model)
        {
            var passwordHashed = HashAlgoritmHelper.GetMd5Hash(model.Password);
            var param = new { model.Email, passwordHashed };

            string query = $"SELECT TOP 1 ID, USERNAME, EMAIL, FULLNAME, TELP1, DESCRIPTION, IS_ACTIVE, " +
                $"(select string_agg(name, ',') from TB_M_USER_ROLE a inner join TB_M_ROLE b on a.ROLE_ID = b.ID where a.USER_ID = a1.ID) as Roles " +
                $"FROM TB_M_USER a1 where a1.EMAIL = @email and a1.PASSWORD = @passwordHashed;";

            var result = await _dbConnection.CreateConnection().QueryAsync<UserModel>(query, param);
            return result.FirstOrDefault();
        }
        public async Task<List<TbmMenuModel>> GetMenu(string userId)
        {
            string query = @"select * from tb_m_menu 
                            where FunctionId in 
                            (select a.FUNCTION_ID from TB_M_ROLE_FUNCTION a
                            inner join TB_M_USER_ROLE b on a.ROLE_ID = b.ROLE_ID
                            where b.USER_ID = @userId
                            group by a.FUNCTION_ID) or FunctionId = ''
                            order by orderindex;";
            var param = new { userId };

            var result = await _dbConnection.CreateConnection().QueryAsync<TbmMenuModel>(query, param);
            return result.ToList();
        }
    }
}
