using ViewModels.Index;

using System.Collections.Generic;

namespace Services.ImageService
{
    public interface IImageService
    {
        IEnumerable<IndexImageViewModel> GetIndexImages();
    }
}
