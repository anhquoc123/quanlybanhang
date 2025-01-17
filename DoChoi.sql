USE [DoChoi]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/24/2021 1:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NULL,
	[MaSanPham] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[ThanhTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/24/2021 1:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime] NULL,
	[TrangThai] [int] NULL,
	[TenKhachHang] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[MaTaiKhoan] [nvarchar](250) NULL,
	[SoLuong] [int] NULL,
	[TongTien] [decimal](18, 0) NULL,
	[GiamGia] [decimal](18, 2) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 5/24/2021 1:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](250) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 5/24/2021 1:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](250) NULL,
	[LoaiSanPham] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
	[Mota] [nvarchar](500) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/24/2021 1:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [nvarchar](250) NOT NULL,
	[MatKhau] [nvarchar](250) NULL,
	[HoTen] [nvarchar](250) NULL,
	[Groups] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 1, 4, 1, CAST(125000 AS Decimal(18, 0)), CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 1, 7, 4, CAST(300000 AS Decimal(18, 0)), CAST(1200000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (3, 1, 6, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (4, 1, 5, 1, CAST(225000 AS Decimal(18, 0)), CAST(225000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (5, 2, 4, 1, CAST(125000 AS Decimal(18, 0)), CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 2, 6, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (7, 2, 8, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (8, 2, 10, 1, CAST(725000 AS Decimal(18, 0)), CAST(725000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (9, 2, 12, 1, CAST(400000 AS Decimal(18, 0)), CAST(400000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 3, 5, 1, CAST(225000 AS Decimal(18, 0)), CAST(225000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 3, 7, 1, CAST(300000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (12, 3, 9, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (13, 3, 11, 1, CAST(215000 AS Decimal(18, 0)), CAST(215000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (14, 4, 3, 1, CAST(300000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (15, 4, 4, 1, CAST(125000 AS Decimal(18, 0)), CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (16, 4, 5, 1, CAST(225000 AS Decimal(18, 0)), CAST(225000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (17, 5, 4, 1, CAST(125000 AS Decimal(18, 0)), CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (18, 5, 5, 1, CAST(225000 AS Decimal(18, 0)), CAST(225000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (19, 5, 6, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (20, 5, 7, 1, CAST(300000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (25, 6, 9, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (26, 6, 7, 1, CAST(300000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (27, 6, 6, 1, CAST(325000 AS Decimal(18, 0)), CAST(325000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (28, 6, 3, 1, CAST(300000 AS Decimal(18, 0)), CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (29, 6, 11, 1, CAST(215000 AS Decimal(18, 0)), CAST(215000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (1, CAST(N'2021-05-23T21:14:47.340' AS DateTime), 1, N'Khánh Vinh', N'0334141300', N'Lâm Đồng', N'admin', NULL, CAST(1687500 AS Decimal(18, 0)), CAST(0.10 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (2, CAST(N'2021-05-23T21:16:56.853' AS DateTime), 1, N'Vinh', N'0334141300', N'Đà Lạt', N'admin', NULL, CAST(1615000 AS Decimal(18, 0)), CAST(0.15 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (3, CAST(N'2021-05-23T21:18:26.107' AS DateTime), 1, N'Khánh', N'0334141300', N'Đà Lạt', N'admin', NULL, CAST(852000 AS Decimal(18, 0)), CAST(0.20 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (4, CAST(N'2021-05-23T21:31:04.503' AS DateTime), 1, N'Vinh', N'0334141300', N'', N'admin', NULL, CAST(617500 AS Decimal(18, 0)), CAST(0.05 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (5, CAST(N'2021-05-23T21:32:11.340' AS DateTime), 0, N'Vinh Vinh', N'0334141300', N'', N'admin', NULL, CAST(828750 AS Decimal(18, 0)), CAST(0.15 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [NgayLap], [TrangThai], [TenKhachHang], [SoDienThoai], [DiaChi], [MaTaiKhoan], [SoLuong], [TongTien], [GiamGia]) VALUES (6, CAST(N'2021-05-23T21:34:10.000' AS DateTime), 1, N'Khánh Vinh', N'0334141300', N'', N'admin', NULL, CAST(1465000 AS Decimal(18, 0)), CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (1, N'Đồ chơi trí tuệ', N'Mọi độ tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (2, N'Đồ chơi phát nhạc', N'Mọi độ tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (3, N'Đồ chơi xe công trình', N'6-11 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (4, N'Đồ chơi máy bay, tên lửa', N'6-11 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (5, N'Đồ chơi thủ công', N'3-6 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (6, N'Đồ chơi đóng vai', N'1-3 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (7, N'Đồ chơi ảo thuật', N'6-11 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (8, N'Đồ chơi dưới nước', N'3-6 tuổi')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MoTa]) VALUES (9, N'hihi', N'ádasd
ád
ád
á
dá')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (1, N'Cờ logic', 1, 100, CAST(275000 AS Decimal(18, 0)), N'Chất liệu: gỗ tự nhiên, sơn an toàn')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (2, N'Rubik 3x3x3', 1, 100, CAST(125000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (3, N'Bộ rút gỗ', 1, 50, CAST(300000 AS Decimal(18, 0)), N'Chất liệu: gỗ tự nhiên, sơn an toàn')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (4, N'Đàn Doraemon', 2, 120, CAST(125000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (5, N'Chú chó phát nhạc', 2, 100, CAST(225000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (6, N'Điện thoại phát nhạc', 2, 75, CAST(325000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (7, N'Xe ben mô hình', 3, 80, CAST(300000 AS Decimal(18, 0)), N'Chất liệu: kim loại')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (8, N'Xe cần cầu mô hình', 3, 80, CAST(325000 AS Decimal(18, 0)), N'Chất liệu: kim loại')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (9, N'Máy múc mô hình', 3, 80, CAST(325000 AS Decimal(18, 0)), N'Chất liệu: kim loại')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (10, N'Máy bay điều khiển', 4, 30, CAST(725000 AS Decimal(18, 0)), N'Chất liệu: nhựa dẻo')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (11, N'Trực thăng phát sáng', 4, 70, CAST(215000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (12, N'Phi thuyền Start War', 4, 30, CAST(400000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (13, N'Bộ cắt giấy thủ công', 5, 45, CAST(125000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (14, N'Màu sáp 24 màu', 5, 30, CAST(75000 AS Decimal(18, 0)), N'Chất liệu: 100% Hữu cơ tự nhiên')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (15, N'Dụng cụ bác sĩ', 6, 20, CAST(175000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (16, N'Dụng cụ nấu ăn', 6, 35, CAST(150000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (17, N'Dụng cụ sửa xe', 6, 20, CAST(200000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (18, N'Đĩa bay ảo thuật', 7, 50, CAST(75000 AS Decimal(18, 0)), N'Chất liệu: giấy')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (19, N'Đồng tiền ma thuật', 7, 40, CAST(100000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (20, N'Chiếc ly thần kỳ', 7, 50, CAST(125000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (21, N'Bạch tuộc phun nước', 8, 40, CAST(50000 AS Decimal(18, 0)), N'Chất liệu: cao su')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (22, N'Cá bơi tự động', 8, 40, CAST(50000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [LoaiSanPham], [SoLuong], [DonGia], [Mota]) VALUES (23, N'Rùa vặn cót', 8, 40, CAST(50000 AS Decimal(18, 0)), N'Chất liệu: nhựa cao cấp')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [HoTen], [Groups]) VALUES (N'admin', N'1', N'Phạm Quốc Anh', 1)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [HoTen], [Groups]) VALUES (N'anhthu', N'thuiuminh', N'Trần Diệu Anh Thư', 2)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [HoTen], [Groups]) VALUES (N'nhatminh', N'minhminh', N'Nguyen Huu Nhat Minh', 2)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [HoTen], [Groups]) VALUES (N'vinhvinh', NULL, N'Vinh Khánh', 2)
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_SoLuong]  DEFAULT ((0)) FOR [SoLuong]
GO
