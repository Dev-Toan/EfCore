﻿using System;
using System.Collections.Generic;

namespace EFCore.models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public string? MaLoai { get; set; }

    public int? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public virtual LoaiSanPham? MaLoaiNavigation { get; set; }

    //public double? ThanhTien { get { return DonGia * SoLuong; } }
}