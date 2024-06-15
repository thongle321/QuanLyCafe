using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanCoffe.GUI
{
    public partial class SanPham : UserControl
    {
        HienThiSanPhamBLL hienThiSanPhamBLL = new HienThiSanPhamBLL();
        HienThiSanPhamTheoLoaiBLL hienThiSanPhamTheoLoaiBLL = new HienThiSanPhamTheoLoaiBLL();
        TimKiemSanPhamBLL timKiemSanPhamBLL = new TimKiemSanPhamBLL();
        public int LayMaSP;
        public SanPham()
        {
            InitializeComponent();
        }

        public void LoadForm()
        {
            grid_SanPham.DataSource = hienThiSanPhamBLL.HienThiSanPham();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void btn_CaPhe_Click(object sender, EventArgs e)
        {
            grid_SanPham.DataSource = hienThiSanPhamTheoLoaiBLL.HienThiSanPhamTheoLoai(1);
        }

        private void btn_DaXay_Click(object sender, EventArgs e)
        {
            grid_SanPham.DataSource = hienThiSanPhamTheoLoaiBLL.HienThiSanPhamTheoLoai(2);

        }

        private void btn_SoDa_Click(object sender, EventArgs e)
        {
            grid_SanPham.DataSource = hienThiSanPhamTheoLoaiBLL.HienThiSanPhamTheoLoai(3);

        }

        private void btn_Tra_Click(object sender, EventArgs e)
        {
            grid_SanPham.DataSource = hienThiSanPhamTheoLoaiBLL.HienThiSanPhamTheoLoai(4);
        }

        private void btn_TatCa_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void grid_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string TenCot = grid_SanPham.Columns[e.ColumnIndex].Name;
            if (TenCot == "Sua")
            {
                LayMaSP = Convert.ToInt32(grid_SanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString());
                SuaSanPham suaSanPham = new SuaSanPham();
                suaSanPham.LayMaSP(LayMaSP);
                suaSanPham.txt_Ten.Text = grid_SanPham.Rows[e.RowIndex].Cells["Ten"].Value.ToString();
                suaSanPham.txt_Gia.Text = grid_SanPham.Rows[e.RowIndex].Cells["Gia"].Value.ToString();
                var data = (Byte[])(grid_SanPham.Rows[e.RowIndex].Cells["Anh"].Value);
                var stream = new MemoryStream(data);
                suaSanPham.pb_Anh.Image = Image.FromStream(stream);
                HienThiNguyenLieuSanPhamBLL hienThiNguyenLieuSanPhamBLL = new HienThiNguyenLieuSanPhamBLL();
                suaSanPham.ShowDialog();
                suaSanPham.cbb_Loai.SelectedText = grid_SanPham.Rows[e.RowIndex].Cells["Ten1"].Value.ToString();
                LoadForm();
            }
            else if(TenCot == "Xoa")
            {
                LayMaSP = Convert.ToInt32(grid_SanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString());
                XoaSanPhamBLL xoaSanPhamBLL = new XoaSanPhamBLL();
                DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xoá", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    bool Xoa = xoaSanPhamBLL.XoaSanPham(LayMaSP);
                    if (Xoa)
                    {
                        MessageBox.Show("Xoá thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadForm();
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }    
            else
            {
                LayMaSP = Convert.ToInt32(grid_SanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString());
                ChiTietSanPham chiTietSanPham = new ChiTietSanPham();
                chiTietSanPham.LayMaSP(LayMaSP);
                chiTietSanPham.txt_Ten.Text = grid_SanPham.Rows[e.RowIndex].Cells["Ten"].Value.ToString();
                chiTietSanPham.txt_Loai.Text = grid_SanPham.Rows[e.RowIndex].Cells["Ten1"].Value.ToString();
                chiTietSanPham.txt_Gia.Text = grid_SanPham.Rows[e.RowIndex].Cells["Gia"].Value.ToString();
                var data = (Byte[])(grid_SanPham.Rows[e.RowIndex].Cells["Anh"].Value);
                var stream = new MemoryStream(data);
                chiTietSanPham.pb_Anh.Image = Image.FromStream(stream);
                HienThiNguyenLieuSanPhamBLL hienThiNguyenLieuSanPhamBLL = new HienThiNguyenLieuSanPhamBLL();
                chiTietSanPham.grid_NguyenLieu.DataSource = hienThiNguyenLieuSanPhamBLL.HienThiNguyenLieuSanPham(LayMaSP);
                chiTietSanPham.ShowDialog();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemSanPham ctsp_them = new ThemSanPham();
            ctsp_them.ShowDialog();
            LoadForm();
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string Ten = txt_TimKiem.Text;
            grid_SanPham.DataSource = timKiemSanPhamBLL.TimKiemSanPham(Ten);
        }
    }
}
