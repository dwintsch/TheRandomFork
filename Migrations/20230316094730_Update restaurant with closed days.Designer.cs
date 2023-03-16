﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheRandomFork.Data;

#nullable disable

namespace TheRandomFork.Migrations
{
    [DbContext(typeof(RandomForkDbContext))]
    [Migration("20230316094730_Update restaurant with closed days")]
    partial class Updaterestaurantwithcloseddays
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheRandomFork.Models.Domain.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Homepage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Road")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("TheRandomFork.Models.Domain.RestaurantClosedDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClosedDay")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantClosedDay");
                });

            modelBuilder.Entity("TheRandomFork.Models.Domain.RestaurantHistoryEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantHistory");
                });

            modelBuilder.Entity("TheRandomFork.Models.Domain.RestaurantClosedDay", b =>
                {
                    b.HasOne("TheRandomFork.Models.Domain.Restaurant", "Restaurant")
                        .WithMany("ClosedDays")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("TheRandomFork.Models.Domain.RestaurantHistoryEntry", b =>
                {
                    b.HasOne("TheRandomFork.Models.Domain.Restaurant", "Restaurant")
                        .WithMany("History")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("TheRandomFork.Models.Domain.Restaurant", b =>
                {
                    b.Navigation("ClosedDays");

                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
