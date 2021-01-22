﻿// <auto-generated />
using System;
using ComicBookShop.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicBookShop.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20210108224242_DbInit3")]
    partial class DbInit3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ComicBookShop.Model.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PK_address");

                    b.ToTable("address");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrespondingComicBookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("InUsersCartId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PK_cartitem");

                    b.HasIndex("CorrespondingComicBookId");

                    b.HasIndex("InUsersCartId");

                    b.ToTable("cartitem");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.ComicBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ComicType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PK_comicbook");

                    b.ToTable("comicbook");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeliveryAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("OrderedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PK_order");

                    b.HasIndex("DeliveryAddressId");

                    b.HasIndex("OrderedByUserId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.OrderComicBook", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ComicBookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OrderId", "ComicBookId")
                        .HasName("PK_ordercomicbook");

                    b.HasIndex("ComicBookId");

                    b.ToTable("ordercomicbook");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DeliveryAddressID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK_user");

                    b.HasIndex("DeliveryAddressID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.CartItem", b =>
                {
                    b.HasOne("ComicBookShop.Model.Entity.ComicBook", "CorrespondingComicBook")
                        .WithMany("CartItems")
                        .HasForeignKey("CorrespondingComicBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookShop.Model.Entity.User", "InUsersCart")
                        .WithMany("CartItems")
                        .HasForeignKey("InUsersCartId");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.Order", b =>
                {
                    b.HasOne("ComicBookShop.Model.Entity.Address", "DeliveryAddress")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookShop.Model.Entity.User", "OrderedByUser")
                        .WithMany("Orders")
                        .HasForeignKey("OrderedByUserId");
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.OrderComicBook", b =>
                {
                    b.HasOne("ComicBookShop.Model.Entity.ComicBook", "ComicBookContained")
                        .WithMany("OrderComicBooks")
                        .HasForeignKey("ComicBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicBookShop.Model.Entity.Order", "OrderContaining")
                        .WithMany("OrderComicBooks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicBookShop.Model.Entity.User", b =>
                {
                    b.HasOne("ComicBookShop.Model.Entity.Address", "DeliveryAddress")
                        .WithMany("UserDeliveries")
                        .HasForeignKey("DeliveryAddressID");
                });
#pragma warning restore 612, 618
        }
    }
}
