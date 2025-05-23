using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudMoto.Models;

public partial class TallerMecanicoContext : DbContext
{
    public TallerMecanicoContext()
    {
    }

    public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Motocicletum> Motocicleta { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioCliente> ServicioClientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__3D0E29B8E45FA55B");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.Cargo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EEBB6AE1D9");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.IdMotocicleta).HasColumnName("idMotocicleta");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdMotocicletaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdMotocicleta)
                .HasConstraintName("FK__Cliente__idMotoc__4316F928");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura).HasName("PK__Detalle___51D500E284226A4F");

            entity.ToTable("Detalle_Factura");

            entity.Property(e => e.IdDetalleFactura).HasColumnName("idDetalle_factura");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdServicioCliente).HasColumnName("idServicio_cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Detalle_F__idCli__5070F446");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Detalle_F__idEmp__4F7CD00D");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK__Detalle_F__idFac__4E88ABD4");

            entity.HasOne(d => d.IdServicioClienteNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdServicioCliente)
                .HasConstraintName("FK__Detalle_F__idSer__5165187F");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297C51DE201C");

            entity.HasIndex(e => e.Dui, "UQ__Empleado__C03671B96EBDD567").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DUI");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__Empleados__idCar__3A81B327");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687E26E8DEF8");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Motocicletum>(entity =>
        {
            entity.HasKey(e => e.IdMotocicleta).HasName("PK__Motocicl__EE98DCEBE5A99FED");

            entity.Property(e => e.IdMotocicleta).HasColumnName("idMotocicleta");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__A3FA8E6B664A0A2E");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Proveedor1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proveedor");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB981196CC7A620");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Servicio1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("servicio");
        });

        modelBuilder.Entity<ServicioCliente>(entity =>
        {
            entity.HasKey(e => e.IdServicioCliente).HasName("PK__Servicio__923234757FB73316");

            entity.ToTable("Servicio_cliente");

            entity.Property(e => e.IdServicioCliente).HasColumnName("idServicio_cliente");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ServicioClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Servicio___idCli__48CFD27E");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServicioClientes)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__Servicio___idSer__47DBAE45");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6A8F25AC3");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__9AFF8FC66DC98F6F").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Usuario__idEmple__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
