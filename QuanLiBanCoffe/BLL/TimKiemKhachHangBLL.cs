using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class TimKiemKhachHangBLL
    {
        TruyCapTimKiemKhachHang truyCapTimKiemKhachHang = new TruyCapTimKiemKhachHang();
        public DataTable TimKiemKhachHang(string TenKH)
        {
            if(TenKH == null)
            {
                return null;
            }    
            return truyCapTimKiemKhachHang.TimKiemKhachHang(TenKH);
        }
    }
}
