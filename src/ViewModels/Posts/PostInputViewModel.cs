using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ViewModels.Posts
{
  public  class PostInputViewModel
    {
        private const string TitleErrorMessage = "Too short description characters length!";
        private const string DescriptionErrorMessage = "Too short description characters length!";
        private const string UrlErrorMessage = "Invalid url";

        [Required]
        [MinLength(4,ErrorMessage = TitleErrorMessage)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = DescriptionErrorMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [MinLength(10,ErrorMessage = UrlErrorMessage)]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        public string CreatedOnToString => this.CreatedOn.AddHours(2).ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

    }
}
