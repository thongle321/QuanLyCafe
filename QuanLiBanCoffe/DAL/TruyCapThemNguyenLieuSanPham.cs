using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemNguyenLieuSanPham : KetNoiDatabase
    {
        public bool ThemNguyenLieuSanPham(NguyenLieuDTO nguyenLieu)
        {
            bool info = ThemNguyenLieuSanPhamDTO(nguyenLieu);
            return info;
        }
    }
}
