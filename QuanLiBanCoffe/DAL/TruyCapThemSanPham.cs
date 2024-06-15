using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemSanPham : KetNoiDatabase
    {
        public bool ThemSanPham(SanPhamDTO SanPham, List<NguyenLieuDTO> nguyenLieu)
        {
            bool info = ThemSanPhamDTO(SanPham, nguyenLieu);
            return info;
        }
    }
}
