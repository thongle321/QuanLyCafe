using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiNguyenLieu : KetNoiDatabase
    {
        public DataTable HienThiNguyenLieu()
        {
            DataTable info = HienThiNguyenLieuDTO();
            return info;
        }
    }
}
