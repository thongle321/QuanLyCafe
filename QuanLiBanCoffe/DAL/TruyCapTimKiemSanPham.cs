using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapTimKiemSanPham : KetNoiDatabase
    {
        public DataTable TimKiemSanPham(string Ten)
        {
            DataTable info = TimKiemSanPhamDTO(Ten);
            return info;
        }

    }
}
