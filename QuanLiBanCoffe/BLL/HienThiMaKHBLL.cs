using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class HienThiMaKHBLL
    {
        TruyCapHienThiMaKH truyCapHienThiMaKH = new TruyCapHienThiMaKH();
        public DataTable HienThiMaKH()
        {
            return truyCapHienThiMaKH.HienThiMaKH();
        }
    }
}
