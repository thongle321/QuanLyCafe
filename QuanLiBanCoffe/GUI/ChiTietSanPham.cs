using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoffe.GUI
{
    public partial class ChiTietSanPham : Form
    {
        public int MaSP;

        public void LayMaSP(int MaSP)
        {
            this.MaSP = MaSP;
        }

        public ChiTietSanPham()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
