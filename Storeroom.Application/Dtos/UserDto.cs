using System;
using System.ComponentModel.DataAnnotations;
using Storeroom.Domain.Models;

namespace Storeroom.Application.Dtos
{
    public class UserDto : EntityBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string FullName { get; set; }

        public Guid? FamilyId { get; set; }
        public FamilyDto Family { get; set; }
        public FamilyDto OwnFamily { get; set; }

        [Required]
        public string CreatedAt { get; set; }
        
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImageURL { get; set; }
    }
}