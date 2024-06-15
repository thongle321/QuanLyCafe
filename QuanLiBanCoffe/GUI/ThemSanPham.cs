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
    public partial class ThemSanPham : Form
    {
        HienThiLoaiSanPhamBLL hienThiLoaiSanPhamBLL = new HienThiLoaiSanPhamBLL();
        HienThiLoaiNguyenLieuBLL hienThiLoaiNguyenLieuBLL = new HienThiLoaiNguyenLieuBLL();
        HienThiDonViNguyenLieuBLL hienThiDonViNguyenLieuBLL = new HienThiDonViNguyenLieuBLL();
        ThemSanPhamBLL themSanPhamBLL = new ThemSanPhamBLL();
        public int MaSP;

        public void LayMaSP(int MaSP)
        {
            this.MaSP = MaSP;
        }

        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ChiTietSanPham_Them_Load(object sender, EventArgs e)
        {
            cbb_Loai.DataSource = hienThiLoaiSanPhamBLL.HienThiLoaiSanPham();
            cbb_Loai.DisplayMember = "Ten";
            cbb_Loai.ValueMember = "MaLoai";
            cbb_TenNguyenLieu.DataSource = hienThiLoaiNguyenLieuBLL.HienThiLoaiNguyenLieu();
            cbb_TenNguyenLieu.DisplayMember = "TenNL";
            cbb_TenNguyenLieu.ValueMember = "MaNL";

        }

        private void txt_DonVi_TextChanged(object sender, EventArgs e)
        {            
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_SoLuong.Text, out int soluong))
            {
                MessageBox.Show("Số lượng phải là số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int MaNL = (int)cbb_TenNguyenLieu.SelectedValue;
            string Ten = cbb_TenNguyenLieu.Text;
            int SoLuong = soluong;
            string DonVi = txt_DonVi.Text;
            grid_NguyenLieu.Rows.Add(MaNL, Ten, SoLuong, DonVi);
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            if(txt_Ten.Text == "" || txt_Gia.Text == "" || pb_Anh.Image == null)
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
            SanPhamDTO sanPhamDTO = new SanPhamDTO();
            sanPhamDTO.Ten = txt_Ten.Text;
            sanPhamDTO.MaLoai = (int)cbb_Loai.SelectedValue;
            sanPhamDTO.Gia = Gia;
            sanPhamDTO.Anh = ImageToByteArray(pb_Anh);
            List<NguyenLieuDTO> nguyenLieu = new List<NguyenLieuDTO>();
            foreach (DataGridViewRow dgvr in grid_NguyenLieu.Rows)
            {
                nguyenLieu.Add(new NguyenLieuDTO
                {
                    MaNL = int.Parse(dgvr.Cells["MaNL"].Value.ToString()),
                    SoLuong = int.Parse(dgvr.Cells["SoLuong"].Value.ToString())
                });
            }
            bool ThemSanPham = themSanPhamBLL.ThemSanPham(sanPhamDTO, nguyenLieu);
            if(ThemSanPham)
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                SanPham sanPham = new SanPham();
                sanPham.LoadForm();
            }    
            else
            {
                MessageBox.Show("Thêm thất bại");
            }    
  
        }

        private void btn_ThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png) | *.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png";
            if(ofd.ShowDialog() == DialogResult.OK)
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
    }
}
