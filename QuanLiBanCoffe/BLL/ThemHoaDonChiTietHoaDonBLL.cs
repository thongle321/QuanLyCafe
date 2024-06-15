using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThemHoaDonChiTietHoaDonBLL
    {
        TruyCapThemHoaDonChiTietHoaDon truyCapThemHoaDonChiTietHoaDon = new TruyCapThemHoaDonChiTietHoaDon();
        public bool ThemHoaDonChiTietHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDon)
        {
            return truyCapThemHoaDonChiTietHoaDon.ThemHoaDonChiTietHoaDon(hoaDon, chiTietHoaDon);
        }

    }
}
