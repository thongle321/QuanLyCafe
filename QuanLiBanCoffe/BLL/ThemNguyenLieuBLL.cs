using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThemNguyenLieuBLL
    {
        TruyCapThemNguyenLieu truycapthemnguyenlieu = new TruyCapThemNguyenLieu();
        public bool ThemNguyenLieu(KhoSanPhamDTO khoSanPham)
        {
            if(khoSanPham.TenNL == "" || khoSanPham.SoLuong <= 0 || khoSanPham.DonVi == "")
            {
                return false;
            }    
            return truycapthemnguyenlieu.ThemNguyenLieu(khoSanPham);
        }
    }
}
