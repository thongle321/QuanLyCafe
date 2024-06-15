using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemNguyenLieu : KetNoiDatabase
    {
        public bool ThemNguyenLieu(KhoSanPhamDTO KhoSanPham)
        {
            bool info = ThemNguyenLieuDTO(KhoSanPham);
            return info;
        }
    }
}
