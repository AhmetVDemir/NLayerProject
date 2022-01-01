using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UNLayerP.Core.Models;

namespace UNLayerP.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 99, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 7.25m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 25.50m, Stock = 70, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Dolma Kalem", Price = 10m, Stock = 100, CategoryId = _ids[0] },

                new Product { Id = 5, Name = "Küçük Defter", Price = 55m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Orta Boy Defter", Price = 26m, Stock = 75, CategoryId = _ids[1] },
                new Product { Id = 7, Name = "Büyük Defter", Price = 20, Stock = 10, CategoryId = _ids[1] },
                new Product { Id = 8, Name = "Kareli Defter", Price = 5m, Stock = 5, CategoryId = _ids[1] }

                );
        }
    }
}
