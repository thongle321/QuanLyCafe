using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemKhachHang : KetNoiDatabase
    {
        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            bool info = ThemKhachHangDTO(khachHang);
            return info;
        }
    }
}
