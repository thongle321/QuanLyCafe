using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe
{
    public partial class QuanLyNhanVien : UserControl
    {
        HienThiNhanVienBLL hienThiNhanVienBLL = new HienThiNhanVienBLL();
        TimKiemNhanVienBLL timKiemNhanVienBLL = new TimKiemNhanVienBLL();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {
            grid_NhanVien.DataSource = hienThiNhanVienBLL.HienThiNhanVien();
            btn_Luu.Enabled = false;
        }
        public void LamMoi()
        {
            txt_DN.Clear();
            txt_MaNV.Clear();
            txt_MatKhau.Clear();
            txt_SDT.Clear();
            txt_Ten.Clear();
            cb_GioiTinh.Text = "Nam";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Luu.Enabled = false;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            LamMoi();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Them.Enabled = false;
            btn_Luu.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (txt_MaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên để sửa", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Ten.Text == "" || txt_DN.Text == "" || txt_MatKhau.Text == "" || txt_SDT.Text == "")
            {
                MessageBox.Show("Thông tin không hợp lệ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow row = grid_NhanVien.SelectedRows[0];
            int MaNV = int.Parse(row.Cells[0].Value.ToString());
            NhanVienDTO nhanvien = new NhanVienDTO();
            SuaNhanVienBLL suaNhanVienBLL = new SuaNhanVienBLL();
            nhanvien.MaNV = MaNV;
            nhanvien.TenNguoiDung = txt_DN.Text;
            nhanvien.MatKhau = txt_MatKhau.Text;
            nhanvien.TenNV = txt_Ten.Text;
            nhanvien.GioiTinh = cb_GioiTinh.Text;
            nhanvien.SDT = txt_SDT.Text;
            if (suaNhanVienBLL.SuaNhanVien(nhanvien))
            {
                MessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadForm();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaNV.Text == "")
            {
                MessageBox.Show("Chọn nhân viên để xoá", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow row = grid_NhanVien.SelectedRows[0];
            int MaNV = int.Parse(row.Cells[0].Value.ToString());
            XoaNhanVienBLL xoaNhanVienBLL = new XoaNhanVienBLL();
            if (xoaNhanVienBLL.XoaNhanVien(MaNV))
            {
                MessageBox.Show("Xoá thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xoá thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadForm();
        }

        private void btn_Moi_Click_1(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            cb_GioiTinh.SelectedItem = "Nam";
            LoadForm();
        }
        
        private void txt_SDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void grid_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int MaNV;
                string TenNV, GioiTinh, SDT, TenDangNhap, MatKhau;
                MaNV = (int) grid_NhanVien.CurrentRow.Cells[0].Value;
                TenNV = grid_NhanVien.CurrentRow.Cells[1].Value.ToString();
                GioiTinh = grid_NhanVien.CurrentRow.Cells[2].Value.ToString();
                SDT = grid_NhanVien.CurrentRow.Cells[3].Value.ToString();
                TenDangNhap = grid_NhanVien.CurrentRow.Cells[4].Value.ToString();
                MatKhau = grid_NhanVien.CurrentRow.Cells[5].Value.ToString();
                txt_MaNV.Text = MaNV.ToString();
                txt_Ten.Text = TenNV;
                cb_GioiTinh.Text = GioiTinh;
                txt_SDT.Text = SDT;
                txt_DN.Text = TenDangNhap;
                txt_MatKhau.Text = MatKhau;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết:" + ex.Message);
            }
        }
        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string TenNV = txt_TimKiem.Text;
            grid_NhanVien.DataSource = timKiemNhanVienBLL.TimKiemNhanVien(TenNV);
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_Ten.Text == "" && txt_DN.Text == "" && txt_MatKhau.Text == "" && txt_SDT.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NhanVienDTO nhanvien = new NhanVienDTO();
            ThemNhanVienBLL themNhanVienBLL = new ThemNhanVienBLL();
            nhanvien.TenNguoiDung = txt_DN.Text;
            nhanvien.MatKhau = txt_MatKhau.Text;
            nhanvien.TenNV = txt_Ten.Text;
            nhanvien.GioiTinh = cb_GioiTinh.Text;
            nhanvien.SDT = txt_SDT.Text;
            bool ThemNhanVien = themNhanVienBLL.ThemNhanVien(nhanvien);
            if (ThemNhanVien)
            {
                MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadForm();
            LamMoi();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
        }
    }
}
