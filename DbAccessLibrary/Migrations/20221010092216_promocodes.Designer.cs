﻿// <auto-generated />
using System;
using DbAccessLibrary.DbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbAccessLibrary.Migrations
{
    [DbContext(typeof(ClothesStoreDbContext))]
    [Migration("20221010092216_promocodes")]
    partial class promocodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbAccessLibrary.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClothesId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOrderFinished")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClothesId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.Clothes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfClothes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.Promocode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Promocodes");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.UsedPromocode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PromocodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PromocodeId");

                    b.ToTable("UsedPromocodes");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.Cart", b =>
                {
                    b.HasOne("DbAccessLibrary.Models.Clothes", null)
                        .WithMany("Carts")
                        .HasForeignKey("ClothesId");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.Clothes", b =>
                {
                    b.HasOne("DbAccessLibrary.Models.Seller", null)
                        .WithMany("Clothes")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("DbAccessLibrary.Models.UsedPromocode", b =>
                {
                    b.HasOne("DbAccessLibrary.Models.Promocode", null)
                        .WithMany("Promocodes")
                        .HasForeignKey("PromocodeId");
                });
#pragma warning restore 612, 618
        }
    }
}
