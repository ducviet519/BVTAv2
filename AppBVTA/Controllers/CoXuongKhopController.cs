﻿using DataBVTA.Models.Entities;
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

        #region 1. Khám lâm sàng

        public async Task<IActionResult> PhieuKhamBenh(string mabn, string mavaovien, string maql)
        {
            if(String.IsNullOrEmpty(mabn)) { mabn = "16000569"; mavaovien = "221128002601722353"; }
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.mabn = mabn;
            model.mavaovien = mavaovien;
            model.maql = maql;
            model.ThongTinHanhChinh = await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn, mavaovien, maql);
            model.PhieuKham_TienSuThuoc = await _services.PhieuKhamBenh.Get_PhieuKham_TienSuThuoc(mabn, mavaovien, maql);
            model.PhieuKham_TrieuChung = await _services.PhieuKhamBenh.Get_PhieuKham_TrieuChung(mabn, mavaovien, maql);

            //model.DanhMuc_TenBacSi = new SelectList((await _services.DanhMuc.Get_DM_BacSi()).Select(s => new { ma = s.ma, hoten = $"{s.ma} | {s.hoten}"}).ToList(), "ma", "hoten");
            model.DanhMuc_TenBacSi = new SelectList(await _services.DanhMuc.Get_DM_BacSi(), "ma", "hoten");
            model.DanhMuc_MaBacSi = new SelectList(await _services.DanhMuc.Get_DM_BacSi(), "ma", "ma");
            //model.DanhMuc_TenDieuDuong = new SelectList((await _services.DanhMuc.Get_DM_DieuDuong()).Select(s => new { ma = s.ma, hoten = $"{s.ma} | {s.hoten}" }).ToList(), "ma", "hoten");
            model.DanhMuc_TenDieuDuong = new SelectList(await _services.DanhMuc.Get_DM_DieuDuong(), "ma", "hoten");
            model.DanhMuc_MaDieuDuong = new SelectList(await _services.DanhMuc.Get_DM_DieuDuong(), "ma", "ma");
            model.DanhMuc_TenICD = new SelectList(await _services.DanhMuc.Get_DM_ICD10(), "CICD10", "VVIET");
            model.DanhMuc_MaICD = new SelectList(await _services.DanhMuc.Get_DM_ICD10(), "CICD10", "CICD10");
            return View(model);
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
        public IActionResult DanhSachDonThuoc(string mabn, string mavaovien, string maql)
        {
            if (String.IsNullOrEmpty(mabn)) { mabn = "16000569"; mavaovien = "221128002601722353"; }
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.mabn = mabn;
            model.mavaovien = mavaovien;
            model.maql = maql;
            return View(model);
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
