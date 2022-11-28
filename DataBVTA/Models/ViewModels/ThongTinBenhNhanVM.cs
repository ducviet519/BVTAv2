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
        public List<PhieuKhamBenh> PhieuKham_TienSuThuoc { get; set; }
        public List<PhieuKhamBenh> PhieuKham_TrieuChung { get; set; }

        public IEnumerable<SelectListItem> DanhMuc_TenBacSi { get; set; }
        public IEnumerable<SelectListItem> DanhMuc_MaBacSi { get; set; }

        public IEnumerable<SelectListItem> DanhMuc_TenDieuDuong { get; set; }
        public IEnumerable<SelectListItem> DanhMuc_MaDieuDuong { get; set; }

        public IEnumerable<SelectListItem> DanhMuc_MaICD { get; set; }
        public IEnumerable<SelectListItem> DanhMuc_TenICD { get; set; }

        public string mabn { get; set; }
        public string mavaovien { get; set; }
        public string maql { get; set; }
    }
}
