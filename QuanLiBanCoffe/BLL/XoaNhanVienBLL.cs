using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.BLL
{
    internal class XoaNhanVienBLL
    {
        TruyCapXoaNhanVien truycapxoanhanvien = new TruyCapXoaNhanVien();
        public bool XoaNhanVien(int MaNV)
        {
            if (MaNV == 0 )
            {
                return false;
            }    
            return truycapxoanhanvien.XoaNhanVien(MaNV);
        }
    }
}
