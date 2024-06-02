﻿namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("GIAMGIA")]
    public partial class GIAMGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAMGIA()
        {
            CHITIETGIAMGIAs = new HashSet<CHITIETGIAMGIA>();
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Giảm Giá")]
        public int MaGiamGia { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }

        [StringLength(30)]
        [DisplayName("Tên Giảm Giá")]
        public string TenGiamGia { get; set; }

        [DisplayName("Ngày Bắt Đầu")]
        public DateTime? NgayBatDau { get; set; }

        [DisplayName("Ngày Kết Thúc")]
        public DateTime? NgayKetThuc { get; set; }

        [DisplayName("Số Lượng")]
        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETGIAMGIA> CHITIETGIAMGIAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
