using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DAL;
namespace QuanLiBanCoffe.BLL
{
    internal class HienThiNhanVienBLL
    {
        TruyCapHienThiNhanVien truycaphienthinhanvien = new TruyCapHienThiNhanVien();
        public DataTable HienThiNhanVien()
        {
            return truycaphienthinhanvien.HienThiNhanVien();
        }
    }
}
