using DataBVTA.Models.ViewModels;
using DataBVTA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AppBVTA.ViewComponents
{
    //[ViewComponent(Name = "DanhMucVC")]
    public class DanhMucViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _services;
        public DanhMucViewComponent(IUnitOfWork services)
        {
            _services = services;
        }
        public async Task<IViewComponentResult> InvokeAsync(string mabn)
        {
            ThongTinBenhNhanVM model = new ThongTinBenhNhanVM();
            return View(model);
        }
    }
}
