using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapSuaNguyenLieu : KetNoiDatabase
    {
        public bool SuaNguyenLieu(KhoSanPhamDTO khoSanPham)
        {
            bool info = SuaNguyenLieuDTO(khoSanPham);
            return info;
        }
    }
}
