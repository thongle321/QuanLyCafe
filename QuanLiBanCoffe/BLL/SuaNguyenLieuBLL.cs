using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class SuaNguyenLieuBLL
    {
        TruyCapSuaNguyenLieu truyCapSuaNguyenLieu = new TruyCapSuaNguyenLieu();
        public bool SuaNguyenLieu(KhoSanPhamDTO khoSanPham)
        {
            if(khoSanPham.TenNL == "" || khoSanPham.SoLuong <= 0 || khoSanPham.DonVi == "")
            {
                return false;
            } 
            return truyCapSuaNguyenLieu.SuaNguyenLieu(khoSanPham);
        }
    }
}
