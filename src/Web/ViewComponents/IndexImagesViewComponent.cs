using Microsoft.AspNetCore.Mvc;

using Services.ImageService;

namespace Web.ViewComponents
{
    public class IndexImagesViewComponent : ViewComponent
    {
        private readonly IImageService imageService;

        public IndexImagesViewComponent(IImageService imageService)
        {
            this.imageService = imageService;
        }
        public IViewComponentResult Invoke()
        {
            var indexImages = this.imageService.GetIndexImages();
            return this.View(indexImages);
        }
    }
}
