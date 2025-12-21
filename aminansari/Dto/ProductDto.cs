using aminansari.Models;

namespace aminansari.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int count { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }




        public int CategoryId { get; set; }
        public string CategoriesName { get; set; }
        public string CategoriesDescription { get; set; }
        public List<CategoryDto> Categories { get; set; }

        public ProductDto()
        {
            Categories = new List<CategoryDto>();
        }

    }
}
