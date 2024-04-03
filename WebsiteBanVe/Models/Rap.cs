namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rap")]
    public partial class Rap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rap()
        {
            Phongs = new HashSet<Phong>();
        }

        [Key]
        public int id_rap { get; set; }

        [StringLength(50)]
        public string ten_rap { get; set; }

        [StringLength(100)]
        public string dia_chi { get; set; }

        [StringLength(50)]
        public string tai_khoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
