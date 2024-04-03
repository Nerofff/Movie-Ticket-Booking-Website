namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lich_chieu_Gio_chieu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_lich_chieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_gio_chieu { get; set; }

        [StringLength(10)]
        public string trangthai { get; set; }

        public virtual Gio_Chieu Gio_Chieu { get; set; }

        public virtual Lich_chieu Lich_chieu { get; set; }
    }
}
