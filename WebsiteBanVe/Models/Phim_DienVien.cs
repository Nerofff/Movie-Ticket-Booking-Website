namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phim_DienVien
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_phim { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dien_vien { get; set; }

        [StringLength(10)]
        public string vaidien { get; set; }

        public virtual Dien_Vien Dien_Vien { get; set; }

        public virtual Phim Phim { get; set; }
    }
}
