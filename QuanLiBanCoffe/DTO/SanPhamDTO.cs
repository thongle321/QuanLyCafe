using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanCoffe.DTO
{
    internal class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string Ten { get; set; }
        public int MaLoai { get; set; }
        public int Gia { get; set; }
        public byte[] Anh { get; set; }
    }
}
