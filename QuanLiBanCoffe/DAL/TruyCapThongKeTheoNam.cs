using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DAL
{
    internal class TruyCapThongKeTheoNam : KetNoiDatabase
    {
        public DataTable ThongKeTheoNam(int nam)
        {
            DataTable info = ThongKeTheoNamDTO(nam);
            return info;
        }
    }
}
