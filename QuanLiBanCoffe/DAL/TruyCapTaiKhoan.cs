using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapTaiKhoan:KetNoiDatabase
    {
        public TaiKhoanDTO KiemTra(TaiKhoanDTO taikhoan)
        {
            TaiKhoanDTO info = KiemTraDTO(taikhoan);
            return info;
        }
    }
}
