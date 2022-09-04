using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Address;
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
    public class AddressService : ServiceBase, IAddressService
    {
        public AddressService(IRepositoryWrapper repository) : base(repository)
        {
        }

        public void CreateAddress(AddressDTO addressDTO)
        {
            var addressCreate = new Address
            {
                CEP = addressDTO.CEP,
                City = addressDTO.City,
                AddressType = addressDTO.AddressType,
                Country = addressDTO.Country,
                CustomerId = addressDTO.CustomerId,
                Description = addressDTO.Description,
                District = addressDTO.District,
                Number = addressDTO.Number,
                State = addressDTO.State,
                Street = addressDTO.Street,
                StreetType = addressDTO.StreetType
            };

            addressCreate.Generate();

            var addressValidator = new AddressValidator();

            if (!addressValidator.Validate(addressCreate).IsValid)
            {
                throw new ValidationFailed(addressValidator.Validate(addressCreate).Errors, "Address");
            }

            _repository.AddressRepository.Create(addressCreate);
            _repository.Save();

            if (_repository.AddressRepository.FindByCondition(x => x.CustomerId == addressCreate.CustomerId).ToList().Count() == 1)
            {
                var customerAccount = _repository.CustomerAccountRepository.FindByCondition(x => x.CustomerId == addressCreate.CustomerId).FirstOrDefault();

                if(customerAccount is not null)
                {
                    customerAccount.DefaultChargeAddressId = addressCreate.Id;
                    customerAccount.DefaultDeliveryAddressId = addressCreate.Id;

                    _repository.CustomerAccountRepository.Update(customerAccount);
                    _repository.Save();
                }

                
            }
        }

        public void DeleteAddress(Guid addressId)
        {
            var addressDelete = _repository.AddressRepository.FindByCondition(x => x.Id == addressId).FirstOrDefault();

            if(addressDelete is null)
            {
                throw new NotFound("Address");
            }

            if(_repository.CustomerAccountRepository.FindByCondition(x => x.DefaultChargeAddressId == addressDelete.Id || x.DefaultDeliveryAddressId == addressDelete.Id).FirstOrDefault() is not null)
            {
                throw new AddressIsSetAsDefault();
            }

            _repository.AddressRepository.Delete(addressDelete);
            _repository.Save();


        }

        public AddressDTO GetAddress(Guid addressId)
        {
            var addressFound = _repository.AddressRepository.FindByCondition(x => x.Id == addressId)    
                                            .Select(x => new AddressDTO
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
                                                Street = x.Street,
                                                State = x.State,
                                                StreetType = x.StreetType
                                            })
                                            .FirstOrDefault();

            if(addressFound is null)
            {
                throw new NotFound("Address");
            }

            return addressFound;
        }

        public List<AddressDTO> GetCustomerAddresses(Guid customerId)
        {
            var addressesFound = _repository.AddressRepository.FindByCondition(x => x.CustomerId == customerId)
                                            .Select(x => new AddressDTO
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
                                                Street = x.Street,
                                                State = x.State,
                                                StreetType = x.StreetType
                                            })
                                            .ToList();

            return addressesFound;
        }

        public void UpdateAddress(AddressDTO addressDTO)
        {
            var addressFound = _repository.AddressRepository.FindByCondition(x => x.Id == addressDTO.Id).FirstOrDefault();

            if(addressFound is null)
            {
                throw new NotFound("Address");
            }

            addressFound.City = addressDTO.City;
            addressFound.Country = addressDTO.Country;
            addressFound.State = addressDTO.State;
            addressFound.Street = addressDTO.Street;
            addressFound.StreetType = addressDTO.StreetType;
            addressFound.Number = addressDTO.Number;
            addressFound.AddressType = addressDTO.AddressType;
            addressFound.CEP = addressDTO.CEP;
            addressFound.DateModification = DateTime.Now;
            addressFound.Description = addressDTO.Description;
            addressFound.District = addressDTO.District;

            var addressValidator = new AddressValidator();

            if (!addressValidator.Validate(addressFound).IsValid)
            {
                throw new ValidationFailed(addressValidator.Validate(addressFound).Errors, "Address");
            }

            _repository.AddressRepository.Update(addressFound);
            _repository.Save();
        }
    }
}
