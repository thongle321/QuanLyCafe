using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiThongTinTheoMaSPBLL
    {
        TruyCapHienThiThongTinTheoMaSP truyCapHienThiThongTinTheoMaSP = new TruyCapHienThiThongTinTheoMaSP();
        public SanPhamDTO HienThiThongTinTheoMaSP(int MaSP)
        {
            return truyCapHienThiThongTinTheoMaSP.HienThiThongTinTheoMaSP(MaSP);
        }
    }
}
