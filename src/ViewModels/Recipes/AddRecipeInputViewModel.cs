using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Recipes
{
    public   class AddRecipeInputViewModel
    {
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(1, 3)]
        public ProductType ProductType { get; set; }

        [Required]
        [MinLength(30)]
        public string Instructions { get; set; }

        [Range(0, int.MaxValue)]
        public int CookingTime { get; set; }
    }
}
