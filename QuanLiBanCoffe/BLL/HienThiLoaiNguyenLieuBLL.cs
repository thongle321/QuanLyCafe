using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiLoaiNguyenLieuBLL
    {
        TruyCapHienThiLoaiNguyenLieu truyCapHienThiLoaiNguyenLieu = new TruyCapHienThiLoaiNguyenLieu();
        public DataTable HienThiLoaiNguyenLieu()
        {
            return truyCapHienThiLoaiNguyenLieu.HienThiLoaiNguyenLieu();
        }
    }
}
