using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Stock;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class StockService : ServiceBase, IStockService
    {
        private readonly IMapper _mapper;
        public StockService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void ConsumeStock(Guid productId, uint quantity)
        {
            var stocks = _repository.StockRepository.FindByCondition(x => x.ProductId == productId && x.Quantity > 0).OrderBy(x => x.Quantity).ToList();

            foreach (var stock in stocks)
            {
                if(stock.Quantity < quantity)
                {
                    quantity -= stock.Quantity;

                    stock.Quantity = 0;
                }
                else
                {
                    stock.Quantity -= quantity;
                    quantity = 0;
                    break;
                }
            }

            if(quantity > 0)
            {
                var product = _repository.ProductRepository.FindByCondition(x => x.Id == productId).FirstOrDefault();

                throw new InsufficientStock(product.Name);
            }

            _repository.Save();
        }

        public void CreateStock(StockDTO stock)
        {
            var stockCreate = _mapper.Map<Stock>(stock);

            stockCreate.Generate();

            _repository.StockRepository.Create(stockCreate);
            _repository.Save();
        }

        public void DeleteStock(Guid id)
        {
            var stockFound = _repository.StockRepository.FindByCondition(x => x.Id == id).FirstOrDefault();

            _repository.StockRepository.Delete(stockFound);
            _repository.Save();
        }

        public StockDTO GetStock(Guid id)
        {
            return _mapper.Map<StockDTO>(_repository.StockRepository.FindByCondition(x => x.Id == id).FirstOrDefault());
        }

        public List<ProductStockDTO> GetStockByProduct()
        {
            return _mapper.Map<List<ProductStockDTO>>(_repository.StockRepository.GetProductsStocks());
        }

        public List<StockDTO> GetStocks()
        {
            return _mapper.Map<List<StockDTO>>(_repository.StockRepository.GetAll().ToList());
        }

        public void UpdateStock(StockDTO stock)
        {
            var stockFound = _repository.StockRepository.FindByCondition(x => x.Id == stock.Id).FirstOrDefault();

            stockFound.SourceName = stock.SourceName;
            stockFound.Value = stock.Value;
            stockFound.DateModification = DateTime.Now;

            _repository.StockRepository.Update(stockFound);
            _repository.Save();
        }
    }
}
