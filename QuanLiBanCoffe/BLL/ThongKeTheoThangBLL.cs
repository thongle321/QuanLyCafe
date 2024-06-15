using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThongKeTheoThangBLL
    {
        TruyCapThongKeTheoThang truyCapThongKeTheoThang = new TruyCapThongKeTheoThang();
        public DataTable ThongKeTheoThang(int thang)
        {
            if(thang == 0)
            {
                return null;
            }    
            return truyCapThongKeTheoThang.ThongKeTheoThang(thang);
        }

    }
}
