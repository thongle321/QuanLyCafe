using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoffe.GUI
{
    public partial class ThongKe : UserControl
    {
        ThongKeTheoNgayBLL thongKeTheoNgayBLL = new ThongKeTheoNgayBLL();
        ThongKeTheoThangBLL thongKeTheoThangBLL = new ThongKeTheoThangBLL();
        ThongKeTheoNamBLL thongKeTheoNamBLL = new ThongKeTheoNamBLL();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại thống kê: Ngày, Tháng, Năm.");
                return;
            }
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Ngày":
                    int ngay = DateTime.Now.Day;
                    DataTable da = thongKeTheoNgayBLL.ThongKeTheoNgay(ngay);
                    if(da.Rows.Count > 0)
                    {
                        btn_TongHoaDon.Text = da.Rows[0]["TongHoaDon"].ToString();
                        btn_TongSanPham.Text = da.Rows[0]["TongSanPham"].ToString();
                        btn_TongTien.Text = da.Rows[0]["TongTien"].ToString();
                    }
                    btn_TongHoaDon.Text = "0";
                    btn_TongSanPham.Text = "0";
                    btn_TongTien.Text = "0";
                    break;
                case "Tháng":
                    int thang = DateTime.Now.Month;
                    DataTable da2 = thongKeTheoThangBLL.ThongKeTheoThang(thang);
                    if(da2.Rows.Count > 0)
                    {
                        btn_TongHoaDon.Text = da2.Rows[0]["TongHoaDon"].ToString();
                        btn_TongSanPham.Text = da2.Rows[0]["TongSanPham"].ToString();
                        btn_TongTien.Text = da2.Rows[0]["TongTien"].ToString();
                    }
                    else
                    {
                        btn_TongHoaDon.Text = "0";
                        btn_TongSanPham.Text = "0";
                        btn_TongTien.Text = "0";
                    }    
                    break;
                case "Năm":
                    int nam = DateTime.Now.Year;
                    DataTable da3 = thongKeTheoNamBLL.ThongKeTheoNam(nam);
                    if(da3.Rows.Count > 0)
                    {
                        btn_TongHoaDon.Text = da3.Rows[0]["TongHoaDon"].ToString();
                        btn_TongSanPham.Text = da3.Rows[0]["TongSanPham"].ToString();
                        btn_TongTien.Text = da3.Rows[0]["TongTien"].ToString();
                    }
                    else
                    {
                        btn_TongHoaDon.Text = "0";
                        btn_TongSanPham.Text = "0";
                        btn_TongTien.Text = "0";
                    }   
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
