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
    public class CustomerService : ICustomerService
    {
        private IRepositoryWrapper _repository;

        public CustomerService(IRepositoryWrapper repository)
        {
            _repository = repository;
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

            //TODO adicionar validação dos campos
            _repository.CustomerRepository.Create(customerCreate);
            _repository.Save();
        }

        public void DeleteCustomer(string email)
        {
            var customerFound = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == email.ToLower());

            _repository.CustomerRepository.Delete((Customer)customerFound);
            _repository.Save();
        }

        public CustomerDTO GetCustomer(string email)
        {
            var customerFound = _repository.CustomerRepository.FindByCondition(x => x.Email.ToLower() == email.ToLower())
                                                                    .Select(x => new CustomerDTO
                                                                    {
                                                                        BirthDate = x.BirthDate,
                                                                        CPF =x.CPF,
                                                                        Email=x.Email,
                                                                        Gender=x.Gender,
                                                                        Name=x.Name,
                                                                        PhoneCode = x.PhoneCode,    
                                                                        PhoneType = x.PhoneType,
                                                                        PhoneNumber = x.PhoneNumber,    
                                                                        Ranking=x.Ranking
                                                                    }).FirstOrDefault();



            return customerFound;
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            var customerUpdate = new Customer
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

            _repository.CustomerRepository.Update(customerUpdate);
            _repository.Save();
        }
    }
}
