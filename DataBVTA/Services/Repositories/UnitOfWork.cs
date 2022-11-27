using DataBVTA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILoginRepository Permission { get; }
        public IProductRepository Products { get; }
        public IChoKhamRepository DanhSachChoKham { get; }
        public IPhongKhamRepository PhongKham { get; }
        public ILichSuKhamBenhReponsitory LichSuKhamBenh { get; }
        public IThongTinHanhChinhRepository ThongTinHanhChinh { get; }
        public IPhieuKhamBenhRepository PhieuKhamBenh { get; }

        public UnitOfWork
            (
                ILoginRepository loginRepository,
                IProductRepository productRepository,
                IChoKhamRepository choKhamRepository,
                IPhongKhamRepository phongKhamRepository,
                ILichSuKhamBenhReponsitory lichSuKhamBenhReponsitory,
                IThongTinHanhChinhRepository thongTinHanhChinhRepository,
                IPhieuKhamBenhRepository phieuKhamBenhRepository
            )
        {
            Permission = loginRepository;
            Products = productRepository;
            DanhSachChoKham = choKhamRepository;
            PhongKham = phongKhamRepository;
            LichSuKhamBenh = lichSuKhamBenhReponsitory;
            ThongTinHanhChinh = thongTinHanhChinhRepository;
            PhieuKhamBenh = phieuKhamBenhRepository;
        }
        
    }
}
