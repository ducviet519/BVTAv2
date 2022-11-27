using DataBVTA.Models.Entities;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.Controllers
{
    [Authorize]
    public class CoXuongKhopController : Controller
    {
        private readonly IUnitOfWork _services;
        public CoXuongKhopController(IUnitOfWork services)
        {
            _services = services;
        }

        #region Thông tin chung của bệnh nhân
        
        public IActionResult DanhMuc()
        {
            return PartialView("_DanhMuc");
        }
        public IActionResult BieuDo()
        {
            return PartialView("_BieuDo");
        }

        #endregion

        #region 1. Khám lâm sàng

        public async Task<IActionResult> PhieuKhamBenh(string mabn, string maphongkham)
        {
            mabn = "88888888";
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.LichSuKhamBenh = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn);
            model.ThongTinHanhChinh = (await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn)).Where(i => i.mabn != null).FirstOrDefault();
            //string mavaovien = (await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn))
            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> KhamLamSang(string mabn)
        {
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.LichSuKhamBenh = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn);
            model.ThongTinHanhChinh = (await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn)).Where(i => i.mabn != null).FirstOrDefault();
            return PartialView("_PhieuKhamBenh_KhamLamSang", model);
        }

        #endregion

        #region 2. Đánh giá

        public IActionResult DanhGiaASDAS()
        {
            return View();
        }
        public IActionResult DanhGiaDAPSA()
        {
            return View();
        }
        public IActionResult DanhGiaPASI()
        {
            return View();
        }

        #endregion

        #region 3. Chỉ định

        public IActionResult ChiDinh()
        {
            return View();
        }
        public IActionResult KetQuaChanDoanHinhAnh()
        {
            return PartialView("_KetQuaChanDoanHinhAnh");
        }
        public IActionResult KetQuaXetNghiem()
        {
            return PartialView("_KetQuaXetNghiem");
        }
        public IActionResult ThemMoiChiDinh()
        {
            return View();
        }
        #endregion

        #region 4. Danh sách đơn thuốc
        public IActionResult DanhSachDonThuoc()
        {
            return View();
        }
        public IActionResult ThemMoiDonThuoc()
        {
            return PartialView("_ThemMoiDonThuoc");
        }
        public IActionResult SuaDonThuoc()
        {
            return PartialView("_SuaDonThuoc");
        }
        #endregion

        #region 5. Xử trí
        public IActionResult XuTri()
        {
            return View();
        }
        #endregion
    }
}
