namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("HINHTHUCTHANHTOAN")]
    public partial class HINHTHUCTHANHTOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HINHTHUCTHANHTOAN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hình Thức Thanh Toán")]
        public int MaHinhThucThanhToan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên hình thức thanh toán.")]
        [StringLength(30)]
        [DisplayName("Tên Hình Thức Thanh Toán")]
        public string TenHinhThucThanhToan { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
