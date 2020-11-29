using Data;
using Models.Enums;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Index;

namespace Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ImageService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<IndexImageViewModel> GetIndexImages()
        {
            return this.db.Images.Where(x => x.Type == ImageType.Index)
                          .ProjectTo<IndexImageViewModel>(this.mapper.ConfigurationProvider);
        }
    }
}
