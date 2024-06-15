using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DTO;
using QuanLiBanCoffe.DAL;
namespace QuanLiBanCoffe.BLL
{
    internal class TaiKhoanBLL
    {
        TruyCapTaiKhoan truycaptaikhoan = new TruyCapTaiKhoan();
        public int KiemTra(TaiKhoanDTO taikhoan)
        {
            if (taikhoan.TenNguoiDung == "" && taikhoan.MatKhau == "")
            {
                return 3;
            }
            if (taikhoan.TenNguoiDung == "")
            {
                return 1;
            }
            if (taikhoan.MatKhau == "")
            {
                return 2;
            }
            TaiKhoanDTO info = truycaptaikhoan.KiemTra(taikhoan);
            if (info == null)
            {
                return 4;
            }
            if (info.Loai == 1)
            {
                return 5;
            }
            else if (info.Loai == 2)
            {
                return 6;
            }
            return 0;
        } 
    }
}
