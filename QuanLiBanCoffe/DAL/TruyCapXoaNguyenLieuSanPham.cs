using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapXoaNguyenLieuSanPham : KetNoiDatabase
    {
        public bool XoaNguyenLieuSanPham(int MaSP, int MaNL)
        {
            bool info = XoaNguyenLieuSanPhamDTO(MaSP, MaNL);
            return info;
        }
    }
}
