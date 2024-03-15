using Dapper;
using LearnFrameworkMvc.Module.Helpers;
using LearnFrameworkMvc.Module.Models.Login;
using LearnFrameworkMvc.Module.Models.Master.User;
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
    }
}
