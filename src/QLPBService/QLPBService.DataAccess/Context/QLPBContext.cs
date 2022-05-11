using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QLPBService.Domain.Entities;

#nullable disable

namespace QLPBService.DataAccess.Context
{
    public partial class QLPBContext : DbContext
    {
        public QLPBContext()
        {
        }

        public QLPBContext(DbContextOptions<QLPBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CongChucVienChuc> CongChucVienChucs { get; set; }
        public virtual DbSet<KhoiPhongBan> KhoiPhongBans { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TrinhDo> TrinhDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=tin123456;database=QLPB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.ToTable("ChucVu");

                entity.Property(e => e.TenChucVu)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CongChucVienChuc>(entity =>
            {
                entity.ToTable("CongChucVienChuc");

                entity.HasIndex(e => e.ChucVuId, "VC_CV");

                entity.HasIndex(e => e.PhongBanId, "VC_PB");

                entity.HasIndex(e => e.TrinhDoId, "VC_TD");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LaDaiDienPb).HasColumnName("LaDaiDienPB");

                entity.HasOne(d => d.ChucVu)
                    .WithMany(p => p.CongChucVienChucs)
                    .HasForeignKey(d => d.ChucVuId)
                    .HasConstraintName("CongChucVienChuc_ibfk_3");

                entity.HasOne(d => d.PhongBan)
                    .WithMany(p => p.CongChucVienChucs)
                    .HasForeignKey(d => d.PhongBanId)
                    .HasConstraintName("CongChucVienChuc_ibfk_1");

                entity.HasOne(d => d.TrinhDo)
                    .WithMany(p => p.CongChucVienChucs)
                    .HasForeignKey(d => d.TrinhDoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CongChucVienChuc_ibfk_4");
            });

            modelBuilder.Entity<KhoiPhongBan>(entity =>
            {
                entity.ToTable("KhoiPhongBan");

                entity.Property(e => e.TenKhoiPb)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("TenKhoiPB");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.ToTable("PhongBan");

                entity.HasIndex(e => e.KhoiPbid, "PB_KPB");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(255);

                entity.Property(e => e.KhoiPbid).HasColumnName("KhoiPBId");

                entity.Property(e => e.NganHang).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.Stk)
                    .HasMaxLength(255)
                    .HasColumnName("STK");

                entity.Property(e => e.TenPb)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("TenPB");

                entity.Property(e => e.Website).HasMaxLength(255);

                entity.HasOne(d => d.KhoiPb)
                    .WithMany(p => p.PhongBans)
                    .HasForeignKey(d => d.KhoiPbid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PhongBan_ibfk_1");
            });

            modelBuilder.Entity<TrinhDo>(entity =>
            {
                entity.ToTable("TrinhDo");

                entity.Property(e => e.CapBac)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.VietTat)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
