using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapSuaSanPham : KetNoiDatabase
    {
        public bool SuaSanPham(SanPhamDTO sanPham)
        {
            bool info = SuaSanPhamDTO(sanPham);
            return info;
        }

    }
}
