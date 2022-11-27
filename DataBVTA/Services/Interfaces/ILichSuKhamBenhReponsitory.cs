using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface ILichSuKhamBenhReponsitory
    {
        Task<List<LichSuKhamBenh>> GetLichSuKhamBenh(string mabn, string ngaykham = null, string maql = null, string thang = null);
    }
}
