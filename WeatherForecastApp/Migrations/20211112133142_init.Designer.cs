﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecastApp.Models.DbStorage;

namespace WeatherForecastApp.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20211112133142_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.DaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Day");

                    b.Property<string>("LanguageDay")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DaysOfWeek");
                });

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.SearchCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CityName");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("SearchCity");
                });

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.WeatherInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DayId")
                        .HasColumnType("int")
                        .HasColumnName("dayId");

                    b.Property<decimal?>("TempMax")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("Temp_max");

                    b.Property<decimal?>("TempMin")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("Temp_min");

                    b.Property<decimal?>("Temperatura")
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("WeatherInfo");
                });

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.WeatherInfo", b =>
                {
                    b.HasOne("WeatherForecastApp.Models.DbStorage.DaysOfWeek", "Day")
                        .WithMany("WeathersInfo")
                        .HasForeignKey("DayId")
                        .HasConstraintName("FK__Weather__dayId__36B12243");

                    b.Navigation("Day");
                });

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.DaysOfWeek", b =>
                {
                    b.Navigation("WeathersInfo");
                });
#pragma warning restore 612, 618
        }
    }
}