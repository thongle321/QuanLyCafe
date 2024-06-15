using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiTenTheoMaKH : KetNoiDatabase
    {
        public KhachHangDTO HienThiTenTheoMaKH(int MaKH)
        {
            KhachHangDTO info = HienThiTenTheoMaKHDTO(MaKH);
            return info;
        }

    }
}
