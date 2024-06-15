using QuanLiBanCoffe.BLL;
using QuanLiBanCoffe.DAL;
using QuanLiBanCoffe.DTO;
using QuanLiBanCoffe.GUI;
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
    public partial class QuanLyKho_Them : Form
    {
        public QuanLyKho_Them()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Them_Click(object sender, EventArgs e)
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
            ThemNguyenLieuBLL themNguyenLieuBLL = new ThemNguyenLieuBLL();
            KhoSanPhamDTO khoSanPhamDTO = new KhoSanPhamDTO();
            khoSanPhamDTO.TenNL = txt_NguyenLieu.Text;
            khoSanPhamDTO.SoLuong = SoLuong;
            khoSanPhamDTO.DonVi = txt_DonVi.Text;
            bool ThemNguyenLieu = themNguyenLieuBLL.ThemNguyenLieu(khoSanPhamDTO);
            if(ThemNguyenLieu)
            {
                MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhoSanPham khoSanPham = new KhoSanPham();
                khoSanPham.LoadForm();
            }    
            else
            {
                MessageBox.Show("Thêm không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
