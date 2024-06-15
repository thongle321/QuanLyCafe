using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using QuanLiBanCoffe.DTO;
namespace QuanLiBanCoffe.DAL
{
    public class SqlConnectionConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=.;Initial Catalog=QuanLyCafe;Integrated Security=True;Encrypt=False");
            return myConnection;
        }
    }
    internal class KetNoiDatabase
    {
        public static DataTable HienThiNhanVienDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            string HienThiNhanVien = "SELECT NV.MaNV, NV.TenNV, NV.GioiTinh, NV.SDT, TK.TenNguoiDung, TK.MatKhau FROM NhanVien NV, TaiKhoan TK WHERE NV.MaTK = TK.MaTK AND TK.Loai = 2";
            SqlDataAdapter da = new SqlDataAdapter(HienThiNhanVien, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static TaiKhoanDTO KiemTraDTO(TaiKhoanDTO taikhoan)
        {
            TaiKhoanDTO ketqua = null;
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string TaiKhoan = "SELECT * FROM TaiKhoan WHERE TenNguoiDung = @TenNguoiDung AND MatKhau = @MatKhau AND Loai IN (1, 2)";
            SqlCommand cmd = new SqlCommand(TaiKhoan, myConnection);
            cmd.Parameters.AddWithValue("@TenNguoiDung", taikhoan.TenNguoiDung);
            cmd.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ketqua = new TaiKhoanDTO
                {
                    MaTK = reader.GetInt32(0),
                    TenNguoiDung = reader.GetString(1),
                    MatKhau = reader.GetString(2),
                    Loai = reader.GetInt32(3)
                };
            }
            reader.Close();
            myConnection.Close();
            return ketqua;
        }
        public static bool ThemNhanVienDTO(NhanVienDTO nhanvien)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string AddTK = "INSERT INTO TaiKhoan (TenNguoiDung, MatKhau, Loai) VALUES (@TenNguoiDung, @MatKhau, @Loai)";
            SqlCommand cmd1 = new SqlCommand(AddTK, myConnection);
            cmd1.Parameters.AddWithValue("@TenNguoiDung", nhanvien.TenNguoiDung);
            cmd1.Parameters.AddWithValue("@MatKhau", nhanvien.MatKhau);
            cmd1.Parameters.AddWithValue("@Loai", 2);
            if (cmd1.ExecuteNonQuery() > 0)
            {
                string getMaTK = "SELECT TOP 1 MaTK FROM TaiKhoan WHERE TenNguoiDung = @TenNguoiDung ORDER BY MaTK DESC";
                SqlCommand cmdMaTK = new SqlCommand(getMaTK, myConnection);
                cmdMaTK.Parameters.AddWithValue("@TenNguoiDung", nhanvien.TenNguoiDung);
                int MaTK = (int)cmdMaTK.ExecuteScalar();

                string AddNV = "INSERT INTO NhanVien (MaTK,TenNV, GioiTinh, SDT) VALUES (@MaTK,@TenNV, @GioiTinh, @SDT)";
                SqlCommand cmd2 = new SqlCommand(AddNV, myConnection);
                cmd2.Parameters.AddWithValue("@MaTK", MaTK);
                cmd2.Parameters.AddWithValue("@TenNV", nhanvien.TenNV);
                cmd2.Parameters.AddWithValue("@GioiTinh", nhanvien.GioiTinh);
                cmd2.Parameters.AddWithValue("@SDT", nhanvien.SDT);
                return cmd2.ExecuteNonQuery() > 0;
            }
            myConnection.Close();
            return false;
        }
        public static bool SuaNhanVienDTO(NhanVienDTO nhanvien)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string MaTK = "SELECT MaTK FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmdFetch = new SqlCommand(MaTK, myConnection);
            cmdFetch.Parameters.AddWithValue("@MaNV", nhanvien.MaNV);
            int ketQua = (int)cmdFetch.ExecuteScalar();
            if (ketQua > 0)
            {
                int maTK = Convert.ToInt32(ketQua);
                string SuaNV = "UPDATE NhanVien SET TenNV=@TenNV, GioiTinh=@GioiTinh, SDT=@SDT WHERE MaNV=@MaNV";
                SqlCommand cmd = new SqlCommand(SuaNV, myConnection);
                cmd.Parameters.AddWithValue("@TenNV", nhanvien.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nhanvien.GioiTinh);
                cmd.Parameters.AddWithValue("@SDT", nhanvien.SDT);
                cmd.Parameters.AddWithValue("@MaNV", nhanvien.MaNV);

                string SuaTK = "UPDATE TaiKhoan SET TenNguoiDung=@TenNguoiDung, MatKhau=@MatKhau WHERE MaTK=@MaTK";
                SqlCommand cmd2 = new SqlCommand(SuaTK, myConnection);
                cmd2.Parameters.AddWithValue("@TenNguoiDung", nhanvien.TenNguoiDung);
                cmd2.Parameters.AddWithValue("@MatKhau", nhanvien.MatKhau);
                cmd2.Parameters.AddWithValue("@MaTK", maTK);
                return (cmd.ExecuteNonQuery() > 0 && cmd2.ExecuteNonQuery() > 0);
            }
            myConnection.Close();
            return false;
        }
        public static bool XoaNhanVienDTO(int MaNV)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string LayMaTK = "SELECT MaTK FROM NhanVien WHERE MaNV = @MaNV";
            SqlCommand cmd1 = new SqlCommand(LayMaTK, myConnection);
            cmd1.Parameters.AddWithValue("@MaNV", MaNV);
            int MaTK = (int)cmd1.ExecuteScalar();
            if (MaTK > 0)
            {
                string SuaNV = "DELETE NhanVien WHERE MaNV=@MaNV";
                SqlCommand cmd2 = new SqlCommand(SuaNV, myConnection);
                string SuaTK = "DELETE TaiKhoan WHERE MaTK=@MaTK";
                SqlCommand cmd3 = new SqlCommand(SuaTK, myConnection);
                cmd2.Parameters.AddWithValue("@MaNV", MaNV);
                cmd3.Parameters.AddWithValue("@MaTK", MaTK);

                return (cmd2.ExecuteNonQuery() > 0 && cmd3.ExecuteNonQuery() > 0);
            }
            myConnection.Close();
            return false;
        }
        public static DataTable TimKiemNhanVienDTO(string TenNV)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiNhanVien = "SELECT NV.MaNV, NV.TenNV, NV.GioiTinh, NV.SDT, TK.TenNguoiDung, TK.MatKhau FROM NhanVien NV, TaiKhoan TK WHERE NV.MaTK = TK.MaTK AND TenNV LIKE @TenNV";
            SqlDataAdapter da = new SqlDataAdapter(HienThiNhanVien, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@TenNV", "%" + TenNV + "%");
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiNguyenLieuDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiNguyenLieu = "SELECT MaNL, TenNL, SoLuong, DonVi FROM KhoSanPham";
            SqlDataAdapter da = new SqlDataAdapter(HienThiNguyenLieu, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static bool ThemNguyenLieuDTO(KhoSanPhamDTO khoSanPham)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThemKho = "INSERT INTO KhoSanPham VALUES (@TenNL, @SoLuong, @DonVi)";
            SqlCommand cmd = new SqlCommand(ThemKho, myConnection);
            cmd.Parameters.AddWithValue("@TenNL", khoSanPham.TenNL);
            cmd.Parameters.AddWithValue("@SoLuong", khoSanPham.SoLuong);
            cmd.Parameters.AddWithValue("@DonVi", khoSanPham.DonVi);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static bool SuaNguyenLieuDTO(KhoSanPhamDTO khoSanPham)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string SuaKho = "UPDATE KhoSanPham SET TenNL = @TenNL, SoLuong = @SoLuong, DonVi = @DonVi WHERE MaNL = @MaNL";
            SqlCommand cmd = new SqlCommand(SuaKho, myConnection);
            cmd.Parameters.AddWithValue("@TenNL", khoSanPham.TenNL);
            cmd.Parameters.AddWithValue("@SoLuong", khoSanPham.SoLuong);
            cmd.Parameters.AddWithValue("@DonVi", khoSanPham.DonVi);
            cmd.Parameters.AddWithValue("@MaNL", khoSanPham.MaNL);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static bool XoaNguyenLieuDTO(int MaNL)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string XoaKho = "DELETE FROM KhoSanPham WHERE MaNL = @MaNL";
            SqlCommand cmd = new SqlCommand(XoaKho, myConnection);
            cmd.Parameters.AddWithValue("@MaNL", MaNL);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static DataTable TimKiemNguyenLieuDTO(string TenNL)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string TimKiemNguyenLieu = "SELECT MaNL, TenNL, SoLuong, DonVi FROM KhoSanPham WHERE TenNL LIKE @TenNL";
            SqlDataAdapter da = new SqlDataAdapter(TimKiemNguyenLieu, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@TenNL", "%" + TenNL + "%");
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiSanPhamDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiSanPham = "SELECT SP.MaSP, SP.Anh, SP.Ten, LSP.Ten AS Ten1, SP.Gia FROM SanPham SP, LoaiSanPham LSP WHERE SP.MaLoai = LSP.MaLoai";
            SqlDataAdapter da = new SqlDataAdapter(HienThiSanPham, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiSanPhamTheoLoaiDTO(int MaLoai)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string TimKiemSanPham = "SELECT SP.MaSP, SP.Anh, SP.Ten, LSP.Ten AS Ten1, SP.Gia FROM SanPham SP, LoaiSanPham LSP WHERE SP.MaLoai = LSP.MaLoai AND LSP.MaLoai = @MaLoai";
            SqlDataAdapter da = new SqlDataAdapter(TimKiemSanPham, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@MaLoai", MaLoai);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiNguyenLieuSanPhamDTO(int MaSP)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string NguyenLieuSanPham = "SELECT NL.MaNL, KSP.TenNL, NL.SoLuong, KSP.DonVi FROM SanPham SP, NguyenLieu NL, KhoSanPham KSP\r\nWHERE NL.MaNL = KSP.MaNL AND NL.MaSP = SP.MaSP AND SP.MaSP = @MaSP";
            SqlDataAdapter da = new SqlDataAdapter(NguyenLieuSanPham, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@MaSP", MaSP);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiLoaiSanPhamDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string LoaiSanPham = "SELECT MaLoai, Ten FROM LoaiSanPham";
            SqlDataAdapter da = new SqlDataAdapter(LoaiSanPham, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiLoaiNguyenLieuDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string LoaiNguyenLieu = "SELECT MaNL, TenNL, DonVi FROM KhoSanPham";
            SqlDataAdapter da = new SqlDataAdapter(LoaiNguyenLieu, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static string HienThiDonViTheoNguyenLieuDTO(int MaNL)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();

            string DonVi = "SELECT DonVi FROM KhoSanPham WHERE MaNL = @MaNL";
            SqlCommand cmd = new SqlCommand(DonVi, myConnection);
            cmd.Parameters.AddWithValue("@MaNL", MaNL);

            string donVi = "";
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                donVi = rd["DonVi"].ToString();
            }
            myConnection.Close();
            return donVi;
        }
        public static DataTable TimKiemSanPhamDTO(string Ten)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiSanPham = "SELECT SP.MaSP, SP.Anh, SP.Ten, LSP.Ten AS Ten1, SP.Gia FROM SanPham SP, LoaiSanPham LSP WHERE SP.MaLoai = LSP.MaLoai AND SP.Ten LIKE @Ten";
            SqlDataAdapter da = new SqlDataAdapter(HienThiSanPham, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@Ten", "%" + Ten + "%");
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static bool ThemSanPhamDTO(SanPhamDTO SanPham, List<NguyenLieuDTO> nguyenLieu)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThemSanPham = "INSERT INTO SanPham(Ten, MaLoai, Gia, Anh) VALUES(@Ten, @MaLoai, @Gia, @Anh)";
            SqlCommand cmd = new SqlCommand(ThemSanPham, myConnection);
            cmd.Parameters.AddWithValue("@Ten", SanPham.Ten);
            cmd.Parameters.AddWithValue("@MaLoai", SanPham.MaLoai);
            cmd.Parameters.AddWithValue("@Gia", SanPham.Gia);
            cmd.Parameters.AddWithValue("@Anh", SanPham.Anh);
            if (cmd.ExecuteNonQuery() > 0)
            {
                string MaSP = "SELECT TOP 1 MaSP FROM SanPham WHERE Ten = @Ten ORDER BY MaSP DESC";
                SqlCommand cmdMa = new SqlCommand(MaSP, myConnection);
                cmdMa.Parameters.AddWithValue("@Ten", SanPham.Ten);
                int Ma = (int)cmdMa.ExecuteScalar();
                foreach (var item in nguyenLieu)
                {
                    string ThemNguyenLieu = "INSERT INTO NguyenLieu(MaSP, MaNL, SoLuong) VALUES (@MaSp, @MaNL, @SoLuong)";
                    SqlCommand cmd2 = new SqlCommand(ThemNguyenLieu, myConnection);
                    cmd2.Parameters.AddWithValue("@MaSP", Ma);
                    cmd2.Parameters.AddWithValue("@MaNL", item.MaNL);
                    cmd2.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    if (cmd2.ExecuteNonQuery() > 0)
                    {

                    }
                    else
                    {
                        myConnection.Close();
                        return false;
                    }
                }
                return true;
            }
            else
            {
                myConnection.Close();
                return false;
            }
        }
        public static bool SuaSanPhamDTO(SanPhamDTO sanPham)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string SuaSanPham = "UPDATE SanPham SET Ten = @Ten, MaLoai = @MaLoai, Gia = @Gia, Anh = @Anh WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(SuaSanPham, myConnection);
            cmd.Parameters.AddWithValue("@Ten", sanPham.Ten);
            cmd.Parameters.AddWithValue("@MaLoai", sanPham.MaLoai);
            cmd.Parameters.AddWithValue("@Gia", sanPham.Gia);
            cmd.Parameters.AddWithValue("@Anh", sanPham.Anh);
            cmd.Parameters.AddWithValue("@MaSP", sanPham.MaSP);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static bool XoaNguyenLieuSanPhamDTO(int MaSP, int MaNL)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string XoaNguyenLieuSanPham = "DELETE FROM NguyenLieu WHERE MaSP = @MaSP AND MaNL = @MaNL";
            SqlCommand cmd = new SqlCommand(XoaNguyenLieuSanPham, myConnection);
            cmd.Parameters.AddWithValue("@MaSP", MaSP);
            cmd.Parameters.AddWithValue("@MaNL", MaNL);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static bool XoaSanPhamDTO(int MaSP)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string XoaSanPham = "DELETE FROM SanPham WHERE MaSP = @MaSP";
            string XoaNguyenLieuSanPham = "DELETE FROM NguyenLieu WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(XoaSanPham, myConnection);
            SqlCommand cmd2 = new SqlCommand(XoaNguyenLieuSanPham, myConnection);
            cmd2.Parameters.AddWithValue("@MaSP", MaSP);
            cmd.Parameters.AddWithValue("@MaSP", MaSP);
            if (cmd2.ExecuteNonQuery() > 0 && cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static bool ThemNguyenLieuSanPhamDTO(NguyenLieuDTO nguyenLieu)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThemKho = "INSERT INTO NguyenLieu VALUES (@MaSP, @MaNL, @SoLuong)";
            SqlCommand cmd = new SqlCommand(ThemKho, myConnection);
            cmd.Parameters.AddWithValue("@MaSP", nguyenLieu.MaSP);
            cmd.Parameters.AddWithValue("@MaNL", nguyenLieu.MaNL);
            cmd.Parameters.AddWithValue("@SoLuong", nguyenLieu.SoLuong);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static DataTable HienThiMaSanPhamDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string MaSP = "SELECT MaSP FROM SanPham";
            SqlDataAdapter da = new SqlDataAdapter(MaSP, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static SanPhamDTO HienThiThongTinTheoMaSPDTO(int MaSP)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();

            string SanPham = "SELECT Ten, Gia FROM SanPham WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(SanPham, myConnection);
            cmd.Parameters.AddWithValue("@MaSP", MaSP);

            SanPhamDTO sanPhamDTO = new SanPhamDTO();

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                sanPhamDTO.Ten = rd["Ten"].ToString();
                sanPhamDTO.Gia = int.Parse(rd["Gia"].ToString());

            }
            myConnection.Close();
            return sanPhamDTO;
        }
        public static DataTable HienThiKhachHangDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiKhachHang = "SELECT * FROM KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(HienThiKhachHang, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable TimKiemKhachHangDTO(string TenKH)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiKhachHang = "SELECT * FROM KhachHang WHERE TenKH LIKE @TenKH";
            SqlDataAdapter da = new SqlDataAdapter(HienThiKhachHang, myConnection);
            da.SelectCommand.Parameters.AddWithValue("@TenKH", "%" + TenKH + "%");
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static DataTable HienThiMaKHDTO()
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string HienThiKhachHang = "SELECT MaKH FROM KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(HienThiKhachHang, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myConnection.Close();
            return ds.Tables[0];
        }
        public static bool ThemKhachHangDTO(KhachHangDTO khachHang)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThemKhachHang = "INSERT INTO KhachHang (TenKH, DiaChi, SĐT, NgayTao) VALUES (@TenKH, @DiaChi, @SĐT, @NgayTao)";
            SqlCommand cmd = new SqlCommand(ThemKhachHang, myConnection);
            cmd.Parameters.AddWithValue("@TenKH", khachHang.TenKH);
            cmd.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
            cmd.Parameters.AddWithValue("@SĐT", khachHang.SĐT);
            cmd.Parameters.AddWithValue("@NgayTao", khachHang.NgayTao);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            myConnection.Close();
            return false;
        }
        public static KhachHangDTO HienThiTenTheoMaKHDTO(int MaKH)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string KhachHang = "SELECT TenKH FROM KhachHang WHERE MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(KhachHang, myConnection);
            cmd.Parameters.AddWithValue("@MaKH", MaKH);
            KhachHangDTO khachHangDTO = new KhachHangDTO();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                khachHangDTO.TenKH = rd["TenKH"].ToString();
            }
            myConnection.Close();
            return khachHangDTO;
        }
        public static bool ThemHoaDonChiTietHoaDonDTO(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietHoaDon)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThemHoaDon = "INSERT INTO HoaDon (MaKH, NgayTao, TongTien) VALUES (@MaKH, @NgayTao, @TongTien)";
            SqlCommand cmd = new SqlCommand(ThemHoaDon, myConnection);
            cmd.Parameters.AddWithValue("@MaKH", hoaDon.MaKH);
            cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);
            cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
            if (cmd.ExecuteNonQuery() > 0)
            {
                string MaHD = "SELECT TOP 1 MaHD FROM HoaDon ORDER BY MaHD DESC";
                SqlCommand cmd2 = new SqlCommand(MaHD, myConnection);
                int maHD = (int)cmd2.ExecuteScalar();
                foreach (var item in chiTietHoaDon)
                {
                    string ThemChiTietHoaDon = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, TenSP, SoLuong, GiaSP, TongTien) VALUES (@MaHD, @MaSP, @TenSP, @SoLuong, @GiaSP, @TongTien)";
                    SqlCommand cmd3 = new SqlCommand(ThemChiTietHoaDon, myConnection);
                    cmd3.Parameters.AddWithValue("@MaHD", maHD);
                    cmd3.Parameters.AddWithValue("@MaSP", item.MaSP);
                    cmd3.Parameters.AddWithValue("@TenSP", item.TenSP);
                    cmd3.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd3.Parameters.AddWithValue("@GiaSP", item.GiaSP);
                    cmd3.Parameters.AddWithValue("@TongTien", item.TongTien);
                    if (cmd3.ExecuteNonQuery() > 0)
                    {

                    }
                    else
                    {
                        myConnection.Close();
                        return false;
                    }
                }
                return true;
            }
            else
            {
                myConnection.Close();
                return false;
            }
        }
        public static DataTable ThongKeTheoNgayDTO(int ngay)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThongKeNgay = "SELECT COUNT(DISTINCT hd.MaHD) as TongHoaDon, SUM(cthd.SoLuong) as TongSanPham, SUM(cthd.TongTien) as TongTien FROM ChiTietHoaDon cthd, HoaDon hd WHERE cthd.MaHD = hd.MaHD AND hd.NgayTao = @ngay";
            SqlCommand cmd = new SqlCommand(ThongKeNgay, myConnection);
            cmd.Parameters.AddWithValue("@ngay", ngay);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable ThongKeTheoThangDTO(int thang)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThongKeNgay = "SELECT COUNT(DISTINCT hd.MaHD) as TongHoaDon, SUM(cthd.SoLuong) as TongSanPham, SUM(cthd.TongTien) as TongTien FROM ChiTietHoaDon cthd, HoaDon hd WHERE cthd.MaHD = hd.MaHD AND MONTH(hd.NgayTao) = @Thang";
            SqlCommand cmd = new SqlCommand(ThongKeNgay, myConnection);
            cmd.Parameters.AddWithValue("@thang", thang);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable ThongKeTheoNamDTO(int nam)
        {
            SqlConnection myConnection = SqlConnectionConnect.Connect();
            myConnection.Open();
            string ThongKeNgay = "SELECT COUNT(DISTINCT hd.MaHD) as TongHoaDon, SUM(cthd.SoLuong) as TongSanPham, SUM(cthd.TongTien) as TongTien FROM ChiTietHoaDon cthd, HoaDon hd WHERE cthd.MaHD = hd.MaHD AND YEAR(hd.NgayTao) = @Nam";
            SqlCommand cmd = new SqlCommand(ThongKeNgay, myConnection);
            cmd.Parameters.AddWithValue("@nam", nam);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
