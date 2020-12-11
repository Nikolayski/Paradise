using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ViewModels.Posts
{
  public  class PostInputViewModel
    {
        [Required]
        [MinLength(4,ErrorMessage = "Too short description characters length!")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Too short description characters length!")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [MinLength(13,ErrorMessage ="Invalid url")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Date")]
        public DateTime CreatedOn { get; set; }

        public string CreatedOnToString => this.CreatedOn.AddHours(2).ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

    }
}
