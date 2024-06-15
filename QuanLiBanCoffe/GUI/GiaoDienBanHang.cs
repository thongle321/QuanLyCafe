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
using QuanLiBanCoffe.GUI;
namespace QuanLiBanCoffe
{
    public partial class GiaoDienBanHang : Form
    {
        HienThiMaSanPhamBLL hienThiMaSanPhamBLL = new HienThiMaSanPhamBLL();
        HienThiThongTinTheoMaSPBLL hienThiThongTinTheoMaSPBLL = new HienThiThongTinTheoMaSPBLL();
        HienThiMaKHBLL hienThiMaKHBLL = new HienThiMaKHBLL();
        HienThiTenTheoMaKHBLL hienThiTenTheoMaKHBLL = new HienThiTenTheoMaKHBLL();
        ThemHoaDonChiTietHoaDonBLL themHoaDonChiTietHoaDonBLL = new ThemHoaDonChiTietHoaDonBLL();
        public GiaoDienBanHang()
        {
            InitializeComponent();
        }

        private void cbb_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GiaoDienBanHang_Load(object sender, EventArgs e)
        {
            cbb_MaSP.DataSource = hienThiMaSanPhamBLL.HienThiMaSanPham();
            cbb_MaSP.ValueMember = "MaSP";
            cbb_MaKH.DataSource = hienThiMaKHBLL.HienThiMaKH();
            cbb_MaKH.ValueMember = "MaKH";
        }

        private void cbb_MaSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbb_MaSP.SelectedIndex != -1)
            {
                DataRowView drv = (DataRowView)cbb_MaSP.SelectedItem;
                if (drv != null)
                {
                    int MaSP = (int)drv["MaSP"];
                    SanPhamDTO sanPhamDTO = hienThiThongTinTheoMaSPBLL.HienThiThongTinTheoMaSP(MaSP);
                    txt_Ten.Text = sanPhamDTO.Ten;
                    txt_Gia.Text = sanPhamDTO.Gia.ToString();

                    int SoLuong = int.Parse(nud_SoLuong.Value.ToString());
                    int Gia = int.Parse(txt_Gia.Text);
                    txt_TongGia.Text = (SoLuong * Gia).ToString();
                }
            }
        }
        private void cbb_MaKH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbb_MaKH.SelectedIndex != -1)
            {
                DataRowView drv = (DataRowView)cbb_MaKH.SelectedItem;
                if (drv != null)
                {
                    int MaKH = (int)drv["MaKH"];
                    KhachHangDTO khachHangDTO = hienThiTenTheoMaKHBLL.HienThiTenTheoMaKH(MaKH);
                    txt_TenKH.Text = khachHangDTO.TenKH;
                }
            }
        }

        private void nud_SoLuong_ValueChanged(object sender, EventArgs e)
        {
            int SoLuong = int.Parse(nud_SoLuong.Value.ToString());
            int Gia = int.Parse(txt_Gia.Text);
            txt_TongGia.Text = (SoLuong * Gia).ToString();
        }
        private void btn_KhachHang_Click_1(object sender, EventArgs e)
        {
            QuanLyKhachHang quanLyKhachHang = new QuanLyKhachHang();
            quanLyKhachHang.Show();
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {

            if (grid_SanPham.SelectedRows.Count > 0)
            {
                grid_SanPham.Rows.RemoveAt(grid_SanPham.SelectedRows[0].Index);
                TongGia -= temp;
                btn_ThanhToan.Text = TongGia.ToString();
            }
            else
            {
                MessageBox.Show("Không có sản phẩm trong bảng để xoá", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GiaoDienBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btn_TroLai_Click(object sender, EventArgs e)
        {
            GiaoDienNhanVien giaoDienNhanVien = new GiaoDienNhanVien();
            Hide();
            giaoDienNhanVien.Show();
        }

        private void btn_ThanhToan_Click_1(object sender, EventArgs e)
        {
            if (grid_SanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được thêm", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                HoaDonDTO hoaDonDTO = new HoaDonDTO();
                hoaDonDTO.MaKH = (int)cbb_MaKH.SelectedValue;
                hoaDonDTO.NgayTao = DateTime.Now;
                hoaDonDTO.TongTien = int.Parse(btn_ThanhToan.Text);
                List<ChiTietHoaDonDTO> chiTietHoaDon = new List<ChiTietHoaDonDTO>();
                foreach (DataGridViewRow dgvr in grid_SanPham.Rows)
                {
                    chiTietHoaDon.Add(new ChiTietHoaDonDTO
                    {
                        MaSP = int.Parse(dgvr.Cells["MaSP"].Value.ToString()),
                        TenSP = dgvr.Cells["TenSP"].Value.ToString(),
                        SoLuong = int.Parse(dgvr.Cells["SoLuong"].Value.ToString()),
                        GiaSP = int.Parse(dgvr.Cells["Gia"].Value.ToString()),
                        TongTien = int.Parse(dgvr.Cells["Tong"].Value.ToString())
                    });
                }
                bool thanhToanThanhCong = themHoaDonChiTietHoaDonBLL.ThemHoaDonChiTietHoaDon(hoaDonDTO, chiTietHoaDon);
                if (thanhToanThanhCong)
                {

                    MessageBox.Show("Thanh toán thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grid_SanPham.Rows.Clear();
                    btn_ThanhToan.Text = 0.ToString();
                    TongGia = 0;
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txt_TenKH_TextChanged(object sender, EventArgs e)
        {

        }
        int temp;
        private void grid_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                temp = int.Parse(grid_SanPham.Rows[e.RowIndex].Cells[4].Value.ToString());
            }catch (Exception ex)
            {

            }
        }
        public int n, TongGia = 0;

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if(txt_TongGia.Text != "0" && txt_TongGia.Text != "")
            {
                int MaSP = (int)cbb_MaSP.SelectedValue;
                foreach (DataGridViewRow dgvr in grid_SanPham.Rows)
                {
                    if (int.Parse(dgvr.Cells[0].Value.ToString()) == MaSP)
                    {
                        MessageBox.Show("Sản phẩm đã có trong bảng", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                n = grid_SanPham.Rows.Add();
                grid_SanPham.Rows[n].Cells[0].Value = cbb_MaSP.SelectedValue;
                grid_SanPham.Rows[n].Cells[1].Value = txt_Ten.Text;
                grid_SanPham.Rows[n].Cells[2].Value = nud_SoLuong.Value;
                grid_SanPham.Rows[n].Cells[3].Value = txt_Gia.Text;
                grid_SanPham.Rows[n].Cells[4].Value = txt_TongGia.Text;
                TongGia += int.Parse(txt_TongGia.Text);
                btn_ThanhToan.Text = TongGia.ToString();
            }    
            else
            {
                MessageBox.Show("Số lượng ít nhất là 1", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    

        }
    }
}
