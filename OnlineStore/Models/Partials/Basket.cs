using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public partial class Basket
    {
        public override string ToString()
        {
            return $"{Product.Name} {Product.Description} {Product.Price} {Product.Baskets.FirstOrDefault(p => p.ProductId == Product.Id).CountProduct}";

        }
    }
}
