 use master

 create database NIPER_final
 
 use NIPER_final
CREATE TABLE [SANPHAM] (
	[MaSanPham] INT NOT NULL PRIMARY KEY,
	[TenSanPham] NVARCHAR(30) NULL,
	[HinhAnh] NVARCHAR(MAX) NULL, -- Thay đổi kiểu dữ liệu của HinhAnh
	[GiaTien] NUMERIC(10,0) NULL,
	[DungTich] INT NULL,
	[MoTa] TEXT NULL,
	[MaDanhMuc] INT NOT NULL,
	[MaThuongHieu] INT NOT NULL
);

CREATE TABLE [CUAHANG] (
	[MaCuaHang] INT NOT NULL PRIMARY KEY,
	[TenCuaHang] NVARCHAR(90) NULL,
	[DiaChi] NVARCHAR(90) NULL,
	[SoDienThoai] CHAR(20) NULL
);

CREATE TABLE [KHOHANG] (
	[MaCuaHang] INT NOT NULL,
	[MaSanPham] INT NOT NULL,
	[SoLuong] INT NULL,
	PRIMARY KEY  ([MaCuaHang],[MaSanPham]),
	FOREIGN KEY([MaCuaHang]) REFERENCES [CUAHANG] ([MaCuaHang]), -- Thêm khóa ngoại
	FOREIGN KEY([MaSanPham]) REFERENCES [SANPHAM] ([MaSanPham]) -- Thêm khóa ngoại
);

CREATE TABLE [DANHMUC] (
	[MaDanhMuc] INT NOT NULL PRIMARY KEY,
	[TenDanhMuc] NVARCHAR(40) NULL
);

CREATE TABLE [THUONGHIEU] (
	[MaThuongHieu] INT NOT NULL PRIMARY KEY,
	[TenThuongHieu] NVARCHAR(30) NULL
);
CREATE TABLE [TAIKHOAN] (
	[ID] INT NOT NULL PRIMARY KEY,
	[Ho] NVARCHAR(30) NULL,
	[Ten] NVARCHAR(30) NULL,
	[Email] CHAR(90) NULL,
	[SDT] CHAR(20) NULL,
	[MatKhau] CHAR(90) NULL,
	[PhanQuyen] CHAR(10) NOT NULL
);
CREATE TABLE [HINHTHUCTHANHTOAN] (
	[MaHinhThucThanhToan] INT NOT NULL PRIMARY KEY,
	[TenHinhThucThanhToan] NVARCHAR(30) NULL,
	[MoTa] TEXT NULL
);
CREATE TABLE [HINHTHUCVANCHUYEN] (
	[MaHinhThucVanChuyen] INT NOT NULL PRIMARY KEY,
	[TenHinhThucVanChuyen] NVARCHAR(20) NOT NULL,
	[MoTa] TEXT NULL
);
Create table [GIOHANG] (
	[MaGioHang] Char(10) NOT NULL,
	[ID] Integer NULL,
Primary Key  ([MaGioHang])
) 
go

CREATE TABLE [CHITIETGIOHANG] (
	[MaSanPham] INT NOT NULL,
	[MaGioHang] CHAR(10) NOT NULL,
	[SoLuong] INT NULL,
	[Giaban] NUMERIC(10,0) NULL,
	PRIMARY KEY  ([MaSanPham],[MaGioHang]),
	FOREIGN KEY([MaSanPham]) REFERENCES [SANPHAM] ([MaSanPham]), -- Thêm khóa ngoại
	FOREIGN KEY([MaGioHang]) REFERENCES [GIOHANG] ([MaGioHang]) -- Thêm khóa ngoại
);
CREATE TABLE [DONHANG] (
	[MaDonHang] INT NOT NULL PRIMARY KEY,
	[NgayDatHang] DATETIME NULL,
	[DiaChiGiao] TEXT NULL,
	[GhiChu] TEXT NULL,
	[TinhTrangThanhToan] TEXT NULL,
	[TinhTrangGiaoHang] TEXT NULL,
	[ID] INT NOT NULL,
	[MaHinhThucThanhToan] INT NOT NULL,
	[MaHinhThucVanChuyen] INT NOT NULL,
	FOREIGN KEY([ID]) REFERENCES [TAIKHOAN] ([ID]), -- Thêm khóa ngoại
	FOREIGN KEY([MaHinhThucThanhToan]) REFERENCES [HINHTHUCTHANHTOAN] ([MaHinhThucThanhToan]), -- Thêm khóa ngoại
	FOREIGN KEY([MaHinhThucVanChuyen]) REFERENCES [HINHTHUCVANCHUYEN] ([MaHinhThucVanChuyen]) -- Thêm khóa ngoại
);

CREATE TABLE [CHITIETDONHANG] (
	[MaSanPham] INT NOT NULL,
	[MaDonHang] INT NOT NULL,
	[SoLuongMua] INT NULL,
	[GiaMua] NUMERIC(10,0) NULL,
	PRIMARY KEY  ([MaSanPham],[MaDonHang]),
	FOREIGN KEY([MaSanPham]) REFERENCES [SANPHAM] ([MaSanPham]), -- Thêm khóa ngoại
	FOREIGN KEY([MaDonHang]) REFERENCES [DONHANG] ([MaDonHang]) -- Thêm khóa ngoại
);
go





CREATE TABLE [GIAMGIA] (
	[MaGiamGia] INT NOT NULL PRIMARY KEY,
	[MoTa] TEXT NULL,
	[TenGiamGia] NVARCHAR(30) NULL,
	[NgayBatDau] DATETIME NULL,
	[NgayKetThuc] DATETIME NULL,
	[SoLuong] INT NULL
);
 
 ALTER TABLE DONHANG
ADD MaGiamGia INT NULL,
FOREIGN KEY(MaGiamGia) REFERENCES GIAMGIA(MaGiamGia);
CREATE TABLE [CHITIETGIAMGIA] (
	[MaSanPham] INT NOT NULL,
	[MaGiamGia] INT NOT NULL,
	[MucGiamGia] NUMERIC(18,0) NULL,
	[Giamua] NUMERIC(10,0) NULL,
	PRIMARY KEY  ([MaSanPham],[MaGiamGia]),
	FOREIGN KEY([MaSanPham]) REFERENCES [SANPHAM] ([MaSanPham]), -- Thêm khóa ngoại
	FOREIGN KEY([MaGiamGia]) REFERENCES [GIAMGIA] ([MaGiamGia]) -- Thêm khóa ngoại
);

CREATE TABLE [DANHGIA] (
	[MaDanhGiaSanPham] INT NOT NULL PRIMARY KEY,
	[HoTen] NVARCHAR(50) NULL,
	[NoiDungDanhGia] TEXT NULL,
	[Email] CHAR(90) NULL,
	[MaSanPham] INT NOT NULL,
	[ThoiGian] DATETIME NULL,
	[HinhAnh] NVARCHAR(90) NULL,
	FOREIGN KEY([MaSanPham]) REFERENCES [SANPHAM] ([MaSanPham]) -- Thêm khóa ngoại
);

CREATE TABLE [NHANVIEN] (
	[MaNhanVien] INT NOT NULL PRIMARY KEY,
	[HoTen] NVARCHAR(90) NULL,
	[SDT] CHAR(20) NULL,
	[DiaChi] NVARCHAR(90) NULL,
	[MaCuaHang] INT NOT NULL,
	FOREIGN KEY([MaCuaHang]) REFERENCES [CUAHANG] ([MaCuaHang]), -- Thêm khóa ngoại
 
);

CREATE TABLE [TINTUC] (
	[MaTinTuc] INT NOT NULL PRIMARY KEY,
	[TieuDe] NVARCHAR(100) NULL,
	[NoiDung] TEXT NULL,
	[HinhAnh] CHAR(20) NULL,
	[ThoiGian] DATETIME NULL,
	[MaNhanVien] INT NOT NULL,
	FOREIGN KEY([MaNhanVien]) REFERENCES [NHANVIEN] ([MaNhanVien]) -- Thêm khóa ngoại
);

CREATE TABLE [BINHLUAN] (
	[MaBinhLuan] INT NOT NULL PRIMARY KEY,
	[NoiDung] TEXT NULL,
	[HoTen] NVARCHAR(90) NULL,
	[Email] CHAR(90) NULL,
	[MaTinTuc] INT NOT NULL,
	FOREIGN KEY([MaTinTuc]) REFERENCES [TINTUC] ([MaTinTuc]) -- Thêm khóa ngoại
);

CREATE TABLE [TINNHAN] (
	[MaTinNhan] INT NOT NULL PRIMARY KEY,
	[Hoten] NVARCHAR(90) NULL,
	[Email] CHAR(90) NULL,
	[SDT] CHAR(20) NULL,
	[NoiDung] NTEXT NULL,
	[MaCuaHang] INT NOT NULL,
	FOREIGN KEY([MaCuaHang]) REFERENCES [CUAHANG] ([MaCuaHang]) -- Thêm khóa ngoại
);


ALTER TABLE KHOHANG
ADD FOREIGN KEY(MaCuaHang) REFERENCES CUAHANG(MaCuaHang);
 
 ALTER TABLE DONHANG
ADD FOREIGN KEY(ID) REFERENCES TAIKHOAN(ID);
 
 ALTER TABLE CHITIETDONHANG
ADD FOREIGN KEY(MaSanPham) REFERENCES SANPHAM(MaSanPham);
 

 ALTER TABLE NHANVIEN
ADD FOREIGN KEY(MaCuaHang) REFERENCES CUAHANG(MaCuaHang);


ALTER TABLE TINTUC
ADD FOREIGN KEY(MaNhanVien) REFERENCES NHANVIEN(MaNhanVien);

ALTER TABLE BINHLUAN
ADD FOREIGN KEY(MaTinTuc) REFERENCES TINTUC(MaTinTuc);

ALTER TABLE TINNHAN
ADD FOREIGN KEY(MaCuaHang) REFERENCES CUAHANG(MaCuaHang);



-- Thay đổi kiểu dữ liệu của cột MoTa trong bảng SANPHAM
ALTER TABLE SANPHAM
ALTER COLUMN MoTa NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột MoTa trong bảng HINHTHUCTHANHTOAN
ALTER TABLE HINHTHUCTHANHTOAN
ALTER COLUMN MoTa NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột MoTa trong bảng HINHTHUCVANCHUYEN
ALTER TABLE HINHTHUCVANCHUYEN
ALTER COLUMN MoTa NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột DiaChiGiao trong bảng DONHANG
ALTER TABLE DONHANG
ALTER COLUMN DiaChiGiao NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột GhiChu trong bảng DONHANG
ALTER TABLE DONHANG
ALTER COLUMN GhiChu NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột TinhTrangThanhToan trong bảng DONHANG
ALTER TABLE DONHANG
ALTER COLUMN TinhTrangThanhToan NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột TinhTrangGiaoHang trong bảng DONHANG
ALTER TABLE DONHANG
ALTER COLUMN TinhTrangGiaoHang NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột MoTa trong bảng GIAMGIA
ALTER TABLE GIAMGIA
ALTER COLUMN MoTa NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột NoiDungDanhGia trong bảng DANHGIA
ALTER TABLE DANHGIA
ALTER COLUMN NoiDungDanhGia NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột NoiDung trong bảng TINTUC
ALTER TABLE TINTUC
ALTER COLUMN NoiDung NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột NoiDung trong bảng BINHLUAN
ALTER TABLE BINHLUAN
ALTER COLUMN NoiDung NVARCHAR(MAX);

-- Thay đổi kiểu dữ liệu của cột NoiDung trong bảng TINNHAN
ALTER TABLE TINNHAN
ALTER COLUMN NoiDung NVARCHAR(MAX);

 -- Nhập dữ liệu cho bảng DANHMUC
INSERT INTO DANHMUC (MaDanhMuc, TenDanhMuc)
VALUES 
    (1, N'Nước hoa nam'),
    (2, N'Nước hoa nữ'),
    (3, N'Nước hoa unisex');

-- Nhập dữ liệu cho bảng THUONGHIEU
INSERT INTO THUONGHIEU (MaThuongHieu, TenThuongHieu)
VALUES 
    (1, N'Chanel'),
    (2, N'Dior'),
    (3, N'Gucci');

-- Nhập dữ liệu cho bảng SANPHAM
INSERT INTO SANPHAM (MaSanPham, TenSanPham, HinhAnh, GiaTien, DungTich, MoTa, MaDanhMuc, MaThuongHieu)
VALUES 
    (1, N'Chanel Chance Eau Tendre', N'1.jpg', 1000000, 50, N'Mô tả nước hoa Chanel Chance Eau Tendre', 2, 1),
    (2, N'Dior Sauvage', N'4.jpg', 1200000, 100, N'Mô tả nước hoa Dior Sauvage', 1, 2),
    (3, N'Gucci Bloom', N'2.jpg', 800000, 75, N'Mô tả nước hoa Gucci Bloom', 2, 3);
 
-- Nhập dữ liệu cho bảng CUAHANG
INSERT INTO CUAHANG (MaCuaHang, TenCuaHang, DiaChi, SoDienThoai)
VALUES 
    (1, N'Cửa hàng nước hoa A', N'123 Đường ABC, Quận 1, Thành phố Hồ Chí Minh', '0123456789'),
    (2, N'Cửa hàng nước hoa B', N'456 Đường XYZ, Quận 2, Thành phố Hồ Chí Minh', '0987654321');

-- Nhập dữ liệu cho bảng KHOHANG
INSERT INTO KHOHANG (MaCuaHang, MaSanPham, SoLuong)
VALUES 
    (1, 1, 50),
    (1, 2, 100),
    (2, 3, 75);

-- Nhập dữ liệu cho bảng HINHTHUCTHANHTOAN
INSERT INTO HINHTHUCTHANHTOAN (MaHinhThucThanhToan, TenHinhThucThanhToan, MoTa)
VALUES 
    (1, N'Thanh toán khi nhận hàng', N'Thanh toán sau khi nhận hàng tại cửa hàng'),
    (2, N'Thanh toán qua thẻ tín dụng', N'Thanh toán trực tuyến qua thẻ tín dụng');

-- Nhập dữ liệu cho bảng TAIKHOAN
INSERT INTO TAIKHOAN (ID, Ho, Ten, Email, SDT, MatKhau, PhanQuyen)
VALUES 
    (8, N'Nguyễn', N'Văn A', 'nguyenvana@example.com', '0123456789', 'matkhau123', 'user'),
	 (9, N'Đào', N'Mạnh Phúc', 'mphucoca@gmail.com', '0123456789', 'admin', 'admin'),
    (10, N'Trần', N'Thị B', 'trandatb@example.com', '0987654321', '123456', 'admin');
-- Nhập dữ liệu minh họa cho bảng NHANVIEN
INSERT INTO NHANVIEN (MaNhanVien, HoTen, SDT, DiaChi, MaCuaHang)
VALUES
    (1, N'Trần Văn A', '0123456789', N'Hà Nội', 1),
    (2, N'Nguyễn Thị B', '0987654321', N'Hồ Chí Minh', 2),
    (3, N'Lê Văn C', '0369876543', N'Đà Nẵng', 1);
-- Nhập dữ liệu minh họa cho bảng HINHTHUCVANCHUYEN
INSERT INTO HINHTHUCVANCHUYEN (MaHinhThucVanChuyen, TenHinhThucVanChuyen, MoTa)
VALUES
    (1, N'Giao hàng tận nơi', N'Giao hàng trực tiếp đến địa chỉ khách hàng'),
    (2, N'Nhận tại cửa hàng', N'Khách hàng đến cửa hàng để nhận hàng');
 
 


 
 

-- Nhập dữ liệu cho bảng TINTUC
INSERT INTO TINTUC (MaTinTuc, TieuDe, NoiDung, HinhAnh, ThoiGian, MaNhanVien)
VALUES 
    (1, N'Nước hoa Chanel mới ra mắt', N'Chanel vừa ra mắt dòng nước hoa mới...', N'TT001.jpg', GETDATE(), 1),
    (2, N'Giảm giá lớn cho dịp cuối năm', N'Trên cửa hàng sẽ có chương trình giảm giá...', N'TT002.jpg', GETDATE(), 2);

-- Nhập dữ liệu cho bảng BINHLUAN
INSERT INTO BINHLUAN (MaBinhLuan, NoiDung, HoTen, Email, MaTinTuc)
VALUES 
    (1, N'Bài viết rất thú vị!', N'Nguyễn Văn A', 'nguyenvana@example.com', 1),
    (2, N'Bài viết chưa rõ ràng lắm', N'Trần Thị B', 'trandatb@example.com', 2);

INSERT INTO TINNHAN (MaTinNhan, HoTen, Email, SDT, NoiDung, MaCuaHang)
VALUES
    (1, N'Nguyễn Văn X', 'nguyenvanx@example.com', '0123456789', N'Hỏi về sản phẩm', 1),
    (2, N'Trần Thị Y', 'tranthiy@example.com', '0987654321', N'Yêu cầu hỗ trợ kỹ thuật', 2),
    (3, N'Lê Văn Z', 'levanz@example.com', '0369876543', N'Thắc mắc về chính sách đổi trả', 1);


	-- Nhập dữ liệu minh họa cho bảng GIOHANG
INSERT INTO GIOHANG (MaGioHang, ID)
VALUES
    ('GH001', 1),
    ('GH002', 2),
    ('GH003', 3);
-- Nhập dữ liệu minh họa cho bảng CHITIETGIOHANG
INSERT INTO CHITIETGIOHANG (MaSanPham, MaGioHang, SoLuong, Giaban)
VALUES
    (1, 'GH001', 2, 500000),
    (2, 'GH002', 1, 700000),
    (3, 'GH003', 3, 350000);
 -- Nhập dữ liệu minh họa cho bảng DANHGIA
INSERT INTO DANHGIA (MaDanhGiaSanPham, HoTen, NoiDungDanhGia, Email, MaSanPham, ThoiGian, HinhAnh)
VALUES
     
  
    (3, N'Lê Văn C', N'Sản phẩm không như mô tả.', 'levanc@example.com', 3, '2024-05-09', NULL);

	-- Nhập dữ liệu cho bảng GIAMGIA
INSERT INTO GIAMGIA (MaGiamGia, MoTa, TenGiamGia, NgayBatDau, NgayKetThuc, SoLuong)
VALUES 
    (1, N'Giảm giá 10% cho mùa hè', N'GIAM10', '2024-01-01', '2024-08-31', 100),
    (2, N'Giảm giá 20% cho mùa đông', N'GIAM20', '2024-01-01', '2025-02-28', 50),
    (3, N'Khuyến mãi đặc biệt Black Friday', N'BLACKFRIDAY', '2024-01-26', '2024-11-30', 200);

-- Nhập dữ liệu cho bảng DONHANG
INSERT INTO DONHANG (MaDonHang, NgayDatHang, DiaChiGiao, GhiChu, TinhTrangThanhToan, TinhTrangGiaoHang, ID, MaHinhThucThanhToan, MaHinhThucVanChuyen, MaGiamGia)
VALUES 
    (1, GETDATE(), N'123 Đường ABC, Quận 1, Thành phố Hồ Chí Minh', N'', N'Chưa thanh toán', N'Đang chờ xử lý', 1, 1, 1, 1),
    (2, GETDATE(), N'456 Đường XYZ, Quận 2, Thành phố Hồ Chí Minh', N'', N'Đã thanh toán', N'Đã giao hàng', 2, 2, 2, 1);
	 
-- Nhập dữ liệu cho bảng CHITIETDONHANG
INSERT INTO CHITIETDONHANG (MaSanPham, MaDonHang, SoLuongMua, GiaMua)
VALUES 
    (1, 1, 1, 1000000),
    (2, 1, 2, 2400000);
 -- Nhập dữ liệu cho bảng SANPHAM
INSERT INTO SANPHAM (MaSanPham, TenSanPham, HinhAnh, GiaTien, DungTich, MoTa, MaDanhMuc, MaThuongHieu)
VALUES 
    
    (5, N'Sản phẩm 5', N'4.jpg', 800000, 75, N'Mô tả sản phẩm 5', 2, 2),
    (6, N'Sản phẩm 6', N'3.jpg', 1500000, 50, N'Mô tả sản phẩm 6', 3, 3),
    (7, N'Sản phẩm 7', N'5.jpg', 900000, 150, N'Mô tả sản phẩm 7', 1, 1),
    (8, N'Sản phẩm 8', N'6.jpg', 1100000, 200, N'Mô tả sản phẩm 8', 2, 2),
    (9, N'Sản phẩm 9', N'7.jpg', 950000, 125, N'Mô tả sản phẩm 9', 3, 3),
    (10, N'Sản phẩm 10', N'8.jpg', 1300000, 100, N'Mô tả sản phẩm 10', 1, 1),
    (11, N'Sản phẩm 11', N'9.jpg', 750000, 75, N'Mô tả sản phẩm 11', 2, 2),
    (12, N'Sản phẩm 12', N'14.jpg', 1400000, 50, N'Mô tả sản phẩm 12', 3, 3),
    (13, N'Sản phẩm 13', N'13.jpg', 800000, 150, N'Mô tả sản phẩm 13', 1, 1);


	-- thay đổi giá trị cho giảm giá
	-- Thêm dữ liệu cho bảng GIAMGIA
INSERT INTO GIAMGIA (MaGiamGia, MoTa, TenGiamGia, NgayBatDau, NgayKetThuc, SoLuong)
VALUES 
    (4, N'Khuyến mãi hè 2024', N'KMHE2024', '2024-01-01', '2025-08-31', 150),
    (5, N'Chương trình giảm giá mùa đông 2024', N'GMMĐ2024', '2024-1-01', '2025-02-28', 100),
    (6, N'Ưu đãi Black Friday 2024', N'BF2024', '2024-1-26', '2025-11-30', 200),
    (7, N'Giảm giá cuối năm', N'GGCN2024', '2024-1-15', '2025-12-31', 80),
    (8, N'Khuyến mãi đặc biệt Tết Nguyên Đán', N'TET2025', '2024-01-20', '2025-02-10', 120);

   -- Thêm nhiều bộ dữ liệu vào bảng CHITIETGIAMGIA
 INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (4, 8, 25, 200000);

INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (6, 8, 10, 100000);

INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (7, 8, 15, 50000);

INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (8, 8, 20, 75000);

INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (9, 8, 5, 25000);

INSERT INTO CHITIETGIAMGIA (MaSanPham, MaGiamGia, MucGiamGia, Giamua)
VALUES 
    (10, 8, 30, 300000);
 
   
    
 
 
    
 
