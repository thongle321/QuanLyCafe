using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiKhachHangBLL
    {
        TruyCapHienThiKhachHang truyCapHienThiKhachHang = new TruyCapHienThiKhachHang();
        public DataTable HienThiKhachHang()
        {
            return truyCapHienThiKhachHang.HienThiKhachHang();
        }
    }
}
