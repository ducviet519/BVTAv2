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
    public class ChoKhamRepository : IChoKhamRepository
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public ChoKhamRepository(IConfiguration configuration)
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

        public async Task<List<ChoKhamModel>> DanhSachChoKhamAsync(string param, string maPhongKham = null, string mabn = null, string ngayKham = null)
        {
            List<ChoKhamModel> data = new List<ChoKhamModel>();
            if(String.IsNullOrEmpty(ngayKham)) { ngayKham = DateTime.Now.ToString("yyyyMMdd"); }
            if (String.IsNullOrEmpty(maPhongKham)) { maPhongKham = "-1"; }
            if (String.IsNullOrEmpty(mabn)) { mabn = "-1"; } 


            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    data = (await dbConnection.QueryAsync<ChoKhamModel>("sp_HIS_chokham",
                        new {
                            date = ngayKham,
                            phongkham = maPhongKham,
                            mabn = mabn,
                            param = param
                        }, commandType: CommandType.StoredProcedure)).ToList();
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
