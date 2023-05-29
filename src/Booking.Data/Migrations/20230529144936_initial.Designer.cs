﻿// <auto-generated />
using System;
using Booking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.Data.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20230529144936_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservedById")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservedById");

                    b.HasIndex("TripId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "City 1",
                            Content = "<p>Content 1</p>",
                            CreationDate = new DateTime(2023, 5, 29, 17, 49, 36, 524, DateTimeKind.Local).AddTicks(5887),
                            ImageUrl = "https://example.com/image1.jpg",
                            Name = "Trip 1",
                            Price = 100m
                        },
                        new
                        {
                            Id = 2,
                            CityName = "City 2",
                            Content = "<p>Content 2</p>",
                            CreationDate = new DateTime(2023, 5, 29, 17, 49, 36, 524, DateTimeKind.Local).AddTicks(5946),
                            ImageUrl = "https://example.com/image2.jpg",
                            Name = "Trip 2",
                            Price = 200m
                        });
                });

            modelBuilder.Entity("Booking.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user1@example.com",
                            Password = "password1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user2@example.com",
                            Password = "password2"
                        });
                });

            modelBuilder.Entity("Booking.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Booking.Domain.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Domain.Entities.Trip", "Trip")
                        .WithMany("Reservations")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Booking.Domain.Entities.Trip", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Booking.Domain.Entities.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}