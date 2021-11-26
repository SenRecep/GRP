﻿// <auto-generated />
using System;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GRP.Services.WaterTankCalculator.Migrations
{
    [DbContext(typeof(WaterTankCalculatorDbContext))]
    [Migration("20211126160735_Histories")]
    partial class Histories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ModuleDefault", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dimensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalOrders")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ModuleDefaults");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ProductDefault", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProductDefaults");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.RATDefault", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("DIP")
                        .HasColumnType("real");

                    b.Property<float>("DKPS")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("LC")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("RUB")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("RATDefaults");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ModuleHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ModuleDefaultKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TotalOrders")
                        .HasColumnType("int");

                    b.Property<float>("TotalWeight")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuleDefaultKey");

                    b.ToTable("ModuleHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ProductHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ProductDefaultKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductDefaultKey");

                    b.ToTable("ProductHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.RATHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("RATDefaultKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RATDefaultKey");

                    b.ToTable("RATHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ModuleHistory", b =>
                {
                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ModuleDefault", "ModuleDefault")
                        .WithMany("ModuleHistories")
                        .HasForeignKey("ModuleDefaultKey")
                        .HasPrincipalKey("Key")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ModuleDefault");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ProductHistory", b =>
                {
                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ProductDefault", "ProductDefault")
                        .WithMany("ProductHistories")
                        .HasForeignKey("ProductDefaultKey")
                        .HasPrincipalKey("Key")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ProductDefault");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.RATHistory", b =>
                {
                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.RATDefault", "RATDefault")
                        .WithMany("RATHistories")
                        .HasForeignKey("RATDefaultKey")
                        .HasPrincipalKey("Key")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("RATDefault");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ModuleDefault", b =>
                {
                    b.Navigation("ModuleHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.ProductDefault", b =>
                {
                    b.Navigation("ProductHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults.RATDefault", b =>
                {
                    b.Navigation("RATHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
