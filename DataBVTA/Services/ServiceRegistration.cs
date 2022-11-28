using DataBVTA.Services.Interfaces;
using DataBVTA.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IChoKhamRepository, ChoKhamRepository>();
            services.AddTransient<ILichSuKhamBenhReponsitory, LichSuKhamBenhReponsitory>();
            services.AddTransient<IPhieuKhamBenhRepository, PhieuKhamBenhRepository>();
            services.AddTransient<IThongTinHanhChinhRepository, ThongTinHanhChinhRepository>();
            services.AddTransient<IDanhMucRepository, DanhMucRepository>();
            services.AddTransient<IUploadFile, UploadFile>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
