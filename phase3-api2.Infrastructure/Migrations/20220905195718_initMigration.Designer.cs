﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using phase3_api2.Infrastructure;

#nullable disable

namespace phase3_api2.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220905195718_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("phase3_api2.Domain.Model.Prod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeExpire")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStored")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeTaken")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isWasted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Prods");
                });
#pragma warning restore 612, 618
        }
    }
}
