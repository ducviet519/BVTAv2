using DataBVTA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Services.Interfaces
{
    public interface IPhongKhamRepository
    {
        public Task<List<PhongKhamModel>> DanhSachPhongKhamAsync();
    }
}
