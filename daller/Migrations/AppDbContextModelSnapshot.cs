﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoMerck.DAL;

#nullable disable

namespace daller.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Common_Layer.Models.Entities.ClinicConsultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsultMotiveMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SelectedLocationIndex")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClinicConsultations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConsultMotiveMessage = "Stringer",
                            CreatedTime = new DateTime(2024, 1, 4, 12, 15, 7, 78, DateTimeKind.Local).AddTicks(5665),
                            SelectedLocationIndex = 2,
                            Url = "www.google.com"
                        },
                        new
                        {
                            Id = 2,
                            ConsultMotiveMessage = "Inter",
                            CreatedTime = new DateTime(2024, 1, 4, 12, 15, 7, 78, DateTimeKind.Local).AddTicks(5677),
                            SelectedLocationIndex = 3,
                            Url = "www.google.com"
                        });
                });

            modelBuilder.Entity("Common_Layer.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("Common_Layer.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "random",
                            RoleId = 1,
                            UserName = "random"
                        });
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.ConsultMotive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConsultMotiveX")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsultMotives");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConsultMotiveX = "Deseo de ser madre"
                        },
                        new
                        {
                            Id = 2,
                            ConsultMotiveX = "Problemas de fertilidad"
                        },
                        new
                        {
                            Id = 3,
                            ConsultMotiveX = "Planificación familiar"
                        },
                        new
                        {
                            Id = 4,
                            ConsultMotiveX = "Tratamientos de reproducción asistida"
                        },
                        new
                        {
                            Id = 5,
                            ConsultMotiveX = "Superar dificultades en la concepción"
                        },
                        new
                        {
                            Id = 6,
                            ConsultMotiveX = "Consultas preconcepcionales"
                        },
                        new
                        {
                            Id = 7,
                            ConsultMotiveX = "Evaluación de la salud reproductiva"
                        },
                        new
                        {
                            Id = 8,
                            ConsultMotiveX = "Seguimiento durante el embarazo"
                        },
                        new
                        {
                            Id = 9,
                            ConsultMotiveX = "Asesoramiento en técnicas de reproducción"
                        },
                        new
                        {
                            Id = 10,
                            ConsultMotiveX = "Preservación de la fertilidad"
                        });
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brasil"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chile"
                        });
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("ProvinceLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceLocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = -34.600677504040895,
                            Longitude = -58.387263729958455,
                            ProvinceLocationId = 1,
                            Subtitle = "Centro Fertilidad",
                            Title = "CEGYR"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = -34.580702852634481,
                            Longitude = -58.430260973627661,
                            ProvinceLocationId = 2,
                            Subtitle = "Centro Fertilidad",
                            Title = "CER"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = -34.578846588221204,
                            Longitude = -58.460103931977983,
                            ProvinceLocationId = 3,
                            Subtitle = "Centro Fertilidad",
                            Title = "CIMER"
                        },
                        new
                        {
                            Id = 4,
                            Latitude = -34.599254733727243,
                            Longitude = -58.401810339490027,
                            ProvinceLocationId = 4,
                            Subtitle = "Centro Fertilidad",
                            Title = "CRECER"
                        },
                        new
                        {
                            Id = 5,
                            Latitude = -34.597439056459208,
                            Longitude = -58.397189279473473,
                            ProvinceLocationId = 5,
                            Subtitle = "Centro Fertilidad",
                            Title = "HIALITUS"
                        },
                        new
                        {
                            Id = 6,
                            Latitude = -34.606202223417398,
                            Longitude = -58.425645264604945,
                            ProvinceLocationId = 5,
                            Subtitle = "Centro Fertilidad",
                            Title = "HOSPITAL ITALIANO"
                        },
                        new
                        {
                            Id = 7,
                            Latitude = -34.596689236707874,
                            Longitude = -58.399734815343471,
                            ProvinceLocationId = 4,
                            Subtitle = "Centro Fertilidad",
                            Title = "IFER"
                        },
                        new
                        {
                            Id = 8,
                            Latitude = -34.557128982074609,
                            Longitude = -58.447618128835863,
                            ProvinceLocationId = 3,
                            Subtitle = "Centro Fertilidad",
                            Title = "WEFIV"
                        });
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 2,
                            Name = "Buenos Aires"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Buenos Aires-GBA"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Capital Federal"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Catamarca"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 2,
                            Name = "Chaco"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 2,
                            Name = "Chubut"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 2,
                            Name = "Córdoba"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 2,
                            Name = "Corrientes"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 2,
                            Name = "Entre Ríos"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 2,
                            Name = "Formosa"
                        },
                        new
                        {
                            Id = 11,
                            CountryId = 2,
                            Name = "Jujuy"
                        },
                        new
                        {
                            Id = 12,
                            CountryId = 2,
                            Name = "La Pampa"
                        },
                        new
                        {
                            Id = 13,
                            CountryId = 2,
                            Name = "La Rioja"
                        },
                        new
                        {
                            Id = 14,
                            CountryId = 2,
                            Name = "Mendoza"
                        },
                        new
                        {
                            Id = 15,
                            CountryId = 2,
                            Name = "Misiones"
                        },
                        new
                        {
                            Id = 16,
                            CountryId = 2,
                            Name = "Neuquén"
                        },
                        new
                        {
                            Id = 17,
                            CountryId = 2,
                            Name = "Río Negro"
                        },
                        new
                        {
                            Id = 18,
                            CountryId = 2,
                            Name = "Salta"
                        },
                        new
                        {
                            Id = 19,
                            CountryId = 2,
                            Name = "San Juan"
                        },
                        new
                        {
                            Id = 20,
                            CountryId = 2,
                            Name = "San Luis"
                        },
                        new
                        {
                            Id = 21,
                            CountryId = 2,
                            Name = "Santa Cruz"
                        },
                        new
                        {
                            Id = 22,
                            CountryId = 2,
                            Name = "Santa Fe"
                        },
                        new
                        {
                            Id = 23,
                            CountryId = 2,
                            Name = "Santiago del Estero"
                        },
                        new
                        {
                            Id = 24,
                            CountryId = 2,
                            Name = "Tierra del Fuego"
                        },
                        new
                        {
                            Id = 25,
                            CountryId = 2,
                            Name = "Tucumán"
                        });
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.ProvinceLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("ProvinceLocations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Playa del Sol",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Montaña Encantada",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ciudad del Viento",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Valle de las Flores",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Centro Histórico",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Barrio Moderno",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Oasis del Desierto",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pico de la Luna",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Selva Esmeralda",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 10,
                            Name = "Río Dorado",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 11,
                            Name = "Costa Azul",
                            ProvinceId = 6
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bosque Mágico",
                            ProvinceId = 6
                        },
                        new
                        {
                            Id = 13,
                            Name = "Sierras Doradas",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 14,
                            Name = "Valle de los Suspiros",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 15,
                            Name = "Río Paraná",
                            ProvinceId = 8
                        },
                        new
                        {
                            Id = 16,
                            Name = "Bosque Encantado",
                            ProvinceId = 8
                        },
                        new
                        {
                            Id = 17,
                            Name = "Termas del Guaychú",
                            ProvinceId = 9
                        },
                        new
                        {
                            Id = 18,
                            Name = "Puerto de las Palmas",
                            ProvinceId = 9
                        },
                        new
                        {
                            Id = 19,
                            Name = "Lago Formosa",
                            ProvinceId = 10
                        },
                        new
                        {
                            Id = 20,
                            Name = "Pueblo de las Aves",
                            ProvinceId = 10
                        },
                        new
                        {
                            Id = 21,
                            Name = "Valle de los Colores",
                            ProvinceId = 11
                        },
                        new
                        {
                            Id = 22,
                            Name = "Cerro de Siete Colores",
                            ProvinceId = 11
                        },
                        new
                        {
                            Id = 23,
                            Name = "Pampa Dorada",
                            ProvinceId = 12
                        },
                        new
                        {
                            Id = 24,
                            Name = "Laguna Escondida",
                            ProvinceId = 12
                        },
                        new
                        {
                            Id = 25,
                            Name = "Valle de la Luna",
                            ProvinceId = 13
                        },
                        new
                        {
                            Id = 26,
                            Name = "Cascada del Cielo",
                            ProvinceId = 13
                        },
                        new
                        {
                            Id = 27,
                            Name = "Viñedos del Sol",
                            ProvinceId = 14
                        },
                        new
                        {
                            Id = 28,
                            Name = "Cerro Aconcagua",
                            ProvinceId = 14
                        },
                        new
                        {
                            Id = 29,
                            Name = "Cataratas del Iguazú",
                            ProvinceId = 15
                        },
                        new
                        {
                            Id = 30,
                            Name = "Bosque Misionero",
                            ProvinceId = 15
                        },
                        new
                        {
                            Id = 31,
                            Name = "Lago Nahuel Huapi",
                            ProvinceId = 16
                        },
                        new
                        {
                            Id = 32,
                            Name = "Cerro Chapelco",
                            ProvinceId = 16
                        });
                });

            modelBuilder.Entity("Common_Layer.Models.Entities.User", b =>
                {
                    b.HasOne("Common_Layer.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.Location", b =>
                {
                    b.HasOne("ProyectoMerck.Models.Entities.ProvinceLocation", "ProvinceLocation")
                        .WithMany()
                        .HasForeignKey("ProvinceLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProvinceLocation");
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.Province", b =>
                {
                    b.HasOne("ProyectoMerck.Models.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ProyectoMerck.Models.Entities.ProvinceLocation", b =>
                {
                    b.HasOne("ProyectoMerck.Models.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });
#pragma warning restore 612, 618
        }
    }
}
