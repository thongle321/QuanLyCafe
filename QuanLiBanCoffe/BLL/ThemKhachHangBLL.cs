using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThemKhachHangBLL
    {
        TruyCapThemKhachHang truyCapThemKhachHang = new TruyCapThemKhachHang();
        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            return truyCapThemKhachHang.ThemKhachHang(khachHang);
        }
    }
}
