namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            CHITIETGIAMGIAs = new HashSet<CHITIETGIAMGIA>();
            CHITIETGIOHANGs = new HashSet<CHITIETGIOHANG>();
            DANHGIAs = new HashSet<DANHGIA>();
            KHOHANGs = new HashSet<KHOHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Sản Phẩm")]
        public int MaSanPham { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        [StringLength(30)]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        public string TenSanPham { get; set; }
        [DisplayName("Hình Ảnh")]
        public string HinhAnh { get; set; }

        [Column(TypeName = "numeric")]
        [Required(ErrorMessage = "Vui lòng nhập giá tiền.")]
        [DisplayName("Giá Tiền")]
        public decimal? GiaTien { get; set; }
        [DisplayName("Dung Tích")]
        public int? DungTich { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả.")]

        [Column(TypeName = "nvarchar")]
        [DisplayName("Mô Tả")]
      
        public string MoTa { get; set; }
        [DisplayName("Mã Danh Mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        public int MaDanhMuc { get; set; }
        [DisplayName("Mã Thương Hiệu")]
        [Required(ErrorMessage = "Vui lòng chọn thương hiệu.")]
        public int MaThuongHieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETGIAMGIA> CHITIETGIAMGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETGIOHANG> CHITIETGIOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHOHANG> KHOHANGs { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }
    }
}
