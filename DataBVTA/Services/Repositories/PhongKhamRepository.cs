using Dapper;
using DataBVTA.Models.Entities;
using DataBVTA.Services.Interfaces;
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
    public class PhongKhamRepository : IPhongKhamRepository
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public PhongKhamRepository(IConfiguration configuration)
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
        public async Task<List<PhongKhamModel>> DanhSachPhongKhamAsync()
        {
            List<PhongKhamModel> data = new List<PhongKhamModel>();

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    data = (await dbConnection.QueryAsync<PhongKhamModel>("sp_HIS_DM", new { param = 1 }, commandType: CommandType.StoredProcedure)).ToList();
                    dbConnection.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return data;
            }
        }
    }
}
