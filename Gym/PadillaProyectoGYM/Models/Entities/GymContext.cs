using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PadillaProyectoGYM.Models.Entities;

public partial class GymContext : DbContext
{
    public GymContext()
    {
    }

    public GymContext(DbContextOptions<GymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Subcategorias> Subcategorias { get; set; }

    public virtual DbSet<Tipoproducto> Tipoproducto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=gym;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.HasIndex(e => e.IdSubCategoria, "IdSubCategoria");

            entity.HasIndex(e => e.IdTipo, "IdTipo");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(6, 2);
            entity.Property(e => e.Stock).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("productos_ibfk_1");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdSubCategoria)
                .HasConstraintName("productos_ibfk_2");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("productos_ibfk_3");
        });

        modelBuilder.Entity<Subcategorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subcategorias");

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.Property(e => e.NombreSub).HasMaxLength(30);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Subcategorias)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("subcategorias_ibfk_1");
        });

        modelBuilder.Entity<Tipoproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipoproducto");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Tipo).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
