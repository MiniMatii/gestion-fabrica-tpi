using System;
using System.Collections.Generic;
using Alemana.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Alemana.Data.Repositorios;

public partial class DbAlemanaContext : DbContext
{
    public DbAlemanaContext()
    {
    }

    public DbAlemanaContext(DbContextOptions<DbAlemanaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Capacidad> Capacidads { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Consumolote> Consumolotes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Materiap> Materiaps { get; set; }

    public virtual DbSet<MateriapRecetum> MateriapReceta { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<OrdAsigOp> OrdAsigOps { get; set; }

    public virtual DbSet<Ordenproduccion> Ordenproduccions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Recetaproducto> Recetaproductos { get; set; }

    public virtual DbSet<Solicitudpedido> Solicitudpedidos { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=alemanadb;uid=root;pwd=110105", ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Capacidad>(entity =>
        {
            entity.HasKey(e => e.IdCap).HasName("PRIMARY");

            entity.ToTable("capacidad");

            entity.Property(e => e.IdCap).HasColumnName("idCap");
            entity.Property(e => e.DescCapacidad)
                .HasMaxLength(150)
                .HasColumnName("desc_capacidad");
            entity.Property(e => e.NomCapacidad)
                .HasMaxLength(45)
                .HasColumnName("nom_capacidad");

            entity.HasMany(d => d.IdOperarios).WithMany(p => p.IdCaps)
                .UsingEntity<Dictionary<string, object>>(
                    "CapacidadOp",
                    r => r.HasOne<Operario>().WithMany()
                        .HasForeignKey("IdOperario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("capacidad_op_ibfk_2"),
                    l => l.HasOne<Capacidad>().WithMany()
                        .HasForeignKey("IdCap")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("capacidad_op_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdCap", "IdOperario")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("capacidad_op");
                        j.HasIndex(new[] { "IdOperario" }, "idOperario");
                        j.IndexerProperty<int>("IdCap").HasColumnName("idCap");
                        j.IndexerProperty<int>("IdOperario").HasColumnName("idOperario");
                    });
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.CodPostal).HasName("PRIMARY");

            entity.ToTable("ciudades");

            entity.Property(e => e.CodPostal)
                .ValueGeneratedNever()
                .HasColumnName("codPostal");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .HasColumnName("nombreCiudad");
        });

        modelBuilder.Entity<Consumolote>(entity =>
        {
            entity.HasKey(e => e.IdConsumo).HasName("PRIMARY");

            entity.ToTable("consumolote");

            entity.HasIndex(e => e.IdLote, "idLote");

            entity.HasIndex(e => e.IdProd, "idProd");

            entity.Property(e => e.IdConsumo).HasColumnName("idConsumo");
            entity.Property(e => e.CantConsumida)
                .HasPrecision(10, 2)
                .HasColumnName("cantConsumida");
            entity.Property(e => e.IdLote).HasColumnName("idLote");
            entity.Property(e => e.IdProd).HasColumnName("idProd");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.Consumolotes)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consumolote_ibfk_2");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Consumolotes)
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("consumolote_ibfk_1");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detalle_pedido");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.CantidadesProductos).HasColumnName("cantidadesProductos");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_pedido_ibfk_2");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.Dni, "dni").IsUnique();

            entity.HasIndex(e => e.IdJefe, "idJefe");

            entity.HasIndex(e => e.IdSucursal, "idSucursal");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("dni");
            entity.Property(e => e.IdJefe).HasColumnName("idJefe");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdJefeNavigation).WithMany(p => p.InverseIdJefeNavigation)
                .HasForeignKey(d => d.IdJefe)
                .HasConstraintName("empleados_ibfk_2");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Empleados)
               .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PRIMARY");

            entity.ToTable("lote");

            entity.HasIndex(e => e.IdMateriaP, "idMateriaP");

            entity.HasIndex(e => e.IdProveedor, "idProveedor");

            entity.Property(e => e.IdLote).HasColumnName("idLote");
            entity.Property(e => e.CantidadLote)
                .HasPrecision(10, 2)
                .HasColumnName("cantidadLote");
            entity.Property(e => e.EstadoLote).HasColumnName("estadoLote");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.IdMateriaP).HasColumnName("idMateriaP");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

            entity.HasOne(d => d.IdMateriaPNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdMateriaP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lote_ibfk_2");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lote_ibfk_1");
        });

        modelBuilder.Entity<Materiap>(entity =>
        {
            entity.HasKey(e => e.IdMateriaP).HasName("PRIMARY");

            entity.ToTable("materiap");

            entity.Property(e => e.IdMateriaP).HasColumnName("idMateriaP");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Unidad)
                .HasMaxLength(45)
                .HasColumnName("unidad");
        });

        modelBuilder.Entity<MateriapRecetum>(entity =>
        {
            entity.HasKey(e => new { e.IdMateriaP, e.IdReceta })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("materiap_receta");

            entity.HasIndex(e => e.IdReceta, "idReceta");

            entity.Property(e => e.IdMateriaP).HasColumnName("idMateriaP");
            entity.Property(e => e.IdReceta).HasColumnName("idReceta");
            entity.Property(e => e.CantidadNecesaria)
                .HasPrecision(10, 2)
                .HasColumnName("cantidadNecesaria");

            entity.HasOne(d => d.IdMateriaPNavigation).WithMany(p => p.MateriapReceta)
                .HasForeignKey(d => d.IdMateriaP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materiap_receta_ibfk_1");

            entity.HasOne(d => d.IdRecetaNavigation).WithMany(p => p.MateriapReceta)
                .HasForeignKey(d => d.IdReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("materiap_receta_ibfk_2");
        });

        modelBuilder.Entity<Operario>(entity =>
        {
            entity.HasKey(e => e.IdOperario).HasName("PRIMARY");

            entity.ToTable("operarios");

            entity.Property(e => e.IdOperario).HasColumnName("idOperario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Disponibilidad)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<OrdAsigOp>(entity =>
        {
            entity.HasKey(e => new { e.IdProd, e.IdOperario })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("ord_asig_op");

            entity.HasIndex(e => e.IdOperario, "idOperario");

            entity.Property(e => e.IdProd).HasColumnName("idProd");
            entity.Property(e => e.IdOperario).HasColumnName("idOperario");
            entity.Property(e => e.Cantidades).HasColumnName("cantidades");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fechaFin");
            entity.Property(e => e.FechaIni)
                .HasColumnType("datetime")
                .HasColumnName("fechaIni");

            entity.HasOne(d => d.IdOperarioNavigation).WithMany(p => p.OrdAsigOps)
                .HasForeignKey(d => d.IdOperario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ord_asig_op_ibfk_2");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.OrdAsigOps)
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ord_asig_op_ibfk_1");
        });

        modelBuilder.Entity<Ordenproduccion>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PRIMARY");

            entity.ToTable("ordenproduccion");

            entity.HasIndex(e => e.IdPedido, "idPedido");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.IdProd).HasColumnName("idProd");
            entity.Property(e => e.CantidadRequerida).HasColumnName("cantidadRequerida");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasColumnName("estadoPedido");
            entity.Property(e => e.FechaEstimada)
                .HasColumnType("datetime")
                .HasColumnName("fechaEstimada");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("datetime")
                .HasColumnName("fechaPedido");
            entity.Property(e => e.FechaReal)
                .HasColumnType("datetime")
                .HasColumnName("fechaReal");
            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Ordenproduccions)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("ordenproduccion_ibfk_2");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Ordenproduccions)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordenproduccion_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdReceta, "idReceta").IsUnique();

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Camara).HasColumnName("camara");
            entity.Property(e => e.Disponible)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("disponible");
            entity.Property(e => e.IdReceta).HasColumnName("idReceta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRecetaNavigation).WithOne(p => p.Producto)
                .HasForeignKey<Producto>(d => d.IdReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Cuit)
                .HasMaxLength(11)
                .HasColumnName("cuit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .HasColumnName("razonSocial");
        });

        modelBuilder.Entity<Recetaproducto>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("PRIMARY");

            entity.ToTable("recetaproducto");

            entity.Property(e => e.IdReceta).HasColumnName("idReceta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Solicitudpedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("solicitudpedido");

            entity.HasIndex(e => e.IdEmpleado, "idEmpleado");

            entity.Property(e => e.IdPedido).HasColumnName("idPedido");
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasColumnName("estadoPedido");
            entity.Property(e => e.FechaEstimada)
                .HasColumnType("datetime")
                .HasColumnName("fechaEstimada");
            entity.Property(e => e.FechaPedido)
                .HasColumnType("datetime")
                .HasColumnName("fechaPedido");
            entity.Property(e => e.FechaReal)
                .HasColumnType("datetime")
                .HasColumnName("fechaReal");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Solicitudpedidos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("solicitudpedido_ibfk_1");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PRIMARY");

            entity.ToTable("sucursales");

            entity.HasIndex(e => e.CodPostal, "codPostal");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.CodPostal).HasColumnName("codPostal");
            entity.Property(e => e.NombreSuc)
                .HasMaxLength(100)
                .HasColumnName("nombreSuc");

            entity.HasOne(d => d.CodPostalNavigation).WithMany(p => p.Sucursales)
                .HasForeignKey(d => d.CodPostal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sucursales_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
