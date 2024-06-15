using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
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
    public partial class SuaSanPham : Form
    {
        HienThiLoaiSanPhamBLL hienThiLoaiSanPhamBLL = new HienThiLoaiSanPhamBLL();
        HienThiNguyenLieuSanPhamBLL hienThiNguyenLieuSanPhamBLL = new HienThiNguyenLieuSanPhamBLL();
        HienThiLoaiNguyenLieuBLL hienThiLoaiNguyenLieuBLL = new HienThiLoaiNguyenLieuBLL();
        HienThiDonViNguyenLieuBLL hienThiDonViNguyenLieuBLL = new HienThiDonViNguyenLieuBLL();
        ThemNguyenLieuSanPhamBLL themNguyenLieuSanPhamBLL = new ThemNguyenLieuSanPhamBLL();
        SuaSanPhamBLL suaSanPhamBLL = new SuaSanPhamBLL();
        SanPhamDTO SanPhamDTO = new SanPhamDTO();
        SanPham sanPham = new SanPham();
        public int MaSP;

        public void LayMaSP(int MaSP)
        {
            this.MaSP = MaSP;
        }

        public SuaSanPham()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if (txt_Ten.Text == "" || txt_Gia.Text == "" || pb_Anh.Image == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txt_Gia.Text, out int Gia))
            {
                MessageBox.Show("Giá phải là số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (grid_NguyenLieu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm nguyên liệu vào sản phẩm", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SanPhamDTO.Ten = txt_Ten.Text;
            SanPhamDTO.MaLoai = (int)cbb_Loai.SelectedValue;
            SanPhamDTO.Gia = int.Parse(txt_Gia.Text);
            SanPhamDTO.Anh = ImageToByteArray(pb_Anh);
            SanPhamDTO.MaSP = this.MaSP;
            bool SuaSanPham = suaSanPhamBLL.SuaSanPham(SanPhamDTO);
            if(SuaSanPham)
            {
                MessageBox.Show("Cập nhật thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sanPham.LoadForm();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaSanPham_Load(object sender, EventArgs e)
        {

            cbb_Loai.DataSource = hienThiLoaiSanPhamBLL.HienThiLoaiSanPham();
            cbb_Loai.DisplayMember = "Ten";
            cbb_Loai.ValueMember = "MaLoai";
            grid_NguyenLieu.DataSource = hienThiNguyenLieuSanPhamBLL.HienThiNguyenLieuSanPham(this.MaSP);
            cbb_TenNguyenLieu.DataSource = hienThiLoaiNguyenLieuBLL.HienThiLoaiNguyenLieu();
            cbb_TenNguyenLieu.DisplayMember = "TenNL";
            cbb_TenNguyenLieu.ValueMember = "MaNL";
        }

        private void btn_ThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png) | *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb_Anh.ImageLocation = ofd.FileName;
            }
        }
        public byte[] ImageToByteArray(PictureBox pb)
        {
            MemoryStream ms = new MemoryStream();
            pb.Image.Save(ms, pb.Image.RawFormat);
            return ms.ToArray();
        }

        private void grid_NguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_NguyenLieu.Rows[e.RowIndex];
                if (row != null)
                {
                    int MaNL = Convert.ToInt32(row.Cells["MaNL"].Value);
                    string TenCot = grid_NguyenLieu.Columns[e.ColumnIndex].Name;
                    if (TenCot == "Xoa")
                    {
                        XoaNguyenLieuSanPhamBLL xoaNguyenLieuSanPhamBLL = new XoaNguyenLieuSanPhamBLL();
                        DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xoá", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg == DialogResult.Yes)
                        {
                            bool Xoa = xoaNguyenLieuSanPhamBLL.XoaNguyenLieuSanPham(this.MaSP, MaNL);
                            if (Xoa)
                            {
                                MessageBox.Show("Xoá thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grid_NguyenLieu.DataSource = hienThiNguyenLieuSanPhamBLL.HienThiNguyenLieuSanPham(this.MaSP);
                            }
                            else
                            {
                                MessageBox.Show("Xoá không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_SoLuong.Text, out int soluong))
            {
                MessageBox.Show("Số lượng phải là số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NguyenLieuDTO nguyenLieu = new NguyenLieuDTO();
            nguyenLieu.MaSP = this.MaSP;
            nguyenLieu.MaNL = (int)cbb_TenNguyenLieu.SelectedValue;
            nguyenLieu.SoLuong = int.Parse(txt_SoLuong.Text);
            bool ThemNguyenLieu = themNguyenLieuSanPhamBLL.ThemNguyenLieuSanPham(nguyenLieu);
            if(ThemNguyenLieu)
            {
                grid_NguyenLieu.DataSource = hienThiNguyenLieuSanPhamBLL.HienThiNguyenLieuSanPham(this.MaSP);
            }
            else
            {

            }
        }

        private void cbb_TenNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_TenNguyenLieu.SelectedIndex != -1)
            {
                DataRowView drv = (DataRowView)cbb_TenNguyenLieu.SelectedItem;
                if (drv != null)
                {
                    int MaNL = (int)drv["MaNL"];

                    string DonVi = hienThiDonViNguyenLieuBLL.HienThiDonViTheoNguyenLieu(MaNL);
                    txt_DonVi.Text = DonVi;
                }
            }
        }
    }
}
