using Services.ImageService;

using Microsoft.AspNetCore.Mvc;

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
