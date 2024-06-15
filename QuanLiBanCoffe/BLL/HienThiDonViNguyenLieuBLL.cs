using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiDonViNguyenLieuBLL
    {
        TruyCapHienThiDonViNguyenLieu truyCapHienThiDonViNguyenLieu = new TruyCapHienThiDonViNguyenLieu();
        public string HienThiDonViTheoNguyenLieu(int MaNL)
        {
            if (MaNL == 0)
            {
                return null;
            }
            return truyCapHienThiDonViNguyenLieu.HienThiDonViTheoNguyenLieu(MaNL);
        }
    }
}
