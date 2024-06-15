using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThongKeTheoNgay : KetNoiDatabase
    {
        public DataTable ThongKeTheoNgay(int ngay)
        {
            DataTable info = ThongKeTheoNgayDTO(ngay);
            return info;
        }

    }
}
