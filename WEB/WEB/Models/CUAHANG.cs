namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("CUAHANG")]
    public partial class CUAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUAHANG()
        {
            KHOHANGs = new HashSet<KHOHANG>();
            NHANVIENs = new HashSet<NHANVIEN>();
            TINNHANs = new HashSet<TINNHAN>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Cửa Hàng")]
        public int MaCuaHang { get; set; }

        [StringLength(90)]
        [DisplayName("Tên Cửa Hàng")]

        public string TenCuaHang { get; set; }

        [StringLength(90)]
        [DisplayName("Địa Chỉ")]

        public string DiaChi { get; set; }

        [StringLength(20)]
        [DisplayName("Số Điện Thoại")]

        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHOHANG> KHOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINNHAN> TINNHANs { get; set; }
    }
}
