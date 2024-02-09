using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Services
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
    public class DapperDbConnection : IDapperDbConnection
    {
        public readonly string _connectionString;
        public DapperDbConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public IDbConnection CreateConnection() 
        { 
            return new SqlConnection(_connectionString);
        }
    }
}
