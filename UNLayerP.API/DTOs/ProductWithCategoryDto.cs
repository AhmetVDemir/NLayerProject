namespace UNLayerP.API.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
