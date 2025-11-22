using Dapper;
using Microsoft.Data.SqlClient;
using SimpleWebApp.Models;

namespace SimpleWebApp.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var db = GetConnection();
            var sql = "SELECT * FROM Products ORDER BY Id ASC";
            return await db.QueryAsync<Product>(sql);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var db = GetConnection();
            var sql = "SELECT Name, Price FROM Products WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Product product)
        {
            using var db = GetConnection();
            var sql = @"INSERT INTO Products (Name, Price) VALUES (@Name, @Price);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            var newId = await db.QuerySingleAsync<int>(sql, new { product.Name, product.Price });
            return newId;
        }

        public async Task<int> UpdateAsync(Product product)
        {
            using var db = GetConnection();
            var sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
            return await db.ExecuteAsync(sql, new { product.Name, product.Price, product.Id });
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var db = GetConnection();
            var sql = "DELETE FROM Products WHERE Id = @Id";
            return await db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
