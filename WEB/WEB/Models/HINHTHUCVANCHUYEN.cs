namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("HINHTHUCVANCHUYEN")]
    public partial class HINHTHUCVANCHUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HINHTHUCVANCHUYEN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hình Thức Vận Chuyển")]

        public int MaHinhThucVanChuyen { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tên Hình Thức Vận Chuyển")]
        public string TenHinhThucVanChuyen { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Mô Tả")]

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
