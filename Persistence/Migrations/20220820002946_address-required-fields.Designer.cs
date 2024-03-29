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
    [Migration("20220820002946_address-required-fields")]
    partial class addressrequiredfields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("address_type");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("country");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("district");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("street");

                    b.Property<string>("StreetType")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("street_type");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("etk_addresses");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

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
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

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

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
