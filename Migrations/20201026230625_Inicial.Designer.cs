﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPedidosSuplidores.DAL;

namespace RegistroPedidosSuplidores.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20201026230625_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenId");

                    b.HasIndex("SuplidorId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.OrdenesDetalle", b =>
                {
                    b.Property<int>("OrdenDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ventaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenDetalle");

                    b.HasIndex("OrdenId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ventaId");

                    b.ToTable("OrdenesDetalle");
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Inventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 65.0,
                            Descripcion = "Carton de Leche",
                            Inventario = 200.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 500.0,
                            Descripcion = "Arroz,5 Lb",
                            Inventario = 253.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 210.0,
                            Descripcion = "Carton de Huevo",
                            Inventario = 50.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 45.0,
                            Descripcion = "Manzanas,unidad",
                            Inventario = 253.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 120.0,
                            Descripcion = "Fresas Congeladas,1 Lb",
                            Inventario = 100.0
                        },
                        new
                        {
                            ProductoId = 6,
                            Costo = 25.0,
                            Descripcion = "Harina de trigo,1 lb",
                            Inventario = 200.0
                        },
                        new
                        {
                            ProductoId = 7,
                            Costo = 300.0,
                            Descripcion = "Bolones,1 funda",
                            Inventario = 253.0
                        });
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            SuplidorId = 1,
                            Nombres = "Nestle"
                        },
                        new
                        {
                            SuplidorId = 2,
                            Nombres = "El soberano"
                        },
                        new
                        {
                            SuplidorId = 3,
                            Nombres = "Huevos Endy"
                        },
                        new
                        {
                            SuplidorId = 4,
                            Nombres = "El frutal"
                        },
                        new
                        {
                            SuplidorId = 5,
                            Nombres = "Constanza"
                        },
                        new
                        {
                            SuplidorId = 6,
                            Nombres = "La Blanquita"
                        },
                        new
                        {
                            SuplidorId = 7,
                            Nombres = "Yogeta"
                        });
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.Ordenes", b =>
                {
                    b.HasOne("RegistroPedidosSuplidores.Entidades.Suplidores", "suplidores")
                        .WithMany()
                        .HasForeignKey("SuplidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegistroPedidosSuplidores.Entidades.OrdenesDetalle", b =>
                {
                    b.HasOne("RegistroPedidosSuplidores.Entidades.Ordenes", null)
                        .WithMany("Detalle")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroPedidosSuplidores.Entidades.Productos", "productos")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroPedidosSuplidores.Entidades.Ventas", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ventaId");
                });
#pragma warning restore 612, 618
        }
    }
}
