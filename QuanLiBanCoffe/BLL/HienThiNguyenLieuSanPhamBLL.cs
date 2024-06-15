using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiNguyenLieuSanPhamBLL
    {
        TruyCapHienThiNguyenLieuSanPham truyCapHienThiNguyenLieuSanPham = new TruyCapHienThiNguyenLieuSanPham();
        public DataTable HienThiNguyenLieuSanPham(int MaSP)
        {
            return truyCapHienThiNguyenLieuSanPham.HienThiNguyenLieuSanPham(MaSP);
        }
    }
}
