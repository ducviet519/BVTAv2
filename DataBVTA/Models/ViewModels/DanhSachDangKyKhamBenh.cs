using DataBVTA.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DataBVTA.Models.ViewModels
{
    public class DanhSachDangKyKhamBenh
    {
        public List<ChoKhamModel> DanhSachChoKham { get; set; }

        public IEnumerable<SelectListItem> PhongKham { get; set; }
    }
}
