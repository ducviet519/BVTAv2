﻿using DataBVTA.Models.Entities;
using DataBVTA.Services;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace AppBVTA.Controllers
{
    public class DanhMucController : Controller
    {
        private readonly IUnitOfWork _services;
        public DanhMucController(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<JsonResult> GetBacSi(string mabs = null, string term = null)
        {
            var listBacSi = await _services.DanhMuc.Get_DM_BacSi();
            if (!String.IsNullOrEmpty(term)){

                var data = listBacSi.Where(i => i.ma != null && StaticHelper.convertToUnSign(i.ma.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.hoten != null && StaticHelper.convertToUnSign(i.hoten.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(mabs) && String.IsNullOrEmpty(term))
            {
                var data = listBacSi.Where(i => i.ma.Contains(mabs) && i.ma != null).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = listBacSi;
                return Json(new { data });
            }
            
        }

        public async Task<JsonResult> GetDieuDuong(string madd = null, string term = null)
        {
            List<DieuDuongModel> listDieuDuong = await _services.DanhMuc.Get_DM_DieuDuong();
            if (!String.IsNullOrEmpty(term))
            {

                var data = listDieuDuong.Where(i => i.ma != null && StaticHelper.convertToUnSign(i.ma.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.hoten != null && StaticHelper.convertToUnSign(i.hoten.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(madd) && String.IsNullOrEmpty(term))
            {
                var data = listDieuDuong.Where(i => i.ma != null && i.ma.Contains(madd)).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = listDieuDuong;
                return Json(new { data });
            }
        }

        public async Task<JsonResult> Get_ICD_ChanDoan(string icd10 = null, string term = null)
        {
            List<ChanDoanModel> list = await _services.DanhMuc.Get_DM_ICD10();
            if (!String.IsNullOrEmpty(term))
            {

                var data = list.Where(i => i.CICD10 != null && StaticHelper.convertToUnSign(i.CICD10.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0 || i.VVIET != null && StaticHelper.convertToUnSign(i.VVIET.ToLower()).IndexOf(StaticHelper.convertToUnSign(term.ToLower())) >= 0).ToList();
                return Json(new { data });
            }
            if (!String.IsNullOrEmpty(icd10) && String.IsNullOrEmpty(term))
            {
                var data = list.Where(i => i.CICD10 != null && i.CICD10.Contains(icd10)).FirstOrDefault();
                return Json(new { data });
            }
            else
            {
                var data = list;
                return Json(new { data });
            }
        }
    }
}
