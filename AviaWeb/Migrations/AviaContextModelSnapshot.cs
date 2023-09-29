﻿// <auto-generated />
using System;
using AviaWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AviaWeb.Migrations
{
    [DbContext(typeof(AviaContext))]
    partial class AviaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AviaWeb.Models.AirTicket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Arrival")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfConclusion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("AirTickets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Arrival = "SaintPetersburg",
                            ArrivalDate = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Company = "AeroFlight",
                            DateOfConclusion = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Departure = "Moscow",
                            DepartureDate = new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassengerId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Arrival = "Moscow",
                            ArrivalDate = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Company = "TopAirlines",
                            DateOfConclusion = new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Departure = "Samara",
                            DepartureDate = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassengerId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Arrival = "Ekaterinburg",
                            ArrivalDate = new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Company = "AeroFlight",
                            DateOfConclusion = new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Departure = "Tumen",
                            DepartureDate = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassengerId = 2L
                        },
                        new
                        {
                            Id = 4L,
                            Arrival = "Ekaterinburg",
                            ArrivalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Company = "TopAirlines",
                            DateOfConclusion = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Departure = "Tumen",
                            DepartureDate = new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassengerId = 3L
                        },
                        new
                        {
                            Id = 5L,
                            Arrival = "Moscow",
                            ArrivalDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Company = "SevenAirlines",
                            DateOfConclusion = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Departure = "Kurgan",
                            DepartureDate = new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PassengerId = 4L
                        });
                });

            modelBuilder.Entity("AviaWeb.Models.Document", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("PassengerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            PassengerId = 1L,
                            Type = "Passport1"
                        },
                        new
                        {
                            Id = 2L,
                            PassengerId = 1L,
                            Type = "Passport2"
                        },
                        new
                        {
                            Id = 3L,
                            PassengerId = 2L,
                            Type = "Passport3"
                        },
                        new
                        {
                            Id = 4L,
                            PassengerId = 3L,
                            Type = "Passport4"
                        },
                        new
                        {
                            Id = 5L,
                            PassengerId = 3L,
                            Type = "Passport5"
                        },
                        new
                        {
                            Id = 6L,
                            PassengerId = 3L,
                            Type = "Passport6"
                        });
                });

            modelBuilder.Entity("AviaWeb.Models.Passenger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronical")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "FN1",
                            LastName = "LN1",
                            Patronical = "PAT1"
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "FN2",
                            LastName = "LN2",
                            Patronical = "PAT2"
                        },
                        new
                        {
                            Id = 3L,
                            FirstName = "FN3",
                            LastName = "LN3",
                            Patronical = "PAT3"
                        },
                        new
                        {
                            Id = 4L,
                            FirstName = "FN4",
                            LastName = "LN4",
                            Patronical = "PAT4"
                        },
                        new
                        {
                            Id = 5L,
                            FirstName = "FN5",
                            LastName = "LN5",
                            Patronical = "PAT5"
                        });
                });

            modelBuilder.Entity("AviaWeb.Models.AirTicket", b =>
                {
                    b.HasOne("AviaWeb.Models.Passenger", "Passenger")
                        .WithMany("AirTickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AviaWeb.Models.Document", b =>
                {
                    b.HasOne("AviaWeb.Models.Passenger", "Passenger")
                        .WithMany("Documents")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AviaWeb.Models.Passenger", b =>
                {
                    b.Navigation("AirTickets");

                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
