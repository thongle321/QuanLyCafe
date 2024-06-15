using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DAL;
namespace QuanLiBanCoffe.BLL
{
    internal class SuaNhanVienBLL
    {
        TruyCapSuaNhanVien truycapsuanhanvien = new TruyCapSuaNhanVien();
        public bool SuaNhanVien(NhanVienDTO nhanvien)
        {
            if (nhanvien.TenNguoiDung == "" || nhanvien.MatKhau == "" || nhanvien.TenNV == "" || nhanvien.GioiTinh == "" || nhanvien.SDT == "")
            {
                return false;
            }
            return truycapsuanhanvien.SuaNhanVien(nhanvien);
        }
    }
}
