namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gio_Chieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gio_Chieu()
        {
            Lich_chieu_Gio_chieu = new HashSet<Lich_chieu_Gio_chieu>();
        }

        [Key]
        public int id_gio_chieu { get; set; }

        public TimeSpan? gio_bat_dau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lich_chieu_Gio_chieu> Lich_chieu_Gio_chieu { get; set; }
    }
}
