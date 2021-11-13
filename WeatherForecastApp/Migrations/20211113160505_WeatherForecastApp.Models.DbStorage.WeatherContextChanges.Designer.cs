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
    [Migration("20211113160505_WeatherForecastApp.Models.DbStorage.WeatherContextChanges")]
    partial class WeatherForecastAppModelsDbStorageWeatherContextChanges
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Day = "Monday",
                            LanguageDay = "en",
                            OrderNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Day = "Понеделник",
                            LanguageDay = "mk",
                            OrderNumber = 1
                        },
                        new
                        {
                            Id = 3,
                            Day = "Tuesday",
                            LanguageDay = "en",
                            OrderNumber = 2
                        },
                        new
                        {
                            Id = 4,
                            Day = "Вторник",
                            LanguageDay = "mk",
                            OrderNumber = 2
                        },
                        new
                        {
                            Id = 5,
                            Day = "Wednesday",
                            LanguageDay = "en",
                            OrderNumber = 3
                        },
                        new
                        {
                            Id = 6,
                            Day = "Среда",
                            LanguageDay = "mk",
                            OrderNumber = 3
                        },
                        new
                        {
                            Id = 7,
                            Day = "Thurstdau",
                            LanguageDay = "en",
                            OrderNumber = 4
                        },
                        new
                        {
                            Id = 8,
                            Day = "Четврток",
                            LanguageDay = "mk",
                            OrderNumber = 4
                        },
                        new
                        {
                            Id = 9,
                            Day = "Friday",
                            LanguageDay = "en",
                            OrderNumber = 5
                        },
                        new
                        {
                            Id = 10,
                            Day = "Петок",
                            LanguageDay = "mk",
                            OrderNumber = 5
                        },
                        new
                        {
                            Id = 11,
                            Day = "Saturday",
                            LanguageDay = "en",
                            OrderNumber = 6
                        },
                        new
                        {
                            Id = 12,
                            Day = "Сабота",
                            LanguageDay = "mk",
                            OrderNumber = 6
                        },
                        new
                        {
                            Id = 13,
                            Day = "Sunday",
                            LanguageDay = "en",
                            OrderNumber = 7
                        },
                        new
                        {
                            Id = 14,
                            Day = "Недела",
                            LanguageDay = "mk",
                            OrderNumber = 7
                        });
                });

            modelBuilder.Entity("WeatherForecastApp.Models.DbStorage.WeatherInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DayId")
                        .HasColumnType("int")
                        .HasColumnName("dayId");

                    b.Property<decimal>("TempMax")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("Temp_max");

                    b.Property<decimal>("TempMin")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("Temp_min");

                    b.Property<decimal>("Temperatura")
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