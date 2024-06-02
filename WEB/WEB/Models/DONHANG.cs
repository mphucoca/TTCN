namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        public DateTime? NgayDatHang { get; set; }

        [Column(TypeName = "nvarchar")]
        public string DiaChiGiao { get; set; }

        [Column(TypeName = "nvarchar")]
        public string GhiChu { get; set; }

        [Column(TypeName = "nvarchar")]
        public string TinhTrangThanhToan { get; set; }

        [Column(TypeName = "nvarchar")]

        public string TinhTrangGiaoHang { get; set; }

        public int ID { get; set; }

        public int MaHinhThucThanhToan { get; set; }

        public int MaHinhThucVanChuyen { get; set; }

        public int? MaGiamGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public virtual GIAMGIA GIAMGIA { get; set; }

        public virtual HINHTHUCTHANHTOAN HINHTHUCTHANHTOAN { get; set; }

        public virtual HINHTHUCVANCHUYEN HINHTHUCVANCHUYEN { get; set; }
    }
}
