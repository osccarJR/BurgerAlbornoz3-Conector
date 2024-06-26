﻿// <auto-generated />
using System;
using BurgerAlbornoz3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerAlbornoz3.Migrations
{
    [DbContext(typeof(BurgerAlbornoz3Context))]
    partial class BurgerAlbornoz3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurgerAlbornoz3.Models.Burger", b =>
                {
                    b.Property<int>("BurgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurgerId");

                    b.ToTable("Burger");
                });

            modelBuilder.Entity("BurgerAlbornoz3.Models.Promo", b =>
                {
                    b.Property<int>("PromId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromId"));

                    b.Property<int>("BurgerID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPromo")
                        .HasColumnType("datetime2");

                    b.HasKey("PromId");

                    b.HasIndex("BurgerID");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("BurgerAlbornoz3.Models.Promo", b =>
                {
                    b.HasOne("BurgerAlbornoz3.Models.Burger", "Burger")
                        .WithMany("Promo")
                        .HasForeignKey("BurgerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("BurgerAlbornoz3.Models.Burger", b =>
                {
                    b.Navigation("Promo");
                });
#pragma warning restore 612, 618
        }
    }
}
