using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThongKeTheoNamBLL
    {
        TruyCapThongKeTheoNam truyCapThongKeTheoNam = new TruyCapThongKeTheoNam();
        public DataTable ThongKeTheoNam(int nam)
        {
            if(nam == 0)
            {
                return null;
            }
            return truyCapThongKeTheoNam.ThongKeTheoNam(nam);
        }
    }
}
