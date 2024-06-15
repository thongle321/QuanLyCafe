using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiLoaiSanPham : KetNoiDatabase
    {
        public DataTable HienThiLoaiSanPham()
        {
            DataTable info = HienThiLoaiSanPhamDTO();
            return info;
        }

    }
}
