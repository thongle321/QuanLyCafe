using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.Framework.UI;
using QuanLiBanCoffe.DTO;
using QuanLiBanCoffe.BLL;
namespace QuanLiBanCoffe
{
    public partial class DangNhap : Form
    {
        TaiKhoanDTO taikhoan = new TaiKhoanDTO();
        public DangNhap()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_Login;
            txt_TenDangNhap.Focus();
        }

        private void pb_Close_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO taikhoan = new TaiKhoanDTO();
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
            taikhoan.TenNguoiDung = txt_TenDangNhap.Text;
            taikhoan.MatKhau = txt_MatKhau.Text;
            int getuser = taiKhoanBLL.KiemTra(taikhoan);
            switch (getuser)
            {
                case 1:
                    MessageBox.Show("Tài khoản không được trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Mật khẩu không được trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 5:
                    MessageBox.Show("Đăng nhập tài khoản admin thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaoDienQL gdql = new GiaoDienQL();
                    this.Hide();
                    gdql.Show();
                    break;
                case 6:
                    MessageBox.Show("Đăng nhập tài khoản nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiaoDienNhanVien gdnv = new GiaoDienNhanVien();
                    this.Hide();
                    gdnv.Show();
                    break;

            }
        }

        private void pb_Hide_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.PasswordChar == '\0')
            {
                pb_Show.BringToFront();
                txt_MatKhau.PasswordChar = '●';
            }


        }

        private void pb_Show_Click(object sender, EventArgs e)
        {
            if (txt_MatKhau.PasswordChar == '●')
            {
                pb_Hide.BringToFront();
                txt_MatKhau.PasswordChar = '\0';
            }

        }
        public bool KiTuDacBiet(string txt_TenDangNhap)
        {
            return txt_TenDangNhap.Any(ch => !char.IsLetterOrDigit(ch));
        }
        private void txt_TenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if(KiTuDacBiet(txt_TenDangNhap.Text))
            {
                lbl_TenDangNhapErr.Text = "Tên đăng nhập không hợp lệ";
            }    
            else
            {
                lbl_TenDangNhapErr.Text = "";
            }
        }

        private void txt_TenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txt_MatKhau.Focus();
            }    
        }

        private void txt_MatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }
    }
}
