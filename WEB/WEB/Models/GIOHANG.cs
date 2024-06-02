namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("GIOHANG")]
    public partial class GIOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIOHANG()
        {
            CHITIETGIOHANGs = new HashSet<CHITIETGIOHANG>();
        }

        [Key]
        [StringLength(10)]
        public string MaGioHang { get; set; }

        public int? ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETGIOHANG> CHITIETGIOHANGs { get; set; }
    }
}
