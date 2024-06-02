namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    [Table("DANHGIA")]
    public partial class DANHGIA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đánh Giá ")]
        public int MaDanhGiaSanPham { get; set; }

        [StringLength(50)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Nội Dung")]
        public string NoiDungDanhGia { get; set; }

        [StringLength(90)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mã Sản Phẩm")]
        public int MaSanPham { get; set; }

        [DisplayName("Thời Gian")]
        public DateTime? ThoiGian { get; set; }

        [StringLength(90)]
        [DisplayName("Hình Ảnh")]
        public string HinhAnh { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
