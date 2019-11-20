﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hamburgueseria.Migrations
{
    [DbContext(typeof(HamburgueseriaContext))]
    [Migration("20191118143036_modifymenu")]
    partial class modifymenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hamburgueseria.Models.Entrantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Entrantes");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Ingredientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EntrantesId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("PostresId")
                        .HasColumnType("int");

                    b.Property<int?>("PrincipalesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntrantesId");

                    b.HasIndex("PostresId");

                    b.HasIndex("PrincipalesId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EntranteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostreId")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int?>("PrincipalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntranteId");

                    b.HasIndex("PostreId");

                    b.HasIndex("PrincipalId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Postres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Postres");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Principales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Principales");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Ingredientes", b =>
                {
                    b.HasOne("Hamburgueseria.Models.Entrantes", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("EntrantesId");

                    b.HasOne("Hamburgueseria.Models.Postres", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("PostresId");

                    b.HasOne("Hamburgueseria.Models.Principales", null)
                        .WithMany("Ingredientes")
                        .HasForeignKey("PrincipalesId");
                });

            modelBuilder.Entity("Hamburgueseria.Models.Menu", b =>
                {
                    b.HasOne("Hamburgueseria.Models.Entrantes", "Entrante")
                        .WithMany()
                        .HasForeignKey("EntranteId");

                    b.HasOne("Hamburgueseria.Models.Postres", "Postre")
                        .WithMany()
                        .HasForeignKey("PostreId");

                    b.HasOne("Hamburgueseria.Models.Principales", "Principal")
                        .WithMany()
                        .HasForeignKey("PrincipalId");
                });
#pragma warning restore 612, 618
        }
    }
}
