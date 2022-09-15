using AutoMapper;
using Domain.Entities;
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
    public class PriceGroupService : ServiceBase, IPriceGroupService
    {
        private IMapper _mapper;
        public PriceGroupService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void CreatePriceGroup(PriceGroupDTO priceGroup)
        {
            var priceGroupCreate = _mapper.Map<PriceGroup>(priceGroup);

            priceGroupCreate.Generate();

            _repository.PriceGroupRepository.Create(priceGroupCreate);
            _repository.Save();
        }

        public void DeletePriceGroup(Guid id)
        {
            var priceGroupFound = _repository.PriceGroupRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if(priceGroupFound is null)
            {
                throw new NotFound("Price Group");
            }

            _repository.PriceGroupRepository.Delete(priceGroupFound);
            _repository.Save();
        }

        public PriceGroupDTO GetPriceGroup(Guid id)
        {
            var priceGroupFound = _repository.PriceGroupRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (priceGroupFound is null)
            {
                throw new NotFound("Price Group");
            }

            return _mapper.Map<PriceGroupDTO>(priceGroupFound);
        }

        public List<PriceGroupDTO> GetPriceGroups()
        {
            var priceGroups = _repository.PriceGroupRepository.GetAll().ToList();

            return _mapper.Map<List<PriceGroupDTO>>(priceGroups);
        }

        public void UpdatePriceGroup(PriceGroupDTO priceGroup)
        {
            var priceGroupFound = _repository.PriceGroupRepository.FindByCondition(x => x.Id == priceGroup.Id).FirstOrDefault();

            if (priceGroupFound is null)
            {
                throw new NotFound("Price Group");
            }

            priceGroupFound.Description = priceGroup.Description;
            priceGroupFound.ProfitMargin = priceGroup.ProfitMargin;
            priceGroupFound.Name = priceGroup.Name;

            _repository.PriceGroupRepository.Update(priceGroupFound);
            _repository.Save();
        }
    }
}
