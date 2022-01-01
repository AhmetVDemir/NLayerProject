using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UNLayerP.Core.Models;
using UNLayerP.Core.Repositories;
using UNLayerP.Core.Services;
using UNLayerP.Core.UnitOfWork;

namespace UNLayerP.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
