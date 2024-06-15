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
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.GUI;
using QuanLiBanCoffe.BLL;
namespace QuanLiBanCoffe
{
    public partial class KhoSanPham : UserControl
    {
        HienThiNguyenLieuBLL hienThiNguyenLieu = new HienThiNguyenLieuBLL();
        TimKiemNguyenLieuBLL timKiemNguyenLieu = new TimKiemNguyenLieuBLL();
        public int GetMaNL;
        public KhoSanPham()
        {
            InitializeComponent();
        }
        public void LoadForm()
        {
            grid_NguyenLieu.DataSource = hienThiNguyenLieu.HienThiNguyenLieu();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            QuanLyKho_Them quanLyKho_Them = new QuanLyKho_Them();
            quanLyKho_Them.ShowDialog();
            LoadForm();
        }

        private void grid_NguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string TenCot = grid_NguyenLieu.Columns[e.ColumnIndex].Name;
            if (TenCot == "Sua")
            {
                GetMaNL = Convert.ToInt32(grid_NguyenLieu.Rows[e.RowIndex].Cells["MaNL"].Value.ToString());
                QuanLyKho_Sua quanLyKho_Sua = new QuanLyKho_Sua();
                quanLyKho_Sua.LayMaNL(GetMaNL);
                quanLyKho_Sua.txt_NguyenLieu.Text = grid_NguyenLieu.Rows[e.RowIndex].Cells["TenNL"].Value.ToString();
                quanLyKho_Sua.txt_SoLuong.Text = grid_NguyenLieu.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
                quanLyKho_Sua.txt_DonVi.Text = grid_NguyenLieu.Rows[e.RowIndex].Cells["DonVi"].Value.ToString();
                quanLyKho_Sua.ShowDialog();
                LoadForm();
            }
            else if (TenCot == "Xoa")
            {
                GetMaNL = Convert.ToInt32(grid_NguyenLieu.Rows[e.RowIndex].Cells["MaNL"].Value.ToString());
                XoaNguyenLieuBLL xoaNguyenLieuBLL = new XoaNguyenLieuBLL();
                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xoá", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    bool XoaNguyenLieu = xoaNguyenLieuBLL.XoaNguyenLieu(GetMaNL);
                    if (XoaNguyenLieu)
                    {
                        MessageBox.Show("Xoá thành công", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
            }
            LoadForm();
        }
        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string TenNL = txt_TimKiem.Text;
            grid_NguyenLieu.DataSource = timKiemNguyenLieu.TimKiemNguyenLieu(TenNL);
        }
    }
}
