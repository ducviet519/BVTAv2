using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBVTA.Services;
using DataBVTA.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace AppBVTA.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        public IActionResult PhieuKhamBenh()
        {
            ExportReport data = new ExportReport();
            data.BarCode = StaticHelper.GenBarCode("12345678");
            data.TenPhieuIn = "PhieuKhamBenh";

            return View(data);
            //return new ViewAsPdf("PhieuKhamBenh", data)
            //{
            //    //FileName = $"{data.TenPhieuIn}.pdf", //User for click download
            //    PageSize = Size.A4,
            //    PageOrientation = Orientation.Portrait,
            //    IsJavaScriptDisabled = true,
            //};

        }

    }
}
