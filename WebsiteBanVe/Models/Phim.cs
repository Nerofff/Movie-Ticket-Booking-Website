namespace WebsiteBanVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            Lich_chieu = new HashSet<Lich_chieu>();
            Phim_DienVien = new HashSet<Phim_DienVien>();
            Phim_Loaiphim = new HashSet<Phim_Loaiphim>();
        }

        [Key]
        public int id_phim { get; set; }

        [StringLength(50)]
        public string ten_phim { get; set; }

        [StringLength(50)]
        public string tacgia { get; set; }

        [StringLength(255)]
        public string hinhanh { get; set; }

        [StringLength(2000)]
        public string mo_ta { get; set; }

        [StringLength(255)]
        public string trailer { get; set; }

        public int? thoi_luong { get; set; }

        public int? id_hang_phim { get; set; }

        public int? Do_Tuoi { get; set; }

        public bool? trang_Thai { get; set; }

        public virtual Hang_phim Hang_phim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lich_chieu> Lich_chieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim_DienVien> Phim_DienVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim_Loaiphim> Phim_Loaiphim { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
