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
    [Migration("20220921210156_updated-cart-item")]
    partial class updatedcartitem
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
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("etk_card_flags");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("etk_categories");
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
                        .HasColumnName("security_code");

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

                    b.Property<Guid?>("DefaultChargeAddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_charge_address_id");

                    b.Property<Guid?>("DefaultCreditCardId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_credit_card_id");

                    b.Property<Guid?>("DefaultDeliveryAddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_delivery_address_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("DefaultChargeAddressId");

                    b.HasIndex("DefaultCreditCardId")
                        .IsUnique();

                    b.HasIndex("DefaultDeliveryAddressId");

                    b.ToTable("etk_customer_accounts");
                });

            modelBuilder.Entity("Domain.Entities.InactiveCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("etk_inactive_categories");
                });

            modelBuilder.Entity("Domain.Entities.InactiveReason", b =>
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<Guid>("InactiveCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("inactive_category_id");

                    b.HasKey("Id");

                    b.HasIndex("InactiveCategoryId");

                    b.ToTable("etk_inactive_reasons");
                });

            modelBuilder.Entity("Domain.Entities.PriceGroup", b =>
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("ProfitMargin")
                        .HasColumnType("numeric")
                        .HasColumnName("profit_margin");

                    b.HasKey("Id");

                    b.ToTable("etk_price_groups");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("code");

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

                    b.Property<Guid?>("InactiveReasonId")
                        .HasColumnType("uuid")
                        .HasColumnName("inactive_reason_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<Guid>("PriceGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("price_group_id");

                    b.HasKey("Id");

                    b.HasIndex("InactiveReasonId");

                    b.HasIndex("PriceGroupId");

                    b.ToTable("etk_products");
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("etk_product_categories");
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
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

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("etk_product_images");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CartValidity")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_cart_validity");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_creation");

                    b.Property<DateTime>("DateModification")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_modified");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("etk_shopping_carts");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCartItem", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uuid")
                        .HasColumnName("shopping_cart_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("ProductId", "ShoppingCartId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("etk_shopping_cart_items");
                });

            modelBuilder.Entity("Domain.Entities.Stock", b =>
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

                    b.Property<DateTime>("InputDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_input");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("source_name");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("etk_stocks");
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
                        .WithMany()
                        .HasForeignKey("DefaultChargeAddressId");

                    b.HasOne("Domain.Entities.CreditCard", "DefaultCreditCard")
                        .WithOne("CustomerAccount")
                        .HasForeignKey("Domain.Entities.CustomerAccount", "DefaultCreditCardId");

                    b.HasOne("Domain.Entities.Address", "DefaultDeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DefaultDeliveryAddressId");

                    b.Navigation("Customer");

                    b.Navigation("DefaultChargeAddress");

                    b.Navigation("DefaultCreditCard");

                    b.Navigation("DefaultDeliveryAddress");
                });

            modelBuilder.Entity("Domain.Entities.InactiveReason", b =>
                {
                    b.HasOne("Domain.Entities.InactiveCategory", "InactiveCategory")
                        .WithMany("InactiveReasons")
                        .HasForeignKey("InactiveCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InactiveCategory");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.InactiveReason", "InactiveReason")
                        .WithMany()
                        .HasForeignKey("InactiveReasonId");

                    b.HasOne("Domain.Entities.PriceGroup", "PriceGroup")
                        .WithMany("Products")
                        .HasForeignKey("PriceGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InactiveReason");

                    b.Navigation("PriceGroup");
                });

            modelBuilder.Entity("Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCart", b =>
                {
                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Domain.Entities.Stock", b =>
                {
                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.CardFlag", b =>
                {
                    b.Navigation("CreditCards");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
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

            modelBuilder.Entity("Domain.Entities.InactiveCategory", b =>
                {
                    b.Navigation("InactiveReasons");
                });

            modelBuilder.Entity("Domain.Entities.PriceGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductImages");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Domain.Entities.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
