using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiThongTinTheoMaSP : KetNoiDatabase
    {
        public SanPhamDTO HienThiThongTinTheoMaSP(int MaSP)
        {
            SanPhamDTO info = HienThiThongTinTheoMaSPDTO(MaSP);
            return info;
        }
    }
}
