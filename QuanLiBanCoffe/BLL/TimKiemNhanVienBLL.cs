using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.BLL
{
    internal class TimKiemNhanVienBLL
    {
        TruyCapTimKiemNhanVien truyCapTimKiemNhanVien = new TruyCapTimKiemNhanVien();
        public DataTable TimKiemNhanVien(string TenNV)
        {
            return truyCapTimKiemNhanVien.TimKiemNhanVien(TenNV);
        }
    }
}
