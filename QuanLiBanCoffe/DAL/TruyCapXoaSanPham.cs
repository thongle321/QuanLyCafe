using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapXoaSanPham : KetNoiDatabase
    {
        public bool XoaSanPham(int MaSP)
        {
            bool info = XoaSanPhamDTO(MaSP);
            return info;
        }
    }
}
