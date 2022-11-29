using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IPhieuKhamBenhRepository
    {
        Task<List<PhieuKhamBenh>> Get_PhieuKham_TrieuChung(string mabn, string mavaovien, string maql);
        Task<List<PhieuKhamBenh>> Get_PhieuKham_TienSuThuoc(string mabn, string mavaovien, string maql);
    }
}
