using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiSanPhamTheoLoaiBLL
    {
        TruyCapHienThiSanPhamTheoLoai truyCapHienThiSanPhamTheoLoai = new TruyCapHienThiSanPhamTheoLoai();
        public DataTable HienThiSanPhamTheoLoai(int MaLoai)
        {
            return truyCapHienThiSanPhamTheoLoai.HienThiSanPhamTheoLoai(MaLoai);
        }
    }
}
