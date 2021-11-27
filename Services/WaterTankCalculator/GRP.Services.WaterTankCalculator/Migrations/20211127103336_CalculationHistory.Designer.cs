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
    [Migration("20211127103336_CalculationHistory")]
    partial class CalculationHistory
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

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculateModelHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("PlinthType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CalculationHistoryId");

                    b.ToTable("CalculateModelHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("ConstantsHistoryId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("ModuleHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RATHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TotalCostHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConstantsHistoryId")
                        .IsUnique();

                    b.ToTable("CalculationHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ConstantsHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Dollar")
                        .HasColumnType("real");

                    b.Property<float>("GRPKgPrice")
                        .HasColumnType("real");

                    b.Property<float>("IntercityTransportation")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ConstantsHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ModuleHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

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

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.TotalCostHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalculationHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Financing")
                        .HasColumnType("real");

                    b.Property<float>("GoesInvisible")
                        .HasColumnType("real");

                    b.Property<float>("GrandTotal")
                        .HasColumnType("real");

                    b.Property<float>("IntercityTransportation")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TotalCostHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculateModelHistory", b =>
                {
                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "CalculationHistory")
                        .WithMany("CalculateModelHistories")
                        .HasForeignKey("CalculationHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CalculationHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", b =>
                {
                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ConstantsHistory", "ConstantsHistory")
                        .WithOne("CalculationHistory")
                        .HasForeignKey("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "ConstantsHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ModuleHistory", "ModuleHistory")
                        .WithOne("CalculationHistory")
                        .HasForeignKey("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "ConstantsHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ProductHistory", "ProductHistory")
                        .WithOne("CalculationHistory")
                        .HasForeignKey("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "ConstantsHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.RATHistory", "RATHistory")
                        .WithOne("CalculationHistory")
                        .HasForeignKey("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "ConstantsHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GRP.Services.WaterTankCalculator.Entities.Concrete.History.TotalCostHistory", "TotalCostHistory")
                        .WithOne("CalculationHistory")
                        .HasForeignKey("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", "ConstantsHistoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ConstantsHistory");

                    b.Navigation("ModuleHistory");

                    b.Navigation("ProductHistory");

                    b.Navigation("RATHistory");

                    b.Navigation("TotalCostHistory");
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

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.CalculationHistory", b =>
                {
                    b.Navigation("CalculateModelHistories");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ConstantsHistory", b =>
                {
                    b.Navigation("CalculationHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ModuleHistory", b =>
                {
                    b.Navigation("CalculationHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.ProductHistory", b =>
                {
                    b.Navigation("CalculationHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.RATHistory", b =>
                {
                    b.Navigation("CalculationHistory");
                });

            modelBuilder.Entity("GRP.Services.WaterTankCalculator.Entities.Concrete.History.TotalCostHistory", b =>
                {
                    b.Navigation("CalculationHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
