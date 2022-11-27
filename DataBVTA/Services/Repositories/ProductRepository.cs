using DataBVTA.Models.Entities;
using DataBVTA.Services.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            provideName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; }
        public string provideName { get; }
        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }
        #endregion

        public async Task<int> AddAsync(Product entity)
        {
            entity.AddedOn = DateTime.Now;
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> UpdateAsync(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
