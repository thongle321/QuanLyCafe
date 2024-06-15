using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiNguyenLieuSanPham : KetNoiDatabase
    {
        public DataTable HienThiNguyenLieuSanPham(int MaSP)
        {
            DataTable info = HienThiNguyenLieuSanPhamDTO(MaSP);
            return info;
        }
    }
}
