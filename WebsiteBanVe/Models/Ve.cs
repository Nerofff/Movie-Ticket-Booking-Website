namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ve")]
    public partial class Ve
    {
        [Key]
        public int id_ve { get; set; }

        public string so_ghe_ngoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_mua_ve { get; set; }

        [StringLength(128)]
        public string id_user { get; set; }

        public int? id_lich_chieu { get; set; }

        public TimeSpan? Gio_Chieu { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Lich_chieu Lich_chieu { get; set; }
    }
}
