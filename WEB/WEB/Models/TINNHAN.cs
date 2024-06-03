namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("TINNHAN")]
    public partial class TINNHAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Tin Nhắn")]
        public int MaTinNhan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        [StringLength(90)]
        [DisplayName("Họ Tên")]
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [StringLength(90)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [StringLength(20)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập nội dung.")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }

        [DisplayName("Mã Cửa Hàng")]
        public int MaCuaHang { get; set; }

        public virtual CUAHANG CUAHANG { get; set; }
    }
}
