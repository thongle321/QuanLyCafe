using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiLoaiNguyenLieu : KetNoiDatabase
    {
        public DataTable HienThiLoaiNguyenLieu()
        {
            DataTable info = HienThiLoaiNguyenLieuDTO();
            return info;
        }

    }
}
