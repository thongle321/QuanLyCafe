using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapSuaNhanVien : KetNoiDatabase
    {
        public bool SuaNhanVien(NhanVienDTO nhanvien)
        {
            bool info = SuaNhanVienDTO(nhanvien);
            return info;
        }
    }
}
