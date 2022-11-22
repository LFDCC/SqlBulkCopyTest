﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SqlBulkCopyTest.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220630010038_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Field1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestTables");
                });

            modelBuilder.Entity("TestTableEf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Field1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestTableEfs");
                });
#pragma warning restore 612, 618
        }
    }
}
