using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiSanPhamTheoLoai : KetNoiDatabase
    {
        public DataTable HienThiSanPhamTheoLoai(int MaLoai)
        {
            DataTable info = HienThiSanPhamTheoLoaiDTO(MaLoai);
            return info;
        }
    }
}
