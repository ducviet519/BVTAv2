using DataBVTA.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DataBVTA.Services.Interfaces;
using System.Linq;

namespace AppBVTA.Controllers
{
    public class ChoKhamController : Controller
    {
        private readonly IUnitOfWork _services;
        public ChoKhamController(IUnitOfWork services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> TongQuanKhamBenh()
        {
            DanhSachDangKyKhamBenh model = new DanhSachDangKyKhamBenh();
            model.PhongKham = new SelectList(await _services.DanhMuc.Get_DM_PhongKham(), "makp", "tenkp");
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDanhSachChoKham(string param, string ngayKham, string phongKham, string mabn)
        {
            var danhSachPK = await _services.DanhMuc.Get_DM_PhongKham();
            List<string> maPK = new List<string>();
            foreach (var pk in danhSachPK)
            {
                maPK.Add(pk.makp);
            }
            var data = await _services.DanhSachChoKham.DanhSachChoKhamAsync(param, phongKham, mabn, ngayKham);
            if (String.IsNullOrEmpty(phongKham) == true || phongKham == "-1")
            {
                data = data.Where(s => maPK.Contains(s.maphongkham)).ToList();
            }
            return Json(new { data });
        }

        [HttpGet]
        public IActionResult DanhSachDangKyKCB()
        {
            return PartialView("_DanhSach_DangKyKCB");
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachChuaKham(string mapk)
        {
            DanhSachDangKyKhamBenh model = new DanhSachDangKyKhamBenh();
            model.DanhSachChoKham = await _services.DanhSachChoKham.DanhSachChoKhamAsync("2", mapk);
            return PartialView("_DanhSach_ChiTietChuaKham", model);
        }

        [HttpGet]
        public IActionResult DanhSachChoKham()
        {
            return PartialView("_DanhSach_ChoKham");
        }

        [HttpGet]
        public IActionResult DanhSachDangLamCLS()
        {
            return PartialView("_DanhSach_DangLamCLS");
        }
    }
}
