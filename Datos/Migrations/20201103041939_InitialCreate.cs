﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<string>(type: "varchar(4)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(8)", nullable: true),
                    NMinPersonas = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(12)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.IdHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<string>(type: "varchar(4)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(12)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(15)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(12)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(12)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "varchar(12)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(12)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "varchar(12)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Edad = table.Column<string>(type: "varchar(12)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(25)", nullable: true),
                    Departamento = table.Column<string>(type: "varchar(14)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(14)", nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdCliente = table.Column<string>(type: "varchar(4)", nullable: true),
                    IdHabitacion = table.Column<string>(type: "varchar(4)", nullable: true),
                    IdEmpleado = table.Column<string>(type: "varchar(4)", nullable: true),
                    Cargo = table.Column<string>(type: "varchar(12)", nullable: true),
                    Jornada = table.Column<string>(type: "varchar(8)", nullable: true),
                    Jefe = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cedula);
                    table.ForeignKey(
                        name: "FK_Personas_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<string>(type: "varchar(4)", nullable: false),
                    FechaFactura = table.Column<DateTime>(type: "datetime", nullable: false),
                    Subtotal = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime", nullable: false),
                    cedula = table.Column<string>(type: "varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Personas_cedula",
                        column: x => x.cedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(4)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    idproducto = table.Column<string>(type: "varchar(4)", nullable: true),
                    FacturaIdFactura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Facturas_FacturaIdFactura",
                        column: x => x.FacturaIdFactura,
                        principalTable: "Facturas",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Productos_idproducto",
                        column: x => x.idproducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_FacturaIdFactura",
                table: "DetalleProducto",
                column: "FacturaIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_idproducto",
                table: "DetalleProducto",
                column: "idproducto");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_cedula",
                table: "Facturas",
                column: "cedula");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdHabitacion",
                table: "Personas",
                column: "IdHabitacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProducto");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Habitaciones");
        }
    }
}
