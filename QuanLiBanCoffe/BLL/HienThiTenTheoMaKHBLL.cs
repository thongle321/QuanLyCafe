using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiTenTheoMaKHBLL
    {
        TruyCapHienThiTenTheoMaKH truyCapHienThiTenTheoMaKH = new TruyCapHienThiTenTheoMaKH();
        public KhachHangDTO HienThiTenTheoMaKH(int MaKH)
        {
            if (MaKH == 0)
            {
                return null;
            }
            return truyCapHienThiTenTheoMaKH.HienThiTenTheoMaKH(MaKH);
        }
    }
}
