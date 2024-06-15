using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemHoaDonChiTietHoaDon : KetNoiDatabase
    {
        public bool ThemHoaDonChiTietHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDon)
        {
            bool info = ThemHoaDonChiTietHoaDonDTO(hoaDon, chiTietHoaDon);
            return info;

        }

    }
}
