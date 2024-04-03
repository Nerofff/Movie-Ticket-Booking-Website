namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lich_chieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lich_chieu()
        {
            Lich_chieu_Gio_chieu = new HashSet<Lich_chieu_Gio_chieu>();
            Ves = new HashSet<Ve>();
        }

        [Key]
        public int id_lich_chieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_chieu { get; set; }

        public int? gia_ve { get; set; }

        public int? id_phim { get; set; }

        public int? id_phong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lich_chieu_Gio_chieu> Lich_chieu_Gio_chieu { get; set; }

        public virtual Phong Phong { get; set; }

        public virtual Phim Phim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
