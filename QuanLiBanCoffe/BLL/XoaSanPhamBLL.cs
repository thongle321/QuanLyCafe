using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class XoaSanPhamBLL
    {
        TruyCapXoaSanPham truyCapXoaSanPham = new TruyCapXoaSanPham();
        public bool XoaSanPham(int MaSP)
        {
            if(MaSP == 0)
            {
                return false;
            }
            return truyCapXoaSanPham.XoaSanPham(MaSP);
        }
    }
}
