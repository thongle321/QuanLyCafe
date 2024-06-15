using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThongKeTheoThang : KetNoiDatabase
    {
        public DataTable ThongKeTheoThang(int thang)
        {
            DataTable info = ThongKeTheoThangDTO(thang);
            return info;
        }

    }
}
