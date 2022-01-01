using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UNLayerP.API.Controllers;

namespace UNLayerP.API.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
