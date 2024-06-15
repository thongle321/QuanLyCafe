using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiNguyenLieuBLL
    {
        TruyCapHienThiNguyenLieu truyCapHienThiNguyenLieu = new TruyCapHienThiNguyenLieu();
        public DataTable HienThiNguyenLieu()
        {
            return truyCapHienThiNguyenLieu.HienThiNguyenLieu();
        }
    }
}
