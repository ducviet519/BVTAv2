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
    public class PhieuKhamBenhRepository: IPhieuKhamBenhRepository
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public PhieuKhamBenhRepository(IConfiguration configuration)
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
        //sp_phieukham__thongtinphieu
        public async Task<List<PhieuKhamBenh>> GetPhieuKhamBenh(string mabn = null, string mavaovien = null, string maql = null, string thang = null)
        {
            List<PhieuKhamBenh> data = new List<PhieuKhamBenh>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    data = (await dbConnection.QueryAsync<PhieuKhamBenh>("sp_phieukham__thongtinphieu",
                        new
                        {
                            mabn = mabn,
                            mavaovien = mavaovien,
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
