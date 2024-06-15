using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class TimKiemNguyenLieuBLL
    {
        TruyCapTimKiemNguyenLieu truyCapTimKiemNguyenLieu = new TruyCapTimKiemNguyenLieu();
        public DataTable TimKiemNguyenLieu(string TenNL)
        {
            return truyCapTimKiemNguyenLieu.TimKiemNguyenLieu(TenNL);
        }
    }
}
