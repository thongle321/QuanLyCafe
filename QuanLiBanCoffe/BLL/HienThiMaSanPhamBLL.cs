using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{ 
    internal class HienThiMaSanPhamBLL
    {
        TruyCapHienThiMaSanPham truyCapHienThiMaSanPham = new TruyCapHienThiMaSanPham();
        public DataTable HienThiMaSanPham()
        {
            return truyCapHienThiMaSanPham.HienThiMaSanPham();
        }
    }
}
