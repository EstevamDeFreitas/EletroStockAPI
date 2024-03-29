﻿using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Customer;
using Services.Exceptions.Shared;
using Services.Services.Interfaces;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryWrapper repository) : base(repository)
        {
        }

        public void CreateCustomer(CustomerDTO customer)
        {
            var customerCreate = new Customer
            {
                BirthDate = customer.BirthDate,
                CPF = customer.CPF,
                Email = customer.Email,
                Gender = customer.Gender,
                Name = customer.Name,
                Password = customer.Password,
                PhoneCode = customer.PhoneCode,
                PhoneNumber = customer.PhoneNumber,
                PhoneType = customer.PhoneType,
                Ranking = customer.Ranking
            };

            customerCreate.Generate();

            var customerValidator = new CustomerValidator();

            if (!customerValidator.Validate(customerCreate).IsValid)
            {
                throw new ValidationFailed(customerValidator.Validate(customerCreate).Errors, "Customer");
            }

            var customerAccount = new CustomerAccount()
            {
                CustomerId = customerCreate.Id
            };

            customerAccount.Generate();

            _repository.CustomerRepository.Create(customerCreate);
            _repository.CustomerAccountRepository.Create(customerAccount);
            _repository.Save();
        }

        public void DeleteCustomer(string email)
        {
            var customerFound = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            if (customerFound is null)
            {
                throw new CustomerNotFound();
            }

            _repository.CustomerRepository.Delete(customerFound);
            _repository.Save();
        }

        public CustomerDTO GetCustomer(Guid customerId)
        {
            var customerFound = _repository.CustomerRepository.GetCustomer(customerId);

            if(customerFound is null)
            {
                throw new NotFound("Customer");
            }

            CustomerDTO customerDto = new CustomerDTO
            {
                Email = customerFound.Email,
                BirthDate = customerFound.BirthDate,
                CPF = customerFound.CPF,
                CustomerAccount = new CustomerAccountDTO
                {
                    CustomerId = customerFound.CustomerAccount.CustomerId,
                    DefaultChargeAddressId = customerFound.CustomerAccount.DefaultChargeAddressId,
                    DefaultCreditCardId = customerFound.CustomerAccount.DefaultCreditCardId,
                    DefaultDeliveryAddressId = customerFound.CustomerAccount.DefaultDeliveryAddressId,
                    Id = customerFound.CustomerAccount.Id
                },
                Gender = customerFound.Gender,
                Name = customerFound.Name,
                Password = customerFound.Password,
                PhoneCode = customerFound.PhoneCode,
                PhoneNumber = customerFound.PhoneNumber,
                PhoneType = customerFound.PhoneType,
                Ranking = customerFound.Ranking,
                Addresses = customerFound.Addresses.Select(x => new AddressDTO 
                { 
                    AddressType = x.AddressType,
                    CEP = x.CEP,
                    City = x.City,
                    Country = x.Country,
                    CustomerId = x.CustomerId,
                    Description = x.Description,
                    District = x.District,
                    Id = x.Id,
                    Number = x.Number,
                    State = x.State,
                    Street = x.Street,
                    StreetType = x.StreetType
                }).ToList(),
                CreditCards = customerFound.CreditCards.Select(x => new CreditCardDTO 
                { 
                    CardFlagId = x.CardFlagId,
                    CardNumber = x.CardNumber,
                    Id = x.Id,
                    OwnerName = x.OwnerName,
                    SecurityCode = x.SecurityCode,
                    CustomerId = x.CustomerId
                }).ToList()
            };

            return customerDto;
        }

        public List<CustomerDTO> GetCustomers()
        {
            var customersList = _repository.CustomerRepository.GetAll().Select(x => new CustomerDTO
                                                                                {
                                                                                    BirthDate = x.BirthDate,
                                                                                    CPF = x.CPF,
                                                                                    Email = x.Email,
                                                                                    Gender = x.Gender,
                                                                                    Name = x.Name,
                                                                                    PhoneCode = x.PhoneCode,
                                                                                    PhoneType = x.PhoneType,
                                                                                    PhoneNumber = x.PhoneNumber,
                                                                                    Ranking = x.Ranking
                                                                                }).ToList();

            return customersList;
        }

        public Guid LoginCustomer(string email, string password)
        {
            var customerFound = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();

            if(customerFound is null)
            {
                throw new NotFound("Customer");
            }

            return customerFound.Id;
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            var customerUpdate = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == customer.Email.ToLower()).FirstOrDefault();

            if(customerUpdate is null)
            {
                throw new CustomerNotFound();
            }

            customerUpdate.BirthDate = customer.BirthDate;
            customerUpdate.CPF = customer.CPF;
            customerUpdate.Email = customer.Email;
            customerUpdate.Gender = customer.Gender;
            customerUpdate.Name = customer.Name;
            //customerUpdate.Password = customer.Password;
            customerUpdate.PhoneCode = customer.PhoneCode;
            customerUpdate.PhoneNumber = customer.PhoneNumber;
            customerUpdate.PhoneType = customer.PhoneType;
            customerUpdate.Ranking = customer.Ranking;
            customerUpdate.DateModification = DateTime.Now;

            var customerValidator = new CustomerValidator();

            if (!customerValidator.Validate(customerUpdate).IsValid)
            {
                throw new ValidationFailed(customerValidator.Validate(customerUpdate).Errors, "Customer");
            }

            _repository.CustomerRepository.Update(customerUpdate);
            _repository.Save();
        }

        public void ChangePassword(CustomerChangePasswordDTO customerChangePassword)
        {
            var customerUpdate = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == customerChangePassword.Email.ToLower() && x.Password == customerChangePassword.CurrentPassword).FirstOrDefault();

            if (customerUpdate is null)
            {
                throw new CustomerNotFound();
            }

            customerUpdate.Password = customerChangePassword.NewPassword;

            _repository.CustomerRepository.Update(customerUpdate);
            _repository.Save();
        }

        public void ChangeAccountSettings(CustomerAccountDTO customerAccount)
        {
            var customerAccountFound = _repository.CustomerAccountRepository.FindByCondition(x => x.Id == customerAccount.Id).FirstOrDefault();

            if(customerAccountFound is null)
            {
                throw new NotFound("Customer Account");
            }

            customerAccountFound.DefaultCreditCardId = customerAccount.DefaultCreditCardId;
            customerAccountFound.DefaultChargeAddressId = customerAccount.DefaultChargeAddressId;
            customerAccountFound.DefaultDeliveryAddressId = customerAccount.DefaultDeliveryAddressId;

            _repository.CustomerAccountRepository.Update(customerAccountFound);
            _repository.Save();
        }
    }
}
