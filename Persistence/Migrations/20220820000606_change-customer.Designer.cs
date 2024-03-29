﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Database;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(EletroStockContext))]
    [Migration("20220820000606_change-customer")]
    partial class changecustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("etk_id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("etk_dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("etk_dt_modified");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<char>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<decimal>("PhoneCode")
                        .HasMaxLength(3)
                        .HasColumnType("numeric")
                        .HasColumnName("phone_code");

                    b.Property<decimal>("PhoneNumber")
                        .HasMaxLength(9)
                        .HasColumnType("numeric")
                        .HasColumnName("phone_number");

                    b.Property<string>("PhoneType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone_type");

                    b.Property<int>("Ranking")
                        .HasColumnType("integer")
                        .HasColumnName("ranking");

                    b.HasKey("Id");

                    b.ToTable("etk_customers");
                });
#pragma warning restore 612, 618
        }
    }
}
