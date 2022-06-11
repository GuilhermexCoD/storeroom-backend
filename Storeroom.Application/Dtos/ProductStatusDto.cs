using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Dtos
{
    public class ProductStatusDto : EntityBase
    {
        [Required]
        public string Type { get; set; }
        public IEnumerable<ProductDto> Products{ get; set; }
    }
}