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
        Task<List<PhieuKhamBenh>> GetPhieuKhamBenh(string mabn = null, string mavaovien = null, string maql = null, string thang = null);
    }
}
