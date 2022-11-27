using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.ViewComponents
{
    //[ViewComponent(Name = "BieuDoVC")]
    public class BieuDoViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _services;
        public BieuDoViewComponent(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IViewComponentResult> InvokeAsync(string mabn)
        {
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            model.LichSuKhamBenh = await _services.LichSuKhamBenh.GetLichSuKhamBenh(mabn);
            model.ThongTinHanhChinh = (await _services.ThongTinHanhChinh.GetThongTinHanhChinh(mabn)).Where(i => i.mabn != null).FirstOrDefault();
            return View(model);
        }
    }
}
