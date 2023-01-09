﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teploobmen.Data;

#nullable disable

namespace Teploobmen.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230108224912_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("Teploobmen.Data.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("C")
                        .HasColumnType("REAL");

                    b.Property<double>("Cm")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<double>("Gm")
                        .HasColumnType("REAL");

                    b.Property<double>("H")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("T")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("a")
                        .HasColumnType("REAL");

                    b.Property<double>("d")
                        .HasColumnType("REAL");

                    b.Property<double>("t1")
                        .HasColumnType("REAL");

                    b.Property<double>("w")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Teploobmen.Data.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}