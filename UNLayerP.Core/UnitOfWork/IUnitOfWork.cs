using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UNLayerP.Core.Repositories;

namespace UNLayerP.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task CommitAsync();

        void Commit();
    }
}
