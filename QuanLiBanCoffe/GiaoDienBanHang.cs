using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DTO;
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
    public partial class GiaoDienBanHang : Form
    {
        HienThiMaSanPhamBLL hienThiMaSanPhamBLL = new HienThiMaSanPhamBLL();
        HienThiThongTinTheoMaSPBLL hienThiThongTinTheoMaSPBLL = new HienThiThongTinTheoMaSPBLL();
        public GiaoDienBanHang()
        {
            InitializeComponent();
        }

        private void GiaoDienNhanVien_Load(object sender, EventArgs e)
        {
            txt_ThanhTien.Text = "0 VNĐ";
        }

        private void cbb_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GiaoDienBanHang_Load(object sender, EventArgs e)
        {
            cbb_MaSP.DataSource = hienThiMaSanPhamBLL.HienThiMaSanPham();
            cbb_MaSP.ValueMember = "MaSP";
        }

        private void cbb_MaSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbb_MaSP.SelectedIndex != -1)
            {
                DataRowView drv = (DataRowView)cbb_MaSP.SelectedItem;
                if (drv != null)
                {
                    int MaSP = (int)drv["MaSP"];
                    SanPhamDTO sanPhamDTO = hienThiThongTinTheoMaSPBLL.HienThiThongTinTheoMaSP(MaSP);
                    txt_Ten.Text = sanPhamDTO.Ten;
                    txt_Gia.Text = sanPhamDTO.Gia.ToString();
                }
            }
        }

        private void nud_SoLuong_ValueChanged(object sender, EventArgs e)
        {
            int SoLuong = int.Parse(nud_SoLuong.Value.ToString());
            int Gia = int.Parse(txt_Gia.Text);
            txt_TongGia.Text = (SoLuong * Gia).ToString();
        }
        int n, TongGia = 0;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            n = grid_SanPham.Rows.Add();
            grid_SanPham.Rows[n].Cells[0].Value = cbb_MaSP.SelectedValue;
            grid_SanPham.Rows[n].Cells[1].Value = txt_Ten.Text;
            grid_SanPham.Rows[n].Cells[2].Value = nud_SoLuong.Value;
            grid_SanPham.Rows[n].Cells[3].Value = txt_Gia.Text;
            grid_SanPham.Rows[n].Cells[4].Value = txt_TongGia.Text;
            TongGia += int.Parse(txt_TongGia.Text);
            txt_ThanhTien.Text = TongGia + " VNĐ";
        }
    }
}
