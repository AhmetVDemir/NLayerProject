using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UNLayerP.Core.Models;

namespace UNLayerP.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
