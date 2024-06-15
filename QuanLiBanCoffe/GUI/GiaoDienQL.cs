using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Windows.Forms;
using QuanLiBanCoffe.GUI;
namespace QuanLiBanCoffe
{
    public partial class GiaoDienQL : Form
    {
        public GiaoDienQL()
        {
            InitializeComponent();
        }

        private Form curentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (curentFormChild != null)
            {
                curentFormChild.Close();
            }
            curentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnl_Main.Controls.Add(curentFormChild);
            pnl_Main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnl_Main.Controls.Clear();
            pnl_Main.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            addUserControl(new QuanLyNhanVien());
            //OpenChildForm(new QuanLyNhanVien());
            lbl_text.Text = btn_NhanVien.Text;
        }
        private void btn_Kho_Click(object sender, EventArgs e)
        {
            addUserControl(new KhoSanPham());
            lbl_text.Text = "Kho nguyên liệu";
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            addUserControl(new SanPham());
            lbl_text.Text = btn_SanPham.Text;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            addUserControl(new ThongKe());
            lbl_text.Text = btn_ThongKe.Text;
        }

        private void GiaoDienQL_Load(object sender, EventArgs e)
        {
            addUserControl(new Home());
            lbl_text.Text = "Home";
        }

        private void GiaoDienQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //private bool Maximized = false;
        //private void btn_Max_Click(object sender, EventArgs e)
        //{
        //    if (Maximized)
        //    {
        //        WindowState = FormWindowState.Normal;
        //        Maximized = false;
        //    }
        //    else
        //    {
        //        WindowState = FormWindowState.Maximized;
        //        Maximized = true;
        //    }
        //}

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form dangnhap = new DangNhap();
            dangnhap.Show();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            //if (curentFormChild != null)
            //{
            //    curentFormChild.Close();
            //}
            addUserControl(new Home());
            lbl_text.Text = "Home";
        }
    }
}
