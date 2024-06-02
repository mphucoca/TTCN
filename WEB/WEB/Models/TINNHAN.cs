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

        [StringLength(90)]
        [DisplayName("Họ Tên")]
        public string Hoten { get; set; }

        [StringLength(90)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(20)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }

        [DisplayName("Mã Cửa Hàng")]
        public int MaCuaHang { get; set; }

        public virtual CUAHANG CUAHANG { get; set; }
    }
}
