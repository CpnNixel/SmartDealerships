﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartDealerships.DataAccess.PSQL;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    [DbContext(typeof(DealershipDbContext))]
    [Migration("20220605165958_AddedCompany")]
    partial class AddedCompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("CompanyUser", b =>
                {
                    b.Property<int>("CompaniesId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("CompaniesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CompanyUser");
                });

            modelBuilder.Entity("OrderDetailsProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderDetailsProduct");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Qty")
                        .HasColumnType("integer");

                    b.Property<int?>("ShoppingSessionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingSessionId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.ShoppingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingSessions");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CompanyUser", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartDealerships.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderDetailsProduct", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.OrderDetails", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartDealerships.Infrastructure.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.CartItem", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.ShoppingSession", "ShoppingSession")
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingSessionId");

                    b.Navigation("ShoppingSession");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.OrderDetails", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.Company", "SellingCompany")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("SmartDealerships.Infrastructure.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("SellingCompany");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.Product", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.Company", "SellingCompany")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SellingCompany");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.ShoppingSession", b =>
                {
                    b.HasOne("SmartDealerships.Infrastructure.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmartDealerships.Infrastructure.Models.ShoppingSession", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
