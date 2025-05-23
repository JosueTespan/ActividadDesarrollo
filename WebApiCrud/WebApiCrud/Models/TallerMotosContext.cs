using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiCrud.Models;

public partial class TallerMotosContext : DbContext
{
    public TallerMotosContext()
    {
    }

    public TallerMotosContext(DbContextOptions<TallerMotosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Motocicletum> Motocicleta { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioCliente> ServicioClientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargos__3D0E29B85669886B");

            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.Cargo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__885457EEFB03C213");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFac).HasName("PK__Detalle___B2F5043B01CF1102");

            entity.ToTable("Detalle_Factura");

            entity.Property(e => e.IdDetalleFac).HasColumnName("idDetalle_fac");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdServicioCli).HasColumnName("idServicio_cli");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Detalle_F__idEmp__4E88ABD4");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK__Detalle_F__idFac__4D94879B");

            entity.HasOne(d => d.IdServicioCliNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdServicioCli)
                .HasConstraintName("FK__Detalle_F__idSer__4F7CD00D");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297CE239A69B");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Dui)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DUI");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.IdCargo).HasColumnName("idCargo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__Empleado__idCarg__398D8EEE");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__3CD5687EBEC85481");

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Factura__idClien__49C3F6B7");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Factura__idEmple__4AB81AF0");
        });

        modelBuilder.Entity<Motocicletum>(entity =>
        {
            entity.HasKey(e => e.IdMotocicleta).HasName("PK__Motocicl__EE98DCEBEB395A01");

            entity.Property(e => e.IdMotocicleta).HasColumnName("idMotocicleta");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Motocicleta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Motocicle__idCli__4316F928");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119D287F0A2");

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
            entity.HasKey(e => e.IdServicioCli).HasName("PK__Servicio__E784F1581276D924");

            entity.ToTable("Servicio_cliente");

            entity.Property(e => e.IdServicioCli).HasColumnName("idServicio_cli");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ServicioClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Servicio___idCli__46E78A0C");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServicioClientes)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__Servicio___idSer__45F365D3");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A629E6B64A");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Usuario__idEmple__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
