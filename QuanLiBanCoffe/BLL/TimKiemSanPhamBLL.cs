using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class TimKiemSanPhamBLL
    {
        TruyCapTimKiemSanPham truyCapTimKiemSanPham = new TruyCapTimKiemSanPham();
        public DataTable TimKiemSanPham(string Ten)
        {
            if(Ten == null)
            {
                return null;
            }
            return truyCapTimKiemSanPham.TimKiemSanPham(Ten);
        }
    }
}
