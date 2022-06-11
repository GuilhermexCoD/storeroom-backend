using System;

namespace Storeroom.Domain.Models
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Guid? FamilyId { get; set; }
        public Family Family { get; set; }
        public Family OwnFamily { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageURL { get; set; }
        public string Password { get; set; }
    }
}