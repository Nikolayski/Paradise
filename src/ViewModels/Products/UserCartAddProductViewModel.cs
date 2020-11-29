using System.Collections.Generic;
using System.Linq;

namespace ViewModels.Products
{
  public  class UserCartAddProductViewModel
    {
        public string Id { get; set; }

        public ICollection<ProductToAddViewModel> Products { get; set; }

        public decimal TotalPrice => this.Products.Sum(x => x.Price);
    }
}
