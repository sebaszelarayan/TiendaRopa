using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TiendaAPI.Models;

public partial class TiendaRopaContext : DbContext
{
    public TiendaRopaContext()
    {
    }

    public TiendaRopaContext(DbContextOptions<TiendaRopaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Color> Colores { get; set; }

    public virtual DbSet<Detalleventa> Detalleventa { get; set; }

    public virtual DbSet<Imagenesproducto> Imagenesproductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Talle> Talles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Variantesproducto> Variantesproductos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=TiendaRopa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("colores");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.CodigoHex).HasMaxLength(7);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Detalleventa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleventa");

            entity.HasIndex(e => e.VarianteId, "VarianteId");

            entity.HasIndex(e => e.VentaId, "VentaId");

            entity.Property(e => e.PrecioUnitario).HasPrecision(10, 2);

            entity.HasOne(d => d.Variante).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.VarianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleventa_ibfk_2");

            entity.HasOne(d => d.Venta).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("detalleventa_ibfk_1");
        });

        modelBuilder.Entity<Imagenesproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imagenesproducto");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.Property(e => e.ImagenUrl).HasMaxLength(500);
            entity.Property(e => e.Orden).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Producto).WithMany(p => p.Imagenesproductos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("imagenesproducto_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.CategoriaId, "CategoriaId");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Talle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("talles");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(10);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Rol)
                .HasDefaultValueSql("'Cliente'")
                .HasColumnType("enum('Admin','Cliente')");
        });

        modelBuilder.Entity<Variantesproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("variantesproducto");

            entity.HasIndex(e => e.ColorId, "ColorId");

            entity.HasIndex(e => new { e.ProductoId, e.TalleId, e.ColorId }, "ProductoId").IsUnique();

            entity.HasIndex(e => e.TalleId, "TalleId");

            entity.HasOne(d => d.Color).WithMany(p => p.Variantesproductos)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variantesproducto_ibfk_3");

            entity.HasOne(d => d.Producto).WithMany(p => p.Variantesproductos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("variantesproducto_ibfk_1");

            entity.HasOne(d => d.Talle).WithMany(p => p.Variantesproductos)
                .HasForeignKey(d => d.TalleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variantesproducto_ibfk_2");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Pendiente'")
                .HasColumnType("enum('Pendiente','Pagado','Enviado')");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("ventas_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
