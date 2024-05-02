﻿// <auto-generated />
using System;
using Covid.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Covid.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240327211547_covidFK")]
    partial class covidFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Covid.Core.Entities.CovidDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PositiveD")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RecoveryD")
                        .HasColumnType("datetime2");

                    b.Property<int>("numOfVaccine")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Covids");
                });

            modelBuilder.Entity("Covid.Core.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CovidDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumAdress")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CovidDetailsId")
                        .IsUnique()
                        .HasFilter("[CovidDetailsId] IS NOT NULL");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Covid.Core.Entities.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Covid.Core.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CovidDetailsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CovidDetailsId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("Covid.Core.Entities.Member", b =>
                {
                    b.HasOne("Covid.Core.Entities.CovidDetails", "CovidDetails")
                        .WithOne("Member")
                        .HasForeignKey("Covid.Core.Entities.Member", "CovidDetailsId");

                    b.Navigation("CovidDetails");
                });

            modelBuilder.Entity("Covid.Core.Vaccine", b =>
                {
                    b.HasOne("Covid.Core.Entities.CovidDetails", "CovidDetails")
                        .WithMany("Vaccines")
                        .HasForeignKey("CovidDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Covid.Core.Entities.Producer", "Producer")
                        .WithMany("Vaccines")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CovidDetails");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Covid.Core.Entities.CovidDetails", b =>
                {
                    b.Navigation("Member")
                        .IsRequired();

                    b.Navigation("Vaccines");
                });

            modelBuilder.Entity("Covid.Core.Entities.Producer", b =>
                {
                    b.Navigation("Vaccines");
                });
#pragma warning restore 612, 618
        }
    }
}
