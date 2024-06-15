using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapTimKiemNhanVien : KetNoiDatabase
    {
        public DataTable TimKiemNhanVien(string TenNV)
        {
            DataTable info = TimKiemNhanVienDTO(TenNV);
            return info;
        }
    }
}
