using System.Collections.Generic;

namespace Storeroom.Domain.Models
{
    public class ProductProp : EntityBase
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<Product> Products { get; set;}
    }
}