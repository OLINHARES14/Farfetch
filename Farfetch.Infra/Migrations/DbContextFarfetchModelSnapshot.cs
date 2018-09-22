﻿// <auto-generated />
using System;
using Farfetch.Infra.Data.Imp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Farfetch.Infra.Migrations
{
    [DbContext(typeof(DbContextFarfetch))]
    partial class DbContextFarfetchModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionProduto");

                    b.Property<string>("DescriptionServiceRota");

                    b.Property<string>("DescriptionToggle");

                    b.Property<string>("Protocol");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.ServiceRota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Authorization");

                    b.Property<string>("Rota");

                    b.HasKey("Id");

                    b.ToTable("ServiceRota");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.ServiceRotaToggle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Rota");

                    b.Property<int?>("ToggleId");

                    b.HasKey("Id");

                    b.HasIndex("ToggleId");

                    b.ToTable("ServiceRotaToggle");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.Toggle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Flag");

                    b.HasKey("Id");

                    b.ToTable("Toggle");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.ToggleServiceRota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ServiceRotaId");

                    b.Property<int?>("ToggleId");

                    b.HasKey("Id");

                    b.HasIndex("ServiceRotaId");

                    b.HasIndex("ToggleId");

                    b.ToTable("ToggleServiceRota");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.ServiceRotaToggle", b =>
                {
                    b.HasOne("Farfetch.Domain.Models.Entities.Toggle", "Toggle")
                        .WithMany()
                        .HasForeignKey("ToggleId");
                });

            modelBuilder.Entity("Farfetch.Domain.Models.Entities.ToggleServiceRota", b =>
                {
                    b.HasOne("Farfetch.Domain.Models.Entities.ServiceRota", "ServiceRota")
                        .WithMany("ToggleServiceRotas")
                        .HasForeignKey("ServiceRotaId");

                    b.HasOne("Farfetch.Domain.Models.Entities.Toggle", "Toggle")
                        .WithMany("ToggleServiceRotas")
                        .HasForeignKey("ToggleId");
                });
#pragma warning restore 612, 618
        }
    }
}
