using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThemNguyenLieuSanPhamBLL
    {
        TruyCapThemNguyenLieuSanPham truyCapThemNguyenLieuSanPham = new TruyCapThemNguyenLieuSanPham();
        public bool ThemNguyenLieuSanPham(NguyenLieuDTO nguyenLieu)
        {
            return truyCapThemNguyenLieuSanPham.ThemNguyenLieuSanPham(nguyenLieu);
        }
    }
}
