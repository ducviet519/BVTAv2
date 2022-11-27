using DataBVTA.Models.Entities;
using DataBVTA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace AppBVTA.Controllers
{
    public class BenhNhanController : Controller
    {
        public JsonResult GetBacSi(string mabs = null, string term = null)
        {
            List<BacSiModel> listBacSi = new List<BacSiModel>();
            for (var i = 0; i < 9; i++)
            {
                var item1 = new BacSiModel()
                {
                    mabs = $"00{i}",
                    tenbs = $"Tên bác sĩ {i}",
                };
                listBacSi.Add(item1);
            }
            if (!String.IsNullOrEmpty(term)){

                var data = listBacSi.Where(i => i.mabs != null && StaticHelper.convertToUnSign(i.mabs.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.tenbs != null && StaticHelper.convertToUnSign(i.tenbs.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(mabs) && String.IsNullOrEmpty(term))
            {
                var data = listBacSi.Where(i => i.mabs.Contains(mabs) && i.mabs != null).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = listBacSi;
                return Json(new { data });
            }
            
        }

        public JsonResult GetDieuDuong(string madd = null, string term = null)
        {
            List<DieuDuongModel> listDieuDuong = new List<DieuDuongModel>();
            for (var i = 0; i < 9; i++)
            {
                var item2 = new DieuDuongModel()
                {
                    madd = $"00{i}",
                    tendd = $"Tên điều dưỡng {i}",
                };
                listDieuDuong.Add(item2);
            }
            if (!String.IsNullOrEmpty(term))
            {

                var data = listDieuDuong.Where(i => i.madd != null && StaticHelper.convertToUnSign(i.madd.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.tendd != null && StaticHelper.convertToUnSign(i.tendd.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(madd) && String.IsNullOrEmpty(term))
            {
                var data = listDieuDuong.Where(i => i.madd != null && i.madd.Contains(madd)).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = listDieuDuong;
                return Json(new { data });
            }
        }

        public JsonResult GetICD(string maICD = null, string term = null)
        {
            List<ChanDoanModel> listICD = new List<ChanDoanModel>();
            for (var i = 0; i < 9; i++)
            {
                var item2 = new ChanDoanModel()
                {
                    maICD = $"00{i}",
                    tenICD = $"Chẩn đoán bệnh gì đó {i}",
                };
                listICD.Add(item2);
            }
            if (!String.IsNullOrEmpty(term))
            {

                var data = listICD.Where(i => i.maICD != null && StaticHelper.convertToUnSign(i.maICD.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.tenICD != null && StaticHelper.convertToUnSign(i.tenICD.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(maICD) && String.IsNullOrEmpty(term))
            {
                var data = listICD.Where(i => i.maICD != null && i.maICD.Contains(maICD)).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = listICD;
                return Json(new { data });
            }
        }
    }
}
