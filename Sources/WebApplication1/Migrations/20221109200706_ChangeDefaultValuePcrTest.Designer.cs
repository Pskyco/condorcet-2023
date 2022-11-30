﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Persistence;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(PcrContext))]
    [Migration("20221109200706_ChangeDefaultValuePcrTest")]
    partial class ChangeDefaultValuePcrTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("WebApplication1.Entities.PcrTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AnalysisDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnalysisResultEnum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("LogisticStatusEnum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PerformerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReceptionDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SamplingDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerformerId");

                    b.ToTable("PcrTests");
                });

            modelBuilder.Entity("WebApplication1.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Firstname = "Ludwig",
                            Lastname = "Lebrun"
                        },
                        new
                        {
                            Id = 2,
                            Firstname = "Hicham",
                            Lastname = "Erradi"
                        });
                });

            modelBuilder.Entity("WebApplication1.Entities.PcrTest", b =>
                {
                    b.HasOne("WebApplication1.Entities.User", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Performer");
                });
#pragma warning restore 612, 618
        }
    }
}
