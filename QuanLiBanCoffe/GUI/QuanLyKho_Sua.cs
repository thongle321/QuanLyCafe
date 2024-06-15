using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
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
    public partial class QuanLyKho_Sua : Form
    {
        public int MaNL;

        public void LayMaNL(int MaNL)
        {
            this.MaNL = MaNL;
        }
        public QuanLyKho_Sua()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (txt_NguyenLieu.Text == "" || txt_SoLuong.Text == "" || txt_DonVi.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txt_SoLuong.Text, out int SoLuong))
            {
                MessageBox.Show("Số lượng phải là số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KhoSanPham khoSanPham = new KhoSanPham();
            SuaNguyenLieuBLL suaNguyenLieuBLL = new SuaNguyenLieuBLL();
            KhoSanPhamDTO khoSanPhamDTO = new KhoSanPhamDTO();
            khoSanPhamDTO.TenNL = txt_NguyenLieu.Text;
            khoSanPhamDTO.SoLuong = SoLuong;
            khoSanPhamDTO.DonVi = txt_DonVi.Text;
            khoSanPhamDTO.MaNL = this.MaNL;
            bool SuaNguyenLieu = suaNguyenLieuBLL.SuaNguyenLieu(khoSanPhamDTO);
            if (SuaNguyenLieu)
            {
                MessageBox.Show("Cập nhật thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                khoSanPham.LoadForm();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void QuanLyKho_Sua_Load(object sender, EventArgs e)
        {
        }
    }
}
