using System.Collections.Generic;

namespace Storeroom.Domain.Models
{
    public class ProductStatus : EntityBase
    {
        public string Type { get; set; }
        public IEnumerable<Product> Products{ get; set; }
    }
}