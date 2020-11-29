using System.Collections.Generic;

using ViewModels.Index;

namespace Services.ImageService
{
    public    interface IImageService
    {
        IEnumerable<IndexImageViewModel> GetIndexImages();
    }
}
