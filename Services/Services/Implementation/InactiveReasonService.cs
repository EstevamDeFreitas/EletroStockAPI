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
    public class InactiveReasonService : ServiceBase, IInactiveReasonService
    {
        private readonly IMapper _mapper;
        public InactiveReasonService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public void CreateInactiveReason(InactiveReasonDTO inactiveReason)
        {
            var inactiveReasonCreate = _mapper.Map<InactiveReason>(inactiveReason);
            inactiveReasonCreate.Generate();

            _repository.InactiveReasonRepository.Create(inactiveReasonCreate);
            _repository.Save();
        }

        public void DeleteInactiveReason(Guid id)
        {
            var deleteReason = _repository.InactiveReasonRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if(deleteReason is null)
            {
                throw new NotFound("Inactive Reason");
            }

            _repository.InactiveReasonRepository.Delete(deleteReason);
            _repository.Save();
        }

        public InactiveReasonDTO GetInactiveReason(Guid id)
        {
            var inactiveReason = _repository.InactiveReasonRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (inactiveReason is null)
            {
                throw new NotFound("Inactive Reason");
            }

            return _mapper.Map<InactiveReasonDTO>(inactiveReason);
        }

        public List<InactiveReasonDTO> GetInactiveReasons()
        {
            var inactiveReason = _repository.InactiveReasonRepository.GetAll().ToList();

            return _mapper.Map<List<InactiveReasonDTO>>(inactiveReason);
        }

        public void UpdateInactiveReason(InactiveReasonDTO inactiveReason)
        {
            var inactiveReasonUpdate = _repository.InactiveReasonRepository.FindByCondition(x => x.Id == inactiveReason.Id).FirstOrDefault();

            if (inactiveReasonUpdate is null)
            {
                throw new NotFound("Inactive Reason");
            }

            inactiveReasonUpdate.Description = inactiveReason.Description;
            inactiveReasonUpdate.InactiveCategoryId = inactiveReason.InactiveCategoryId;

            _repository.InactiveReasonRepository.Update(inactiveReasonUpdate);
            _repository.Save();
        }
    }
}
