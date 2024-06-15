using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThemNhanVien : KetNoiDatabase
    {
        public bool ThemNhanVien(NhanVienDTO nhanvien)
        {
            bool info = ThemNhanVienDTO(nhanvien);
            return info;
        }
    }
}
