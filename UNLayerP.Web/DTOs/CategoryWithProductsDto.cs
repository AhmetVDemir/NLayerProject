using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace UNLayerP.Web.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }

    }
}
