using System.Collections.Generic;

using ViewModels.Products;

namespace ViewModels.Carts
{
    public    class CartAddProductViewModel
    {
        public string Id { get; set; }

        public ICollection<ProductToAddViewModel> Products { get; set; }
    }
}
