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

namespace QuanLiBanCoffe.GUI
{
 
    public partial class QuanLyKhachHang : Form
    {
        ThemKhachHangBLL themKhachHangBLL = new ThemKhachHangBLL();
        HienThiKhachHangBLL hienThiKhachHangBLL = new HienThiKhachHangBLL();
        TimKiemKhachHangBLL timKiemKhachHangBLL = new TimKiemKhachHangBLL();
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {
            grid_KhachHang.DataSource = hienThiKhachHangBLL.HienThiKhachHang();
            btn_Luu.Enabled = false;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Them.Enabled = false;
            btn_Thoat.Enabled = false;
            btn_Luu.Enabled = true;
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadForm();
            dtp_NgayTao.CustomFormat = "'Ngày' dd 'tháng' MM 'năm' yyyy";
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string TenKH = txt_TimKiem.Text;
            grid_KhachHang.DataSource = timKiemKhachHangBLL.TimKiemKhachHang(TenKH);
        }

        private void btn_Moi_Click(object sender, EventArgs e)
        {
            txt_TenKH.Clear();
            txt_TenKH.Clear();
            txt_DiaChi.Clear();
            txt_SDT.Clear();
            dtp_NgayTao.Value = DateTime.Now;
            btn_Them.Enabled = true;
            btn_Thoat.Enabled = true;
            btn_Luu.Enabled = false;
        }

        private void QuanLyKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_Thoat_Click_1(object sender, EventArgs e)
        {
            GiaoDienNhanVien giaoDienNhanVien = new GiaoDienNhanVien();
            Hide();
            giaoDienNhanVien.Show();
        }
        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if(txt_TenKH.Text == "" && txt_DiaChi.Text == "" && txt_SDT.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KhachHangDTO khachHangDTO = new KhachHangDTO();
            khachHangDTO.TenKH = txt_TenKH.Text;
            khachHangDTO.DiaChi = txt_DiaChi.Text;
            khachHangDTO.SĐT = txt_SDT.Text;
            khachHangDTO.NgayTao = dtp_NgayTao.Value;
            bool ThemKhachHang = themKhachHangBLL.ThemKhachHang(khachHangDTO);
            if (ThemKhachHang)
            {
                MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadForm();
                btn_Them.Enabled = true;
                btn_Thoat.Enabled = true;
                btn_Luu.Enabled = false;
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}
