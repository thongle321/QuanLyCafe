using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapXoaNhanVien : KetNoiDatabase
    {
        public bool XoaNhanVien(int MaNV)
        {
            bool info = XoaNhanVienDTO(MaNV);
            return info;
        }
    }
}
