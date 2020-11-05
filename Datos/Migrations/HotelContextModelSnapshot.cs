﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.DetalleProducto", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(4)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("FacturaIdFactura")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("IdHabitacion")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("IdProducto")
                        .HasColumnType("varchar(4)");

                    b.HasKey("Codigo");

                    b.HasIndex("FacturaIdFactura");

                    b.HasIndex("IdHabitacion");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleProducto");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.Property<string>("IdFactura")
                        .HasColumnType("varchar(4)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(4)");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime");

                    b.Property<string>("IdHabitacion")
                        .HasColumnType("varchar(4)");

                    b.Property<int>("Iva")
                        .HasColumnType("int");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdFactura");

                    b.HasIndex("Cedula");

                    b.HasIndex("Codigo");

                    b.HasIndex("IdHabitacion");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Entity.Habitacion", b =>
                {
                    b.Property<string>("IdHabitacion")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(16)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(8)");

                    b.Property<int>("nPersonas")
                        .HasColumnType("int");

                    b.HasKey("IdHabitacion");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Departamento")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Cedula");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(12)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.Cliente", b =>
                {
                    b.HasBaseType("Entity.Persona");

                    b.Property<string>("IdCliente")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("IdHabitacion")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Ppal")
                        .HasColumnType("varchar(4)");

                    b.HasIndex("IdHabitacion");

                    b.HasIndex("Ppal");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Entity.Empleado", b =>
                {
                    b.HasBaseType("Entity.Persona");

                    b.Property<string>("Cargo")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("IdEmpleado")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Jefe")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Jornada")
                        .HasColumnType("varchar(8)");

                    b.HasIndex("Jefe");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("Entity.DetalleProducto", b =>
                {
                    b.HasOne("Entity.Factura", null)
                        .WithMany("Detalles")
                        .HasForeignKey("FacturaIdFactura");

                    b.HasOne("Entity.Habitacion", null)
                        .WithMany()
                        .HasForeignKey("IdHabitacion");

                    b.HasOne("Entity.Producto", null)
                        .WithMany()
                        .HasForeignKey("IdProducto");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.HasOne("Entity.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Cedula");

                    b.HasOne("Entity.DetalleProducto", null)
                        .WithMany()
                        .HasForeignKey("Codigo");

                    b.HasOne("Entity.Habitacion", null)
                        .WithMany()
                        .HasForeignKey("IdHabitacion");
                });

            modelBuilder.Entity("Entity.Cliente", b =>
                {
                    b.HasOne("Entity.Persona", null)
                        .WithMany()
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Habitacion", null)
                        .WithMany()
                        .HasForeignKey("IdHabitacion");

                    b.HasOne("Entity.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Ppal");
                });

            modelBuilder.Entity("Entity.Empleado", b =>
                {
                    b.HasOne("Entity.Persona", null)
                        .WithMany()
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Empleado", null)
                        .WithMany()
                        .HasForeignKey("Jefe");
                });
#pragma warning restore 612, 618
        }
    }
}
