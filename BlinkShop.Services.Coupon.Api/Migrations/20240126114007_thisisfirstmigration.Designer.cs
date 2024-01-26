﻿// <auto-generated />
using System;
using BlinkShop.Services.Coupon.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlinkShop.Services.Coupon.Api.Migrations
{
    [DbContext(typeof(BlinkShopDbContext))]
    [Migration("20240126114007_thisisfirstmigration")]
    partial class thisisfirstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlinkShop.Services.Coupon.Api.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MinAmount")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.ToTable("model");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponCode = "10OFf",
                            DiscountAmount = 10.0,
                            LastUpdated = new DateTime(2024, 1, 26, 11, 40, 7, 516, DateTimeKind.Local).AddTicks(8893),
                            MinAmount = 20
                        },
                        new
                        {
                            CouponId = 2,
                            CouponCode = "20OFf",
                            DiscountAmount = 20.0,
                            LastUpdated = new DateTime(2024, 1, 26, 11, 40, 7, 516, DateTimeKind.Local).AddTicks(8943),
                            MinAmount = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
