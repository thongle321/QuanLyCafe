﻿SELECT KSP.TenNL, NL.SoLuong, KSP.DonVi
FROM SanPham SP, NguyenLieu NL, KhoSanPham KSP
WHERE NL.MaNL = KSP.MaNL AND NL.MaSP = SP.MaSP AND SP.MaSP = 2