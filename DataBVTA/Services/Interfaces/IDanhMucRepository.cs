using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IDanhMucRepository
    {
        Task<List<PhongKhamModel>> Get_DM_PhongKham();

        Task<List<BacSiModel>> Get_DM_BacSi();

        Task<List<DieuDuongModel>> Get_DM_DieuDuong();

        Task<List<ChanDoanModel>> Get_DM_ICD10();
    }
}
