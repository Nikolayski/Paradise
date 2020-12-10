using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ViewModels.Users
{
 public   class UserOrderViewModel
    {
        public string Id { get; set; }

        
        public string UserName { get; set; }

       
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

       
        public string Address { get; set; }

        
        public string PhoneNumber { get; set; }

        public ICollection<ProductsUserOrderViewModel> Products { get; set; }

        public decimal TotalSum => this.Products.Sum(x => x.Price);


    }
}
