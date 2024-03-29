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
    [Migration("20220824112032_change-colunm-name")]
    partial class changecolunmname
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

            modelBuilder.Entity("Domain.Entities.CardFlag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("etk_card_flags");
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CardFlagId")
                        .HasColumnType("uuid")
                        .HasColumnName("card_flag_id");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("card_number");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("owner_name");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CardFlagId");

                    b.HasIndex("CustomerId");

                    b.ToTable("etk_credit_cards");
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

            modelBuilder.Entity("Domain.Entities.CustomerAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

                    b.Property<Guid>("DefaultChargeAddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_charge_address_id");

                    b.Property<Guid>("DefaultCreditCardId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_credit_card_id");

                    b.Property<Guid>("DefaultDeliveryAddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_delivery_address_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("DefaultChargeAddressId")
                        .IsUnique();

                    b.HasIndex("DefaultCreditCardId")
                        .IsUnique();

                    b.HasIndex("DefaultDeliveryAddressId")
                        .IsUnique();

                    b.ToTable("etk_customer_accounts");
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

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Domain.Entities.CardFlag", "CardFlag")
                        .WithMany("CreditCards")
                        .HasForeignKey("CardFlagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany("CreditCards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardFlag");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.CustomerAccount", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithOne("CustomerAccount")
                        .HasForeignKey("Domain.Entities.CustomerAccount", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Address", "DefaultChargeAddress")
                        .WithOne("DefaultChargeAddressCustomerAccount")
                        .HasForeignKey("Domain.Entities.CustomerAccount", "DefaultChargeAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CreditCard", "DefaultCreditCard")
                        .WithOne("CustomerAccount")
                        .HasForeignKey("Domain.Entities.CustomerAccount", "DefaultCreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Address", "DefaultDeliveryAddress")
                        .WithOne("DefaultDeliveryAddressCustomerAccount")
                        .HasForeignKey("Domain.Entities.CustomerAccount", "DefaultDeliveryAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DefaultChargeAddress");

                    b.Navigation("DefaultCreditCard");

                    b.Navigation("DefaultDeliveryAddress");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("DefaultChargeAddressCustomerAccount")
                        .IsRequired();

                    b.Navigation("DefaultDeliveryAddressCustomerAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CardFlag", b =>
                {
                    b.Navigation("CreditCards");
                });

            modelBuilder.Entity("Domain.Entities.CreditCard", b =>
                {
                    b.Navigation("CustomerAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CreditCards");

                    b.Navigation("CustomerAccount")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
