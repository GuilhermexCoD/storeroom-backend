using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Dtos
{
    public class ProductPropDto : EntityBase
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [MaxLength(12)]
        public string Barcode { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImageURL { get; set; }
        public IEnumerable<ProductDto> Products { get; set;}
    }
}