﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServiceOne.Engine.DbContexts;

namespace EFMigrationExample.Migrations.ServiceOne
{
    [DbContext(typeof(ServiceOneDbContext))]
    [Migration("20210519182347_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ServiceOne.Engine.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Cars","ServiceOne");
                });

            modelBuilder.Entity("ServiceOne.Engine.Entities.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarModels","ServiceOne");
                });

            modelBuilder.Entity("ServiceOne.Engine.Entities.Car", b =>
                {
                    b.HasOne("ServiceOne.Engine.Entities.CarModel", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
