using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OPCBusinessSolution.Models;

public partial class MonitorBucklandContext : DbContext
{
    public MonitorBucklandContext()
    {
    }

    public MonitorBucklandContext(DbContextOptions<MonitorBucklandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mbpedimento> Mbpedimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ContextConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mbpedimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_MBPedimento");

            entity.ToTable("MBPedimento");

            entity.Property(e => e.Caja)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClavePedimento)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cpfolios)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CPFolios");
            entity.Property(e => e.CruceSoia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CruceSOIA");
            entity.Property(e => e.Doda)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DODA");
            entity.Property(e => e.FechaCcp)
                .HasColumnType("datetime")
                .HasColumnName("FechaCCP");
            entity.Property(e => e.FechaRemesa).HasColumnType("datetime");
            entity.Property(e => e.Pedimento)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Referencia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Remesa)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sello)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TiempoAcgconfirmado)
                .HasColumnType("datetime")
                .HasColumnName("TiempoACGConfirmado");
            entity.Property(e => e.TiempoReciboBgts)
                .HasColumnType("datetime")
                .HasColumnName("TiempoReciboBGTS");
            entity.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
