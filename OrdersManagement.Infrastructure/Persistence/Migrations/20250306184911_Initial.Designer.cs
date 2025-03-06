﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrdersManagement.Infrastructure.Persistence;

#nullable disable

namespace OrdersManagement.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250306184911_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrdersManagement.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RecipientAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipientCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasPrecision(18, 2)
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
