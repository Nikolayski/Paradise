using Models.Enums;

namespace ViewModels.Recipes
{
    public   class RecipeAllViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string ImageUrl { get; set; }

        public ProductType ProductType { get; set; }
    }
}
