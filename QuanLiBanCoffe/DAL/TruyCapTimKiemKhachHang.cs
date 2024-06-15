using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapTimKiemKhachHang : KetNoiDatabase
    {
        public DataTable TimKiemKhachHang(string TenKH)
        {
            DataTable info = TimKiemKhachHangDTO(TenKH);
            return info;
        }

    }
}
