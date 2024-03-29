﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        List<Product> GetProductsFullInfo();
        Product? GetProductFullInfo(Guid id);
    }
}
