using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiNhanVien : KetNoiDatabase
    {
        public DataTable HienThiNhanVien()
        {
            DataTable info = HienThiNhanVienDTO();
            return info;
        }

    }
}
