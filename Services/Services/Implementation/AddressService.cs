﻿using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private IRepositoryWrapper _repository;

        public AddressService(IRepositoryWrapper repository)
        {
            _repository = repository;
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

            _repository.AddressRepository.Create(addressCreate);
            _repository.Save();
        }

        public void DeleteAddress(Guid addressId)
        {
            var addressDelete = _repository.AddressRepository.FindByCondition(x => x.Id == addressId).FirstOrDefault();

            if(addressDelete is null)
            {
                throw new NotFound("Address");
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

            _repository.AddressRepository.Update(addressFound);
            _repository.Save();
        }
    }
}
