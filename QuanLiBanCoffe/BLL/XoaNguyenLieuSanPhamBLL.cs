using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class XoaNguyenLieuSanPhamBLL
    {
        TruyCapXoaNguyenLieuSanPham truyCapXoaNguyenLieuSanPham = new TruyCapXoaNguyenLieuSanPham();
        public bool XoaNguyenLieuSanPham(int MaSP, int MaNL)
        {
            if(MaSP == 0 && MaNL == 0)
            {
                return false;
            }    
            return truyCapXoaNguyenLieuSanPham.XoaNguyenLieuSanPham(MaSP, MaNL);
        }
    }
}
