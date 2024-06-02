namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("CHITIETGIOHANG")]
    public partial class CHITIETGIOHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaGioHang { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Giaban { get; set; }

        public virtual GIOHANG GIOHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
