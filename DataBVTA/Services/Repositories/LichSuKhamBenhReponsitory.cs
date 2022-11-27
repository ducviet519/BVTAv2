using Dapper;
using DataBVTA.Models.Entities;
using DataBVTA.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class LichSuKhamBenhReponsitory: ILichSuKhamBenhReponsitory
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public LichSuKhamBenhReponsitory(IConfiguration configuration)
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

        //sp_phieukham__lichsukhambenh
        public async Task<List<LichSuKhamBenh>> GetLichSuKhamBenh(string mabn, string ngaykham = null, string maql = null, string thang = null)
        {
            DateTime ngaykhamD = new DateTime();
            //if (!String.IsNullOrEmpty(ngaykham)) { ngaykhamD = Convert.ToDateTime(ngaykham, CultureInfo.InvariantCulture); }
            List<LichSuKhamBenh> data = new List<LichSuKhamBenh>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    data = (await dbConnection.QueryAsync<LichSuKhamBenh>("sp_phieukham__lichsukhambenh",
                        new
                        {
                            mabn = mabn,
                            ngaykham = ngaykham,
                            maql = maql,
                            thang = thang
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
