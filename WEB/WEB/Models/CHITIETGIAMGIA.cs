namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("CHITIETGIAMGIA")]
    public partial class CHITIETGIAMGIA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Sản Phẩm")]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Giảm Giá")]
        public int MaGiamGia { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Mức Giảm Giá")]
        public decimal? MucGiamGia { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Giá Mua")]
        public decimal? Giamua { get; set; }

        public virtual GIAMGIA GIAMGIA { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
