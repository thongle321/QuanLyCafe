using QuanLiBanCoffe.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoffe
{
    public partial class GiaoDienNhanVien : Form
    {
        public GiaoDienNhanVien()
        {
            InitializeComponent();
        }

        private void GiaoDienNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
            Hide();
            quanLyKhachHang.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            GiaoDienBanHang giaoDienBanHang = new GiaoDienBanHang();
            Hide();
            giaoDienBanHang.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            Hide();
            dangNhap.Show();
        }
    }
}
