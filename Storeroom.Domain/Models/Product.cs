using System;

namespace Storeroom.Domain.Models
{
    public class Product : EntityBase
    {
        public Guid ProductPropId { get; set; }
        public ProductProp ProductProp { get; set; }
        public Guid ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public Guid FamilyId { get; set; }
        public Family Family { get; set; }
        public decimal Price { get; set; }
        public DateTime BoughtAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}