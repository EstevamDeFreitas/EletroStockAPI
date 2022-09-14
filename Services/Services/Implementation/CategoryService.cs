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
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public void CreateCategory(CategoryDTO category)
        {
            var categoryCreate = _mapper.Map<Category>(category);
            categoryCreate.Generate();

            _repository.CategoryRepository.Create(categoryCreate);
            _repository.Save();
        }

        public void DeleteCategory(Guid id)
        {
            var categoryDelete = _repository.CategoryRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if(categoryDelete is null)
            {
                throw new NotFound("Category");
            }

            _repository.CategoryRepository.Delete(categoryDelete);
            _repository.Save();
        }

        public List<CategoryDTO> GetCategories()
        {
            var categoriesFound = _repository.CategoryRepository.GetAll().ToList();

            return _mapper.Map<List<CategoryDTO>>(categoriesFound);
        }

        public CategoryDTO GetCategory(Guid id)
        {
            var categoryFound = _repository.CategoryRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (categoryFound is null)
            {
                throw new NotFound("Category");
            }

            return _mapper.Map<CategoryDTO>(categoryFound);
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var categoryFound = _repository.CategoryRepository.FindByCondition(x => x.Id == category.Id).FirstOrDefault();

            if (categoryFound is null)
            {
                throw new NotFound("Category");
            }

            categoryFound.Description = category.Description;
            categoryFound.Name = category.Name;

            _repository.CategoryRepository.Update(categoryFound);
            _repository.Save();
        }
    }
}
