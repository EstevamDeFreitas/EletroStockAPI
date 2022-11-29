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
    public class ProductService : ServiceBase, IProductService
    {
        private IMapper _mapper;
        public ProductService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void CreateProduct(ProductDTO product)
        {
            var productCreate = _mapper.Map<Product>(product);
            productCreate.InactiveReasonId = null;
            productCreate.Generate();

            productCreate.ProductCategories.ForEach(x => x.ProductId = productCreate.Id);
            productCreate.ProductImages.ForEach(x => {
                x.ProductId = productCreate.Id;
                x.Generate();
            });

            _repository.ProductRepository.Create(productCreate);
            _repository.Save();
        }

        public void DeleteProduct(Guid id)
        {
            var productFound = _repository.ProductRepository.GetProductFullInfo(id);

            if(productFound is null)
            {
                throw new NotFound("Product");
            }

            _repository.ProductRepository.Delete(productFound);
            _repository.Save();
        }

        public void DisableProduct(Guid id, InactiveReasonDTO inactiveReason)
        {
            var product = _repository.ProductRepository.GetProductFullInfo(id);

            if (product is null)
            {
                throw new NotFound("Product");
            }

            var inactiveReasonEntity = _mapper.Map<InactiveReason>(inactiveReason);
            inactiveReasonEntity.Generate();

            _repository.InactiveReasonRepository.Create(inactiveReasonEntity);

            product.InactiveReasonId = inactiveReasonEntity.Id;

            UpdateProduct(_mapper.Map<ProductDTO>(product));
        }

        public ProductDTO GetProduct(Guid id)
        {
            var productFound = _repository.ProductRepository.GetProductFullInfo(id);
            if (productFound is null)
            {
                throw new NotFound("Product");
            }

            return _mapper.Map<ProductDTO>(productFound);   
        }

        public List<ProductDTO> GetProducts()
        {
            var productsFound = _repository.ProductRepository.GetProductsFullInfo();

            return _mapper.Map<List<ProductDTO>>(productsFound);
        }

        public void UpdateProduct(ProductDTO product)
        {   
            var productFound = _repository.ProductRepository.GetProductFullInfo((Guid)product.Id);
            productFound.PriceGroupId = new Guid();
            if (productFound is null)
            {
                throw new NotFound("Product");
            }

            product.ProductCategories.ForEach(prodCat =>
            {
                prodCat.Category = null;
            });

            productFound.Code = product.Code;
            productFound.PriceGroupId = product.PriceGroupId;
            productFound.Description = product.Description;
            productFound.Name = product.Name;
            productFound.InactiveReasonId = product.InactiveReasonId;
            productFound.ProductCategories = _mapper.Map<List<ProductCategory>>(product.ProductCategories);
            productFound.ProductImages = _mapper.Map<List<ProductImage>>(product.ProductImages);

            productFound.PriceGroup = null;

            productFound.ProductImages.ForEach(ProdIm =>
            {
                if(ProdIm.Id == Guid.Empty)
                {
                    ProdIm.Generate();
                }
            });

            

            _repository.ProductRepository.Update(productFound);
            _repository.Save();
        }
    }
}
