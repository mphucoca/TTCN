﻿namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ.")]
        [StringLength(30)]
       
        [DisplayName("Họ")]

        public string Ho { get; set; }
        [DisplayName("Tên")]
        [StringLength(30)]
        [Required(ErrorMessage = "Vui lòng nhập tên.")]
        public string Ten { get; set; }
        [DisplayName("Email")]
        [StringLength(90)]
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [StringLength(90)]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Phân quyền")]
        public string PhanQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        public static implicit operator int(TAIKHOAN v)
        {
            throw new NotImplementedException();
        }
    }
}
