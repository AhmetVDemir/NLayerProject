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
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
