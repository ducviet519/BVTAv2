using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IThongTinHanhChinhRepository
    {
        Task<ThongTinBenhNhan> GetThongTinHanhChinh(string mabn, string mavaovien, string maql);
    }
}
