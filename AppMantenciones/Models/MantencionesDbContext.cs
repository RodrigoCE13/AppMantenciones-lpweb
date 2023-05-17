using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppMantenciones.Models;

public partial class MantencionesDbContext : DbContext
{
    public MantencionesDbContext()
    {
    }

    public MantencionesDbContext(DbContextOptions<MantencionesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mantencion> Mantencions { get; set; }

    public virtual DbSet<MarcaVehiculo> MarcaVehiculos { get; set; }

    public virtual DbSet<Taller> Tallers { get; set; }

    public virtual DbSet<TipoMantencion> TipoMantencions { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-5HT9V8U; initial catalog=MantencionesDB; user id=sa;password=admin123;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mantencion>(entity =>
        {
            entity.ToTable("mantencion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTaller).HasColumnName("id_taller");
            entity.Property(e => e.IdTipoMantencion).HasColumnName("id_tipoMantencion");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Mantencions)
                .HasForeignKey(d => d.IdTaller)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mantencion_taller");

            entity.HasOne(d => d.IdTipoMantencionNavigation).WithMany(p => p.Mantencions)
                .HasForeignKey(d => d.IdTipoMantencion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mantencion_tipoMantencion");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Mantencions)
                .HasForeignKey(d => d.IdVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mantencion_vehiculo1");
        });

        modelBuilder.Entity<MarcaVehiculo>(entity =>
        {
            entity.ToTable("marcaVehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Taller>(entity =>
        {
            entity.ToTable("taller");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Fono)
                .HasMaxLength(50)
                .HasColumnName("fono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoMantencion>(entity =>
        {
            entity.ToTable("tipoMantencion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.ToTable("vehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMarcaVehiculo).HasColumnName("id_marcaVehiculo");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .HasColumnName("modelo");
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .HasColumnName("patente");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdMarcaVehiculoNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdMarcaVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vehiculo_marcaVehiculo1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
