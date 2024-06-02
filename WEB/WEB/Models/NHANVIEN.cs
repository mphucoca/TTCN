namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            TINTUCs = new HashSet<TINTUC>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Nhân Viên")]
        public int MaNhanVien { get; set; }

        [StringLength(90)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [StringLength(20)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [StringLength(90)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [DisplayName("Mã Cửa Hàng")]
        public int MaCuaHang { get; set; }

        public virtual CUAHANG CUAHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUCs { get; set; }
    }
}
