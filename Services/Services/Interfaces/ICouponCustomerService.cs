﻿using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public interface ICouponCustomerService
    {
        void CreateCustomerRefundCoupon(CouponDTO coupon, CouponCustomerDTO couponCustomer);
    }
}
