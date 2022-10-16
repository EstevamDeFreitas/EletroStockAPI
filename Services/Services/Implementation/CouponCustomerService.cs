using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class CouponCustomerService : ServiceBase, ICouponCustomerService
    {
        private readonly IMapper _mapper;
        public CouponCustomerService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void CreateCustomerRefundCoupon(CouponDTO coupon, CouponCustomerDTO couponCustomer)
        {
            var couponCreate = _mapper.Map<Coupon>(coupon);
            couponCreate.Generate();

            var couponCustomerCreate = _mapper.Map<CouponCustomer>(couponCustomer);
            couponCustomerCreate.Generate();

            couponCustomerCreate.CouponId = couponCreate.Id;

            _repository.CouponRepository.Create(couponCreate);

            _repository.CouponCustomerRepository.Create(couponCustomerCreate);
            _repository.Save();
        }
    }
}
