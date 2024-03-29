﻿using AutoMapper;
using Domain.Entities;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class MapperConfig : MapperConfigurationExpression
    {
        public MapperConfig()
        {
            CreateMap<InactiveCategoryDTO, InactiveCategory>().ReverseMap();
            CreateMap<InactiveReasonDTO, InactiveReason>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<PriceGroupDTO, PriceGroup>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CreditCardDTO, CreditCard>().ReverseMap();
            CreateMap<ProductCategoryDTO, ProductCategory>().ReverseMap();
            CreateMap<ProductImageDTO, ProductImage>().ReverseMap();
            CreateMap<StockDTO, Stock>().ReverseMap();
            CreateMap<ProductStockDTO, Product>().ReverseMap();
            CreateMap<ShoppingCartDTO, ShoppingCart>().ReverseMap();
            CreateMap<ShoppingCartItemDTO, ShoppingCartItem>().ReverseMap();
            CreateMap<SaleDTO, Sale>().ReverseMap();
            CreateMap<SaleItemSummaryDTO, SaleItem>().ReverseMap();
            CreateMap<SaleItemDTO, SaleItem>().ReverseMap();
            CreateMap<SalePaymentDTO, SalePayment>().ReverseMap();
            CreateMap<SaleCouponDTO, SaleCoupon>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<Coupon, CouponDTO>().ReverseMap();
            CreateMap<CouponCustomer, CouponCustomerDTO>().ReverseMap();
        }
    }
}
