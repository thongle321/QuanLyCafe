using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapHienThiMaKH : KetNoiDatabase
    {
        public DataTable HienThiMaKH()
        {
            DataTable info = HienThiMaKHDTO();
            return info;
        }
    }
}
