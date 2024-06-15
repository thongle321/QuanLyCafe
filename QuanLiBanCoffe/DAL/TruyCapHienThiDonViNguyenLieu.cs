using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiDonViNguyenLieu : KetNoiDatabase
    {
        public string HienThiDonViTheoNguyenLieu(int MaNL)
        {
            string info = HienThiDonViTheoNguyenLieuDTO(MaNL);
            return info;
        }

    }
}
