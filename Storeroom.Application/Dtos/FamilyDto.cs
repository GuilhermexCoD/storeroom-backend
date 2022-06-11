using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Dtos
{
    public class FamilyDto : EntityBase
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        public Guid ManagerId { get; set; }
        public UserDto Manager { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImageURL { get; set; }
    }
}