using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThemSanPhamBLL
    {
        TruyCapThemSanPham truyCapThemSanPham = new TruyCapThemSanPham();
        public bool ThemSanPham(SanPhamDTO SanPham, List<NguyenLieuDTO> nguyenLieu)
        {
            if (nguyenLieu == null)
            {
                return false;
            }    
            return truyCapThemSanPham.ThemSanPham(SanPham, nguyenLieu);
        }

    }
}
