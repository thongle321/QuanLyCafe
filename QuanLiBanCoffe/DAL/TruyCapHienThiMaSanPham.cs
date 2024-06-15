using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiMaSanPham : KetNoiDatabase
    {
        public DataTable HienThiMaSanPham()
        {
            DataTable info = HienThiMaSanPhamDTO();
            return info;
        }
    }
}
