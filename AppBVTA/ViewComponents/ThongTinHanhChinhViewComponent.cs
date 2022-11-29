using DataBVTA.Models.Entities;
using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;

namespace AppBVTA.ViewComponents
{
    //[ViewComponent(Name = "ThongTinHanhChinhVC")]
    public class ThongTinHanhChinhViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _services;
        public ThongTinHanhChinhViewComponent(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IViewComponentResult> InvokeAsync(string mabn, string mavaovien, string maql)
        {
            if (String.IsNullOrEmpty(mabn)) { mabn = "16000569"; mavaovien = "190705081307149525"; maql = "190705082253138551"; }
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.mabn = mabn;
            model.mavaovien = mavaovien;
            model.maql = maql;
            model.LichSuKhamBenh = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn);
            model.ThongTinHanhChinh = await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn, mavaovien, maql);
            return View(model);
        }        
    }
}
