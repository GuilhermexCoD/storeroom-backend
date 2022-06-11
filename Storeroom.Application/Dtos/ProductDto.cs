using System;
using System.ComponentModel.DataAnnotations;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Dtos
{
    public class ProductDto : EntityBase
    {
        [Required]
        public Guid ProductPropId { get; set; }
        public ProductPropDto ProductProp { get; set; }

        [Required]
        public Guid ProductStatusId { get; set; }
        public ProductStatusDto ProductStatus { get; set; }

        [Required]
        public Guid FamilyId { get; set; }
        public FamilyDto Family { get; set; }

        [Required]
        [Range(0.01f,1000000)]
        public decimal Price { get; set; }

        [Required]
        public string BoughtAt { get; set; }
        
        [Required]
        public string ExpireAt { get; set; }
    }
}