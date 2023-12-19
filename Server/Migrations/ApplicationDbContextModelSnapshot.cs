﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueChulosPerros.Server.Data;

#nullable disable

namespace QueChulosPerros.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Cita", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int?>("ClientId")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<DateTime>("EndTime")
                    .HasColumnType("datetime2");

                b.Property<int?>("PetId")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<DateTime>("StartTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Subject")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.HasIndex("PetId");

                b.ToTable("Citas");
            });

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Cliente", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("Branch")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.HasKey("Id");

                b.ToTable("Clientes");
            });

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Mascota", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<bool?>("Alive")
                    .IsRequired()
                    .HasColumnType("bit");

                b.Property<string>("Breed")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("ClientId")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar(255)");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("Specie")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("Mascotas");
            });

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Trabajador", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<bool>("Admin")
                    .HasColumnType("bit");

                b.Property<int>("Branch")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Gender")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.HasKey("Id");

                b.ToTable("Trabajadores");
            });

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Cita", b =>
            {
                b.HasOne("QueChulosPerros.Shared.Model.Cliente", "Client")
                    .WithMany()
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("QueChulosPerros.Shared.Model.Mascota", "Pet")
                    .WithMany()
                    .HasForeignKey("PetId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Client");

                b.Navigation("Pet");
            });

            modelBuilder.Entity("QueChulosPerros.Shared.Model.Mascota", b =>
            {
                b.HasOne("QueChulosPerros.Shared.Model.Cliente", "Client")
                    .WithMany()
                    .HasForeignKey("ClientId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Client");
            });
#pragma warning restore 612, 618
        }
    }
}
