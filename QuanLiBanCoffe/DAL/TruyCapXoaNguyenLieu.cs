using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapXoaNguyenLieu : KetNoiDatabase
    {
        public bool XoaNguyenLieu(int MaNL)
        {
            bool info = XoaNguyenLieuDTO(MaNL);
            return info;
        }
    }
}
