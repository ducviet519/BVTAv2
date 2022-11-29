﻿using Dapper;
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
    public class ThongTinHanhChinhRepository: IThongTinHanhChinhRepository
    {
        #region Database Connection
        private readonly IConfiguration _configuration;
        public ThongTinHanhChinhRepository(IConfiguration configuration)
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
        //sp_phieukham__thongtinhanhchinh
        public async Task<ThongTinBenhNhan> GetThongTinHanhChinh(string mabn, string mavaovien, string maql)
        {

            ThongTinBenhNhan data = new ThongTinBenhNhan();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    data = (await dbConnection.QueryFirstOrDefaultAsync<ThongTinBenhNhan>("sp_phieukham_thongtinchinh",
                        new
                        {
                            mabn = mabn,
                            mavaovien = mavaovien,
                            maql = maql,
                        }, commandType: CommandType.StoredProcedure));
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
