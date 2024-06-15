using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.BLL
{
    internal class ThongKeTheoNgayBLL
    {
        TruyCapThongKeTheoNgay truyCapThongKeTheoNgay = new TruyCapThongKeTheoNgay();
        public DataTable ThongKeTheoNgay(int ngay)
        {
            return truyCapThongKeTheoNgay.ThongKeTheoNgay(ngay);
        }
    }
}
