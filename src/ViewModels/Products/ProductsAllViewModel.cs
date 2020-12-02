using Models.Enums;

namespace ViewModels.Products
{
    public   class ProductsAllViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public ProductCountry ProductCountry { get; set; }
    }
}
