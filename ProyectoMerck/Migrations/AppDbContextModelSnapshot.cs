﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoMerck.DAL;

#nullable disable

namespace ProyectoMerck.Migrations
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

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = -34.600677504040895,
                            Longitude = -58.387263729958455,
                            Subtitle = "Centro Fertilidad",
                            Title = "CEGYR"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = -34.580702852634481,
                            Longitude = -58.430260973627661,
                            Subtitle = "Centro Fertilidad",
                            Title = "CER"
                        },
                        new
                        {
                            Id = 3,
                            Latitude = -34.578846588221204,
                            Longitude = -58.460103931977983,
                            Subtitle = "Centro Fertilidad",
                            Title = "CIMER"
                        },
                        new
                        {
                            Id = 4,
                            Latitude = -34.599254733727243,
                            Longitude = -58.401810339490027,
                            Subtitle = "Centro Fertilidad",
                            Title = "CRECER"
                        },
                        new
                        {
                            Id = 5,
                            Latitude = -34.597439056459208,
                            Longitude = -58.397189279473473,
                            Subtitle = "Centro Fertilidad",
                            Title = "HIALITUS"
                        },
                        new
                        {
                            Id = 6,
                            Latitude = -34.606202223417398,
                            Longitude = -58.425645264604945,
                            Subtitle = "Centro Fertilidad",
                            Title = "HOSPITAL ITALIANO"
                        },
                        new
                        {
                            Id = 7,
                            Latitude = -34.596689236707874,
                            Longitude = -58.399734815343471,
                            Subtitle = "Centro Fertilidad",
                            Title = "IFER"
                        },
                        new
                        {
                            Id = 8,
                            Latitude = -34.557128982074609,
                            Longitude = -58.447618128835863,
                            Subtitle = "Centro Fertilidad",
                            Title = "WEFIV"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
