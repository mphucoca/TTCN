namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("TINTUC")]
    public partial class TINTUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINTUC()
        {
            BINHLUANs = new HashSet<BINHLUAN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Tin Tức")]

        public int MaTinTuc { get; set; }

        [StringLength(100)]
        [DisplayName("Tiêu Đề")]

        public string TieuDe { get; set; }
        [DisplayName("Nội Dung")]

        [Column(TypeName = "nvarchar")]
        public string NoiDung { get; set; }

        [StringLength(20)]
        [DisplayName("Hình Ảnh")]

        public string HinhAnh { get; set; }
        [DisplayName("Thời Gian")]


        public DateTime? ThoiGian { get; set; }

        [DisplayName("Mã Nhân Viên")]

        public int MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
