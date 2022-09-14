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
    public class InactiveCategoryService : ServiceBase, IInactiveCategoryService
    {
        private readonly IMapper _mapper;
        public InactiveCategoryService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void CreateInactiveCategory(InactiveCategoryDTO inactiveCategory)
        {
            var inactiveCategoryEntity = _mapper.Map<InactiveCategory>(inactiveCategory);
            inactiveCategoryEntity.Generate();

            _repository.InactiveCategoryRepository.Create(inactiveCategoryEntity);
            _repository.Save();
        }

        public void DeleteInactiveCategory(Guid id)
        {
            var inactiveCategory = _repository.InactiveCategoryRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (inactiveCategory is null)
            {
                throw new NotFound("Inactive Category");
            }

            _repository.InactiveCategoryRepository.Delete(inactiveCategory);
            _repository.Save();
        }

        public List<InactiveCategoryDTO> GetInactiveCategories()
        {
            var inactiveCategories = _mapper.Map<List<InactiveCategoryDTO>>(_repository.InactiveCategoryRepository.GetAll().ToList());

            return inactiveCategories;
        }

        public InactiveCategoryDTO GetInactiveCategory(Guid id)
        {
            var inactiveCategory = _repository.InactiveCategoryRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if(inactiveCategory is null)
            {
                throw new NotFound("Inactive Category");
            }

            return _mapper.Map<InactiveCategoryDTO>(inactiveCategory);
        }

        public void UpdateInactiveCategory(InactiveCategoryDTO inactiveCategory)
        {
            var inactiveCategoryEdit = _repository.InactiveCategoryRepository.FindByCondition(x => x.Id == inactiveCategory.Id).FirstOrDefault();

            if (inactiveCategoryEdit is null)
            {
                throw new NotFound("Inactive Category");
            }

            inactiveCategoryEdit.Active = inactiveCategory.Active;
            inactiveCategoryEdit.Description = inactiveCategory.Description;
            inactiveCategoryEdit.Name = inactiveCategory.Name;
            inactiveCategoryEdit.DateModification = DateTime.Now;

            _repository.InactiveCategoryRepository.Update(inactiveCategoryEdit);
            _repository.Save();
        }
    }
}
