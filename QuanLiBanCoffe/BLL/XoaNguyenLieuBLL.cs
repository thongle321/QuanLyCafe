using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class XoaNguyenLieuBLL
    {
        TruyCapXoaNguyenLieu truyCapXoaNguyenLieu = new TruyCapXoaNguyenLieu();
        public bool XoaNguyenLieu(int MaNL)
        {
            if (MaNL == 0)
            {
                return false;
            }
            return truyCapXoaNguyenLieu.XoaNguyenLieu(MaNL);
        }
    }
}
