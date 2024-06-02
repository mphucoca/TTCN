namespace WEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;


    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Bình Luận")]
        public int MaBinhLuan { get; set; }

        [Column(TypeName = "nvarchar")]
        [DisplayName("Nội Dung")]
        public string NoiDung { get; set; }

        [StringLength(90)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [StringLength(90)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mã Tin Tức")]
        public int MaTinTuc { get; set; }

        public virtual TINTUC TINTUC { get; set; }
    }
}
