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
        public ILichSuKhamBenhReponsitory LichSuKhamBenh { get; }
        public IThongTinHanhChinhRepository ThongTinHanhChinh { get; }
        public IPhieuKhamBenhRepository PhieuKhamBenh { get; }
        public IDanhMucRepository DanhMuc { get; }

        public UnitOfWork
            (
                ILoginRepository loginRepository,
                IProductRepository productRepository,
                IChoKhamRepository choKhamRepository,
                ILichSuKhamBenhReponsitory lichSuKhamBenhReponsitory,
                IThongTinHanhChinhRepository thongTinHanhChinhRepository,
                IPhieuKhamBenhRepository phieuKhamBenhRepository,
                IDanhMucRepository danhMucRepository
            )
        {
            Permission = loginRepository;
            Products = productRepository;
            DanhSachChoKham = choKhamRepository;
            LichSuKhamBenh = lichSuKhamBenhReponsitory;
            ThongTinHanhChinh = thongTinHanhChinhRepository;
            PhieuKhamBenh = phieuKhamBenhRepository;
            DanhMuc = danhMucRepository;
        }
        
    }
}
