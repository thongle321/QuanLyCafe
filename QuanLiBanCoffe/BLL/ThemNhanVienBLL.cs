using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DTO;
using QuanLiBanCoffe.DAL;
namespace QuanLiBanCoffe.BLL
{
    internal class ThemNhanVienBLL
    {
        TruyCapThemNhanVien truycapthemnhanvien = new TruyCapThemNhanVien();
        public bool ThemNhanVien(NhanVienDTO nhanvien)
        {
            if(nhanvien.TenNguoiDung == "" || nhanvien.MatKhau == "" || nhanvien.TenNV == "" || nhanvien.GioiTinh == "" || nhanvien.SDT == "")
            {
                return false;
            }
            return truycapthemnhanvien.ThemNhanVien(nhanvien);
        }
    }
}
