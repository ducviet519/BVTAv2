using DataBVTA.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.ViewModels
{
    public class ThongTinBenhNhanVM
    {
        public List<LichSuKhamBenh> LichSuKhamBenh { get; set; }
        public ThongTinBenhNhan ThongTinHanhChinh { get; set; }
        public PhieuKhamBenh PhieuKhamBenh { get; set; }
        public string mabn { get; set; }
    }
}
