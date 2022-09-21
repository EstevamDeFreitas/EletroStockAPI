using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.Interfaces;
using Services.DTO;
using Services.Exceptions.Shared;
using Services.Exceptions.ShoppingCart;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Implementation
{
    public class ShoppingCartService : ServiceBase, IShoppingCartService
    {
        private readonly IMapper _mapper;
        
        public ShoppingCartService(IRepositoryWrapper repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public void AddItem(ShoppingCartAddDTO item, Guid customerId)
        {
            if (item.Quantity == 0)
            {
                throw new QuantityMustBeDifferentFromZero();
            }

            var product = _repository.ProductRepository.GetProductFullInfo(item.ProductId);

            if(product is null)
            {
                throw new NotFound("Product");
            }

            if((product.InactiveReason is not null && !product.InactiveReason.InactiveCategory.Active) || (product.Stocks is null || !product.Stocks.Any(x => x.Quantity > 0)) )
            {
                throw new ProductIsInactive(product.Name);
            }

            var currentShoppingCart = _repository.ShoppingCartRepository.GetCustomerShoppingCart(customerId);

            if(currentShoppingCart is null)
            {
                var newShoppingCart = new ShoppingCart();
                newShoppingCart.CustomerId = customerId;
                newShoppingCart.CartValidity = DateTime.Now.AddHours(2);

                newShoppingCart.Generate();

                newShoppingCart.ShoppingCartItems = new List<ShoppingCartItem>();
                newShoppingCart.ShoppingCartItems.Add(new ShoppingCartItem { ProductId = item.ProductId, Quantity = item.Quantity, ShoppingCartId = newShoppingCart.Id });

                _repository.ShoppingCartRepository.Create(newShoppingCart);
                _repository.Save();

                return;
            }

            if(currentShoppingCart.ShoppingCartItems.Exists(x => x.ProductId == item.ProductId))
            {
                throw new ProductAlreadySelected(currentShoppingCart.ShoppingCartItems.First(x => x.ProductId == item.ProductId).Product.Name);
            }

            currentShoppingCart.ShoppingCartItems.Add(new ShoppingCartItem { ProductId = item.ProductId, Quantity = item.Quantity, ShoppingCartId = currentShoppingCart.Id });

            currentShoppingCart.CartValidity = DateTime.Now.AddHours(2);

            _repository.ShoppingCartRepository.Update(currentShoppingCart);
            _repository.Save();
        }

        public void DeleteShoppingCart(Guid id)
        {
            var shoppingCart = _repository.ShoppingCartRepository.FindByCondition(x => x.Id== id).FirstOrDefault();

            _repository.ShoppingCartRepository.Delete(shoppingCart);
            _repository.Save();
        }

        public ShoppingCartDTO GetShoppingCart(Guid customerId)
        {
            var shoppingCart = _repository.ShoppingCartRepository.GetCustomerShoppingCart(customerId);

            if(shoppingCart is null)
            {
                throw new NotFound("Shopping Cart");
            }

            return _mapper.Map<ShoppingCartDTO>(shoppingCart);
        }

        public void RemoveItem(ShoppingCartItemDTO item)
        {
            var cartItem = _repository.ShoppingCartItemRepository.FindByCondition(x => x.ShoppingCartId == item.ShoppingCartId && x.ProductId == item.ProductId).FirstOrDefault();

            _repository.ShoppingCartItemRepository.Delete(cartItem);
            _repository.Save();
        }

        public void UpdateItem(ShoppingCartItemDTO item)
        {
            var cartItem = _repository.ShoppingCartItemRepository.FindByCondition(x => x.ShoppingCartId == item.ShoppingCartId && x.ProductId == item.ProductId).FirstOrDefault();

            if(item.Quantity == 0)
            {
                throw new QuantityMustBeDifferentFromZero();
            }

            cartItem.Quantity = item.Quantity;

            _repository.ShoppingCartItemRepository.Update(cartItem);
            _repository.Save();
        }
    }
}
