using Dapper;
using LearnFrameworkMvc.Module.Entities;
using LearnFrameworkMvc.Module.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(Product Product);
        Task<bool> UpdateProductAsync(Product Product);
        Task<bool> DeleteProductAsync(int id);
    }
    public class ProductRepository : IProductRepository
    {
        public IDapperDbConnection _dapperDbConnection;
        public ProductRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<Product>("SELECT * FROM LEARN_DUPPER_PRODUCT");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Product>("SELECT * FROM LEARN_DUPPER_PRODUCT WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> CreateProductAsync(Product Product)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "INSERT INTO LEARN_DUPPER_PRODUCT (Name) VALUES (@Name); SELECT SCOPE_IDENTITY();";
                return await db.ExecuteScalarAsync<int>(query, Product);
            }
        }

        public async Task<bool> UpdateProductAsync(Product Product)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "UPDATE LEARN_DUPPER_PRODUCT SET Name = @Name WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, Product);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "DELETE FROM LEARN_DUPPER_PRODUCT WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
