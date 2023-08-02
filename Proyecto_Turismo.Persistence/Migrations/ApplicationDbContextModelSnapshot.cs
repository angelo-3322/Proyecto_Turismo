﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Turismo.Persistence.Contexts;

#nullable disable

namespace Proyecto_Turismo.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReservacion")
                        .HasColumnType("int");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdReservacion");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Habitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<int>("NumeroHabitaciones")
                        .HasColumnType("int");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<string>("TipoHabitacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Reservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitaciones")
                        .HasColumnType("int");

                    b.Property<int>("IdPaquete")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdHabitaciones");

                    b.HasIndex("IdPaquete");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReservacion")
                        .HasColumnType("int");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdReservacion");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Factura", b =>
                {
                    b.HasOne("Proyecto_Turismo.Domain.Entities.Reservacion", "Reservacion")
                        .WithMany()
                        .HasForeignKey("IdReservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservacion");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Reservacion", b =>
                {
                    b.HasOne("Proyecto_Turismo.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Turismo.Domain.Entities.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("IdHabitaciones")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Turismo.Domain.Entities.Paquete", "Paquete")
                        .WithMany()
                        .HasForeignKey("IdPaquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacion");

                    b.Navigation("Paquete");
                });

            modelBuilder.Entity("Proyecto_Turismo.Domain.Entities.Restaurante", b =>
                {
                    b.HasOne("Proyecto_Turismo.Domain.Entities.Reservacion", "Reservacion")
                        .WithMany()
                        .HasForeignKey("IdReservacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservacion");
                });
#pragma warning restore 612, 618
        }
    }
}
