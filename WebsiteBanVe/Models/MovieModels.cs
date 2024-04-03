using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebsiteBanVe.Models
{
    public partial class MovieModels : DbContext
    {
        public MovieModels()
            : base("name=MovieModels")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Dien_Vien> Dien_Vien { get; set; }
        public virtual DbSet<Gio_Chieu> Gio_Chieu { get; set; }
        public virtual DbSet<Hang_phim> Hang_phim { get; set; }
        public virtual DbSet<Lich_chieu> Lich_chieu { get; set; }
        public virtual DbSet<Lich_chieu_Gio_chieu> Lich_chieu_Gio_chieu { get; set; }
        public virtual DbSet<Loai_phim> Loai_phim { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<Phim_DienVien> Phim_DienVien { get; set; }
        public virtual DbSet<Phim_Loaiphim> Phim_Loaiphim { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<Rap> Raps { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Dien_Vien>()
                .Property(e => e.ten_dien_vien)
                .IsUnicode(false);

            modelBuilder.Entity<Hang_phim>()
                .Property(e => e.ten_hang_phim)
                .IsUnicode(false);

            modelBuilder.Entity<Hang_phim>()
                .HasMany(e => e.Phims)
                .WithOptional(e => e.Hang_phim)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Lich_chieu>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.Lich_chieu)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Loai_phim>()
                .Property(e => e.ten_loai_phim)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.mo_ta)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .Property(e => e.ten_phim)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .Property(e => e.tacgia)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.Lich_chieu)
                .WithOptional(e => e.Phim)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Phong>()
                .Property(e => e.ten_phong)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.Lich_chieu)
                .WithOptional(e => e.Phong)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Rap>()
                .Property(e => e.ten_rap)
                .IsUnicode(false);

            modelBuilder.Entity<Rap>()
                .Property(e => e.dia_chi)
                .IsUnicode(false);

            modelBuilder.Entity<Rap>()
                .Property(e => e.tai_khoan)
                .IsUnicode(false);

            modelBuilder.Entity<Rap>()
                .HasMany(e => e.Phongs)
                .WithOptional(e => e.Rap)
                .WillCascadeOnDelete();
        }
    }
}
