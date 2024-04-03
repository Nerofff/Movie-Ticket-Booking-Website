namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            Lich_chieu = new HashSet<Lich_chieu>();
        }

        [Key]
        public int id_phong { get; set; }

        [StringLength(50)]
        public string ten_phong { get; set; }

        public int? id_rap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lich_chieu> Lich_chieu { get; set; }

        public virtual Rap Rap { get; set; }
    }
}
