using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EStoreAPI.Models;

public partial class EstoreContext : DbContext
{
    public EstoreContext()
    {
    }

    public EstoreContext(DbContextOptions<EstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCode> TbCodes { get; set; }

    public virtual DbSet<TbPromoCode> TbPromoCodes { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=MyatKo;Database=EStore; User Id=sa; Password=a; Encrypt=False; Integrated Security=True");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Server=MyatKo;Database=EStore; User Id=sa; Password=a; Encrypt=False; Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCode>(entity =>
        {
            entity.ToTable("tbCode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codeno)
                .HasMaxLength(50)
                .HasColumnName("codeno");
            entity.Property(e => e.Isredeem).HasColumnName("isredeem");
        });

        modelBuilder.Entity<TbPromoCode>(entity =>
        {
            entity.ToTable("tbPromoCode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accesstime)
                .HasColumnType("datetime")
                .HasColumnName("accesstime");
            entity.Property(e => e.Evoucherid).HasColumnName("evoucherid");
            entity.Property(e => e.Phoneno)
                .HasMaxLength(50)
                .HasColumnName("phoneno");
            entity.Property(e => e.Promocode)
                .HasMaxLength(50)
                .HasColumnName("promocode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
