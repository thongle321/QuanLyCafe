using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class SuaSanPhamBLL
    {
        TruyCapSuaSanPham truyCapSuaSanPham = new TruyCapSuaSanPham();
        public bool SuaSanPham(SanPhamDTO sanPham)
        {
            return truyCapSuaSanPham.SuaSanPham(sanPham);
        }

    }
}
