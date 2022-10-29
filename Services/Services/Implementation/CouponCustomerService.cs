using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Coupon;
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

        public void CreateCoupon(CouponDTO coupon)
        {
            var couponCreate = _mapper.Map<Coupon>(coupon);
            couponCreate.Generate();

            _repository.CouponRepository.Create(couponCreate);
            _repository.Save();
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

        public void DeleteCoupon(Guid couponId)
        {
            var couponCustomers = _repository.CouponCustomerRepository.GetCouponsFullInfo(new List<Guid> { couponId });

            if(couponCustomers == null)
            {
                var coupon = _repository.CouponRepository.FindByCondition(x => x.Id == couponId).FirstOrDefault();

                _repository.CouponRepository.Delete(coupon);
                _repository.Save();
            }
            else
            {
                throw new CouponIsInUseException();
            }
        }

        public List<CouponDTO> GetCoupons()
        {
            var coupons = _repository.CouponRepository.GetAll();

            return _mapper.Map<List<CouponDTO>>(coupons);
        }

        public List<CouponCustomerDTO> GetCustomerCoupons(Guid customerId)
        {
            var coupons = _repository.CouponCustomerRepository.GetCustomerCoupons(customerId);

            return _mapper.Map<List<CouponCustomerDTO>>(coupons);
        }

        public void SendCouponToCustomer(Guid couponId, Guid customerId)
        {
            var coupon = _repository.CouponRepository.FindByCondition(x => x.Id == couponId).FirstOrDefault();

            var couponCustomer = new CouponCustomer
            {
                CouponId = coupon.Id,
                CustomerId = customerId,
                ValueRemaining = coupon.Value
            };

            couponCustomer.Generate();

            _repository.CouponCustomerRepository.Create(couponCustomer);
            _repository.Save();
        }

        public void UpdateCoupon(CouponDTO coupon)
        {
            var counponFound = _repository.CouponRepository.FindByCondition(x => x.Id == coupon.Id).FirstOrDefault();

            counponFound.HasValidity = coupon.HasValidity;
            counponFound.Validity = coupon.Validity;
            counponFound.Value = coupon.Value;
            counponFound.Name = coupon.Name;
            counponFound.CouponType = coupon.CouponType;
            counponFound.DateModification = DateTime.Now;

            _repository.CouponRepository.Update(counponFound);
            _repository.Save();
        }
    }
}
