using System.ComponentModel.DataAnnotations;

namespace ViewModels.Recipes
{
    public   class RecipeEditViewModel
    {
        private const string NameErrorMesage = "Name should be at least 4 characters long!";
        private const string InstructionsErrorMesage = "Instructions should be at least 20 characters long!";
        private const string CookingTimeErrorMesage = "Cooking time cannot be zero or negative number!";

        public string Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = NameErrorMesage)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(30,ErrorMessage = InstructionsErrorMesage)]
        public string Instructions { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = CookingTimeErrorMesage)]
        public int CookingTime { get; set; }
    }
}



