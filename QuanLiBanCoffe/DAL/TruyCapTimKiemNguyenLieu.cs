using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapTimKiemNguyenLieu : KetNoiDatabase
    {
        public DataTable TimKiemNguyenLieu(string TenNL)
        {
            DataTable info = TimKiemNguyenLieuDTO(TenNL);
            return info;
        }
    }
}
